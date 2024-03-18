# Telegraph.Sharp

[![package](https://img.shields.io/nuget/vpre/Telegraph.Sharp.svg)](https://www.nuget.org/packages/Telegraph.Sharp)

Simple to use API client for [Telegra.ph](https://telegra.ph) on .NET 8.

For other dotnet version use package [version 1](https://www.nuget.org/packages/Telegraph.Sharp/1.0.0) instead.

## Quickstart

Sample code to create a new page:

```csharp
using Telegraph.Sharp;
using Telegraph.Sharp.Types;

// Create API client
ITelegraphClient telegraphClient = new TelegraphClient();

// Create Telegraph account
Account account = await telegraphClient.CreateAccountAsync("Short Name", "Author name", "Author URL");

// Provide access token
telegraphClient.AccessToken = account.AccessToken;

// Create new page
var pageContent = new List<Node>
{
    Node.H3("Hello world!"),
    Node.P("Test page")
};

Page page = await telegraphClient.CreatePageAsync("Title", pageContent);
```