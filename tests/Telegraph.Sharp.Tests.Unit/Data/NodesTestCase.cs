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
);
