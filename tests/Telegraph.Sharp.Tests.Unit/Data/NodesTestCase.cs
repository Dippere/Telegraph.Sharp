using System;
using System.Collections.Generic;
using System.Linq;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Tests.Unit.Data;

public record NodesTestCase(
    TagEnum TagEnum,
    Node NodeEmpty,
    Node NodeSingle,
    string Single,
    Node NodeSeveral,
    string Text1,
    string Text2,
    Node NodeEmptyList
)
{
    private const string SingleC = "single";
    private const string Text1C = "text1";
    private const string Text2C = "text2";

    private static readonly NodesTestCase[] TestCases =
    {
        new(TagEnum.Pre, Node.Pre(), Node.Pre(SingleC), SingleC, Node.Pre(Text1C, Text2C), Text1C, Text2C,
            Node.Pre(Array.Empty<Node>())), // Pre
        new(TagEnum.Code, Node.Code(), Node.Code(SingleC), SingleC, Node.Code(Text1C, Text2C), Text1C, Text2C,
            Node.Code(Array.Empty<Node>())), // Code
        new(TagEnum.Blockquote, Node.Blockquote(), Node.Blockquote(SingleC), SingleC, Node.Blockquote(Text1C, Text2C),
            Text1C, Text2C, Node.Blockquote(Array.Empty<Node>())), // Blockquote
        new(TagEnum.Aside, Node.Aside(), Node.Aside(SingleC), SingleC, Node.Aside(Text1C, Text2C), Text1C, Text2C,
            Node.Aside(Array.Empty<Node>())), // Aside
        new(TagEnum.H3, Node.H3(), Node.H3(SingleC), SingleC, Node.H3(Text1C, Text2C), Text1C, Text2C,
            Node.H3(Array.Empty<Node>())), // H3
        new(TagEnum.H4, Node.H4(), Node.H4(SingleC), SingleC, Node.H4(Text1C, Text2C), Text1C, Text2C,
            Node.H4(Array.Empty<Node>())), // H4
        new(TagEnum.P, Node.P(), Node.P(SingleC), SingleC, Node.P(Text1C, Text2C), Text1C, Text2C,
            Node.P(Array.Empty<Node>())), // P
        new(TagEnum.B, Node.B(), Node.B(SingleC), SingleC, Node.B(Text1C, Text2C), Text1C, Text2C,
            Node.B(Array.Empty<Node>())), // B
        new(TagEnum.I, Node.I(), Node.I(SingleC), SingleC, Node.I(Text1C, Text2C), Text1C, Text2C,
            Node.I(Array.Empty<Node>())), // I
        new(TagEnum.U, Node.U(), Node.U(SingleC), SingleC, Node.U(Text1C, Text2C), Text1C, Text2C,
            Node.U(Array.Empty<Node>())), // U
        new(TagEnum.S, Node.S(), Node.S(SingleC), SingleC, Node.S(Text1C, Text2C), Text1C, Text2C,
            Node.S(Array.Empty<Node>())), // S
        new(TagEnum.Strong, Node.Strong(), Node.Strong(SingleC), SingleC, Node.Strong(Text1C, Text2C), Text1C, Text2C,
            Node.Strong(Array.Empty<Node>())), // Strong 
        new(TagEnum.Li, Node.Li(), Node.Li(SingleC), SingleC, Node.Li(Text1C, Text2C), Text1C, Text2C,
            Node.Li(Array.Empty<Node>())), //Li
        new(TagEnum.Figcaption, Node.Figcaption(), Node.Figcaption(SingleC), SingleC, Node.Figcaption(Text1C, Text2C),
            Text1C, Text2C, Node.Figcaption(Array.Empty<Node>())), // Figcaption
        new(TagEnum.Em, Node.Em(), Node.Em(SingleC), SingleC, Node.Em(Text1C, Text2C), Text1C, Text2C,
            Node.Em(Array.Empty<Node>())), // Em
        new(TagEnum.Ol, Node.Ol(), Node.Ol(SingleC), SingleC, Node.Ol(Text1C, Text2C), Text1C, Text2C,
            Node.Ol(Array.Empty<Node>())), // Ol
        new(TagEnum.Ul, Node.Ul(), Node.Ul(SingleC), SingleC, Node.Ul(Text1C, Text2C), Text1C, Text2C,
            Node.Ul(Array.Empty<Node>())) // Ul
    };

    public static IEnumerable<object[]> TestCasesData =>
        TestCases.Select(testCase => new object[] { testCase });

    public override string ToString() => TagEnum.ToString();
}