# Telegraph.Sharp

[![package](https://img.shields.io/nuget/vpre/Telegraph.Sharp.svg)](https://www.nuget.org/packages/Telegraph.Sharp)
[![build](https://github.com/Dippere/Telegraph.Sharp/actions/workflows/main.yml/badge.svg)](https://github.com/Dippere/Telegraph.Sharp/actions/workflows/main.yml/badge.svg)

Simple to use API client for [Telegra.ph](https://telegra.ph).

## Quickstart

Sample code to create a new page:

```csharp
using Telegraph.Sharp;
using Telegraph.Sharp.Types;

// Create API client
var telegraphClient = new TelegraphClient();

// Create Telegraph account
var account = await telegraphClient.CreateAccountAsync("Short Name", "Author name", "Author URL");

// Provide access token
telegraphClient.AccessToken = account.AccessToken;

// Create new page
var pageContent = new List<Node>
{
    Node.H3("Hello world!"),
    Node.P("Test page")
};

var page = await telegraphClient.CreatePageAsync("Title", pageContent);
```