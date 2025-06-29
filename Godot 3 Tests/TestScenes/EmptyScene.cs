using FluentAssertions;
using Godot;
using GodotSharp.BuildingBlocks.TestRunner;

namespace GodotTests.TestScenes;

[SceneTree]
public partial class EmptyScene : Control, ITest
{
    public int RequiredFrames => 1;

    private bool GodotOverride_WithArgs_WasCalled;
    private bool GodotOverride_WithNoArgs_WasCalled;

    [GodotOverride] public void OnEnterTree() => GodotOverride_WithNoArgs_WasCalled = true;
    [GodotOverride] public void OnProcess(float _) => GodotOverride_WithArgs_WasCalled = true;

    void ITest.ProcessTests()
    {
        GodotOverride_WithArgs_WasCalled.Should().BeTrue();
        GodotOverride_WithNoArgs_WasCalled.Should().BeTrue();
    }

    void ITest.InitTests()
        => _.GetType().GetProperties().Should().BeEmpty();
}
