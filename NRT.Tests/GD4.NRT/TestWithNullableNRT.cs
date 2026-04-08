using Godot;
using GodotSharp.SourceGenerators;

namespace NRT.Tests;

[SceneTree, Instantiable]
public partial class TestWithNullableNRT : Node
{
    public Shape2D? InstantiateValue1;
    public Shape2D? InstantiateValue2;
    public Shape2D? NotifyActionValue;

    public Shape2D? NonInitialisedValue;

    [Notify]
    public Shape2D? NotifyTest
    {
        get => _notifyTest.Get();
        set => _notifyTest.Set(value);
    }

    [Notify]
    public Shape2D? NotifyTestWithAction
    {
        get => _notifyTestWithAction.Get();
        set => _notifyTestWithAction.Set(value, OnNotifyTestWithActionChanged);
    }

    [Notify]
    public Shape2D? NotifyTestWithDefaultHack
    {
        get => field = _notifyTestWithDefaultHack.Get();
        set => _notifyTestWithDefaultHack.Set(field = value);
    } = null;

    [Notify]
    public partial Shape2D? NotifyTestUsingPartial { get; set; }

    [Notify]
    public partial Shape2D? NotifyTestUsingPartialWithDefault { get; set; } = null;

    [OnInstantiate(ctor: Scope.None)]
    private void OnInstantiateTest(Shape2D? value1 = null, Shape2D? value2 = default)
    {
        InstantiateValue1 = value1;
        InstantiateValue2 = value2;
    }

    private void OnNotifyTestWithActionChanged()
        => NotifyActionValue = NotifyTestWithAction;

    private void Init(Shape2D? value1 = null, Shape2D? value2 = default)
    {
        InstantiateValue1 = value1;
        InstantiateValue2 = value2;
    }
}
