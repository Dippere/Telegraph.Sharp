# Telegraph.Sharp

[![package](https://img.shields.io/nuget/vpre/Telegraph.Sharp.svg)](https://www.nuget.org/packages/Telegraph.Sharp)

Simple to use API client for [Telegra.ph](https://telegra.ph) on .NET 8.

## Quickstart

Sample code to create a new page:

```csharp
using Telegraph.Sharp;
using Telegraph.Sharp.Types;

// Create client
ITelegraphClient telegraphClient = new TelegraphClient();

// Or with API access token for access to all methods
ITelegraphClient telegraphClient = new TelegraphClient("<ACCESS TOKEN>");

// Create Telegraph account
Account account = await telegraphClient.CreateAccountAsync("Short Name", "Author name", "Author URL");

// Create new page
var pageContent = new List<Node>
{
    Node.H3("Hello world!"),
    Node.P("Test page")
};

Page page = await telegraphClient.CreatePageAsync("Title", pageContent);
```