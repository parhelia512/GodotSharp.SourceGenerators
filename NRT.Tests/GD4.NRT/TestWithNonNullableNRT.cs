using Godot;
using GodotSharp.SourceGenerators;

namespace NRT.Tests;

[SceneTree, Instantiable(ctor: Scope.None)]
public partial class TestWithNonNullableNRT : Node
{
    public static readonly Shape2D DFLT = new CircleShape2D();

    public required Shape2D InstantiateValue1;
    public required Shape2D InstantiateValue2;
    public Shape2D NotifyActionValue = DFLT;

    //public Shape2D NonInitialisedValue; // WARNING
    public required Shape2D NonInitialisedValue; // No warning

    [Notify]
    public Shape2D NotifyTest
    {
        get => _notifyTest.Get();
        set => _notifyTest.Set(value);
    }

    [Notify]
    public Shape2D NotifyTestWithAction
    {
        get => _notifyTestWithAction.Get();
        set => _notifyTestWithAction.Set(value, OnNotifyTestWithActionChanged);
    }

    [Notify]
    public Shape2D NotifyTestWithDefaultHack
    {
        get => field = _notifyTestWithDefaultHack.Get();
        set => _notifyTestWithDefaultHack.Set(field = value);
    } = DFLT;

    [Notify]
    public partial Shape2D NotifyTestUsingPartial { get; set; }

    [Notify]
    public partial Shape2D NotifyTestUsingPartialWithDefault { get; set; } = DFLT;

    [OnInstantiate(ctor: Scope.None)]
    private void OnInstantiateTest(Shape2D value1 = default!, Shape2D value2 = null!)
    {
        InstantiateValue1 = value1 ?? DFLT;
        InstantiateValue2 = value2 ?? DFLT;
    }

    private void OnNotifyTestWithActionChanged()
        => NotifyActionValue = NotifyTestWithAction;

    private TestWithNonNullableNRT()
    {
        InitNotifyTest(DFLT);
        InitNotifyTestWithAction(DFLT);
    }

    private void Init(Shape2D value1 = default!, Shape2D value2 = null!)
    {
        InstantiateValue1 = value1 ?? DFLT;
        InstantiateValue2 = value2 ?? DFLT;
    }
}
