using Telegraph.Sharp.Tests.Unit.Data;

namespace Telegraph.Sharp.Tests.Unit.Attributes;

public class DisplayNodesTestCaseFormatter : ArgumentDisplayFormatter
{
    public override bool CanHandle(object? value) => value is NodesTestCase;

    public override string FormatValue(object? value)
    {
        var fixture = value as NodesTestCase;
        return fixture?.TagEnum.ToString() ?? string.Empty;
    }
}
