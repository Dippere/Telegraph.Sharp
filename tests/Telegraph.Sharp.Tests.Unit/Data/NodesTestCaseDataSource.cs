using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Tests.Unit.Data;

public static class NodesTestCaseDataSource
{
    private const string SingleC = "single";
    private const string Text1C = "text1";
    private const string Text2C = "text2";

    public static IEnumerable<Func<NodesTestCase>> TestCases()
    {
        yield return () => new NodesTestCase(TagEnum.Pre, Node.Pre(), Node.Pre(SingleC), SingleC,
            Node.Pre(Text1C, Text2C), Text1C, Text2C,
            Node.Pre(Array.Empty<Node>())); // Pre
        yield return () => new NodesTestCase(TagEnum.Code, Node.Code(), Node.Code(SingleC), SingleC,
            Node.Code(Text1C, Text2C), Text1C, Text2C,
            Node.Code(Array.Empty<Node>())); // Code
        yield return () => new NodesTestCase(TagEnum.Blockquote, Node.Blockquote(), Node.Blockquote(SingleC), SingleC,
            Node.Blockquote(Text1C, Text2C),
            Text1C, Text2C, Node.Blockquote(Array.Empty<Node>())); // Blockquote
        yield return () => new NodesTestCase(TagEnum.Aside, Node.Aside(), Node.Aside(SingleC), SingleC,
            Node.Aside(Text1C, Text2C), Text1C, Text2C,
            Node.Aside(Array.Empty<Node>())); // Aside
        yield return () => new NodesTestCase(TagEnum.H3, Node.H3(), Node.H3(SingleC), SingleC, Node.H3(Text1C, Text2C),
            Text1C, Text2C,
            Node.H3(Array.Empty<Node>())); // H3
        yield return () => new NodesTestCase(TagEnum.H4, Node.H4(), Node.H4(SingleC), SingleC, Node.H4(Text1C, Text2C),
            Text1C, Text2C,
            Node.H4(Array.Empty<Node>())); // H4
        yield return () => new NodesTestCase(TagEnum.P, Node.P(), Node.P(SingleC), SingleC, Node.P(Text1C, Text2C),
            Text1C, Text2C,
            Node.P(Array.Empty<Node>())); // P
        yield return () => new NodesTestCase(TagEnum.B, Node.B(), Node.B(SingleC), SingleC, Node.B(Text1C, Text2C),
            Text1C, Text2C,
            Node.B(Array.Empty<Node>())); // B
        yield return () => new NodesTestCase(TagEnum.I, Node.I(), Node.I(SingleC), SingleC, Node.I(Text1C, Text2C),
            Text1C, Text2C,
            Node.I(Array.Empty<Node>())); // I
        yield return () => new NodesTestCase(TagEnum.U, Node.U(), Node.U(SingleC), SingleC, Node.U(Text1C, Text2C),
            Text1C, Text2C,
            Node.U(Array.Empty<Node>())); // U
        yield return () => new NodesTestCase(TagEnum.S, Node.S(), Node.S(SingleC), SingleC, Node.S(Text1C, Text2C),
            Text1C, Text2C,
            Node.S(Array.Empty<Node>())); // S
        yield return () => new NodesTestCase(TagEnum.Strong, Node.Strong(), Node.Strong(SingleC), SingleC,
            Node.Strong(Text1C, Text2C), Text1C, Text2C,
            Node.Strong(Array.Empty<Node>())); // Strong
        yield return () => new NodesTestCase(TagEnum.Li, Node.Li(), Node.Li(SingleC), SingleC, Node.Li(Text1C, Text2C),
            Text1C, Text2C,
            Node.Li(Array.Empty<Node>())); //Li
        yield return () => new NodesTestCase(TagEnum.Figcaption, Node.Figcaption(), Node.Figcaption(SingleC), SingleC,
            Node.Figcaption(Text1C, Text2C),
            Text1C, Text2C, Node.Figcaption(Array.Empty<Node>())); // Figcaption
        yield return () => new NodesTestCase(TagEnum.Em, Node.Em(), Node.Em(SingleC), SingleC, Node.Em(Text1C, Text2C),
            Text1C, Text2C,
            Node.Em(Array.Empty<Node>())); // Em
        yield return () => new NodesTestCase(TagEnum.Ol, Node.Ol(), Node.Ol(SingleC), SingleC, Node.Ol(Text1C, Text2C),
            Text1C, Text2C,
            Node.Ol(Array.Empty<Node>())); // Ol
        yield return () => new NodesTestCase(TagEnum.Ul, Node.Ul(), Node.Ul(SingleC), SingleC, Node.Ul(Text1C, Text2C),
            Text1C, Text2C,
            Node.Ul(Array.Empty<Node>())); // Ul
    }
}
