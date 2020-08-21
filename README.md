# SearchFight

Solution for the proposed challenge, based on [The Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) and .Net Core 3.1. The application will query against all the implemented search engines and compare how many results they return.

**Note 1:** Due to the limitiations on using libraries, I resorted to static referencing of the api keys. In a real world scenario, I would have made use of the `Microsoft.Extensions.Configuration` package for dynamic referencing via a json configuration file.<br>

**Note 2:** I've also resorted to basic IoC via constructor injection for some of the class dependencies. Without the restrictions I would have made use of `Microsoft.Extensions.DependencyInjection` to set up an IoC container for the dependencies.

## Usage

You can specify any number of search terms, the application also supports quotation marks to allow searching terms with spaces: 

```
dotnet .net "java script" java
```
Outputs:

```
.net:
        Google: 14810000000
        Bing: 125000000
java script:
        Google: 3540000000
        Bing: 210000000
java:
        Google: 720000000
        Bing: 124000000
Google winner: .net
Bing winner: java script
Total winner: .net
```

## Requirements

Specify the required api keys for the implemented [Google](https://developers.google.com/custom-search/v1/introduction#identify_your_application_to_google_with_api_key) and [Bing](https://azure.microsoft.com/en-us/services/cognitive-services/bing-web-search-api/) search engines. You can add more search engines by implementing the `ISearchEngineAPI` interface.<br>

In `GoogleQuery.cs`:
```
...
private readonly string _apiKey = "";
private readonly string _searchEngineId = "";
...
```
In `BingQuery.cs`
```
...
private readonly string _apiKey = "";
...
```
