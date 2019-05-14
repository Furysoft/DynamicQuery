# Furysoft.DynamicQuery

## About

Core library for dynamically parsing custom queries.

## Install

Install using NuGet

```cmd
Install-package Furysoft.DynamicQuery
```

## Usage

Custom queries can be parsed by injecting the *IDynamicQueryParser* interface into your code.

Calling IDynamicQueryParser.Parse\<TEntity>(...) will parse the provided string into a Query structure.

The provided TEntity defines the permitted values of the query.

### Example usage

```csharp
public class SampleEntity
{
    public string Name { get;set; }

    public string Age { get; set;}
}

public class SampleParsing
{
    private readonly IQueryParser queryParser;

    public void ParseSample()
    {
        IQuery query = this.queryParser.Parse<SampleEntity>("where::Name:\"Test Name\" and Age:24 and Password:value orderby::Name page::1,25");
    }
}
```

In the above example, the where part of the query will be parsed, producing a query that will check where the **Name** value is equal *Test Name*, the **Age** value is 24.

The Password query will not appear in the parsed query, as Password is not a valid query parameter as defined in the **SampleEntity** class.

The Property name can be overriden using a *DataMemberAttribute* or the provided *NameAttribute*
A Property name can be excluded using the *ExcludeAttribute*

Example:

```csharp
public class SampleEntity
{
    [DataMember(Name = "users_name")]
    public string Name { get;set; }
    // where::Name:"value" will be excluded.
    // where::users_name:"value" will be accepted.

    [Name(Name = "user_name")]
    public string UserName { get; set; }
    // where::UserName:"value" will be excluded.
    // where::user_name:"value" will be accepted.

    [Exclude]
    public string Password { get;set; }
    // where::Password:"letmein" will be excluded
}
```

## Query Components

### where

A where query component defines a where query. It is defined via the *where::* keyword. Multiple where parts can be joined using *and* and *or*

Keywords can be escaped using the backslash \ character

#### Equality

Equality can be checked using the format: *PropertyName:Value*
Non-equality can be checked using the *!* keyword
Wildcard searches can be performed using *\**. Wildcards can be placed at any point in the query string

```csharp
"where::Key:value" // Where Key = "value"
"where::Key:123" // Where Key = 123
"where::Key:\"longer value\"" // Where Key = "longer value". Strings with spaces must be quoted
"where::Key:!value" // Where Key is not equal to "value"
"where::Key:\!value" // Where Key is equal to "!value"
"where::Key:value and Other:test" // Where Key = "value" and Other = "test"
"where::Key:*value*" // Where contains the substring "value"
```

#### Ranges

Ranges are searched using the PropertyName and the range to search for. Ranges are defined using a range of two values, either inclusive or exclusive. Wildcards can be used to define boundless ranges.

Inclusive ranges are defined using {val1,val2}
Exclusive rangers are defined using [val1,val2]

Examples:

```csharp
"where::Key:[1,10]" // Where Key is between 1 and 10 (not including 1 and 10)
"where::Key:{1,10}" // Where Key is between 1 and 10 (including 1 and 10)
"where::Key[1,10}" // Where Key is between 1 and 10 (not including 1 and including 10)
"where::Key{1,10]" // Where Key is between 1 and 10 (including 1 and not including 10)
"where::Key[*,10]" // Where Key is less than 10
"where::Key[*,10}" // Where Key is less or equal to than 10
"where::Key[1,*]" // Where Key is greater than 1
"where::Key{1,*]" // Where Key is greater or equal to than 1
"where::Key{\"2019-1-1T00:00:00\",*]" // Where Key is greater or equal to than 1st Jan 2019
```

### OrderBy

Determines the properties to order by, and the direction. Multiple order by properties can be defined.
OrderBy is declared using the *orderby::* component.
OrderBy can be asc or desc.
OrderBy is limited by the permitted property set as defined by the Query Parse Entity

```csharp
"orderby::column1 asc" // Orders by column1 ascending
"orderby::column1 desc" // Orders by column1 descending
"orderby::column1 desc column2 asc" // Orders by column1 descending, then by column2 ascending
```

### Page

Paging data can be provided using the *page::* component. The format takes a page number, and items per page.

example:

```csharp
"page::1,5" // Page 1, 5 Items per page
```