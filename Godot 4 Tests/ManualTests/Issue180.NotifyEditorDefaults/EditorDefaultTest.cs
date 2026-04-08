using Godot;

namespace GodotTests.ManualTests;

[Tool]
public partial class EditorDefaultTest : Node
{
    [Export, Notify] public partial int PartialNoDefault { get; set; }
    [Export, Notify] public partial int PartialInlineDefault { get; set; } = 7;

    [Export, Notify] public int NonPartialNoDefault { get => _nonPartialNoDefault.Get(); set => _nonPartialNoDefault.Set(value); }
    [Export, Notify] public int NonPartialInlineDefault { get => field = _nonPartialInlineDefault.Get(); set => _nonPartialInlineDefault.Set(field = value); } = 7;

    [Export, Notify] public partial Shape2D ObjPartialNoDefault { get; set; }
    [Export, Notify] public partial Shape2D ObjPartialInlineDefault { get; set; } = new CircleShape2D();

    [Export, Notify] public Shape2D ObjNonPartialNoDefault { get => _objNonPartialNoDefault.Get(); set => _objNonPartialNoDefault.Set(value); }
    [Export, Notify] public Shape2D ObjNonPartialInlineDefault { get => field = _objNonPartialInlineDefault.Get(); set => _objNonPartialInlineDefault.Set(field = value); } = new CircleShape2D();
}
