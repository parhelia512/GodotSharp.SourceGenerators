using FluentAssertions;
using Godot;

namespace NRT.Tests;

[SceneTree]
public partial class Main : Node
{
    [GodotOverride]
    private void OnReady()
    {
        var DFLT = TestWithNonNullableNRT.DFLT;
        var VALUE = new CapsuleShape2D();

        // Setup
        var nullableWithNull = TestWithNullableNRT.Instantiate();
        var nullableWithNotNull = TestWithNullableNRT.Instantiate(VALUE, VALUE);
        var nonNullableWithEmpty = TestWithNonNullableNRT.Instantiate(); // (should not compile with null/default)
        var nonNullableWithNotEmpty = TestWithNonNullableNRT.Instantiate(VALUE, VALUE);

        var newNullableWithNull = TestWithNullableNRT.New();
        var newNullableWithNotNull = TestWithNullableNRT.New(VALUE, VALUE);
        var newNonNullableWithEmpty = TestWithNonNullableNRT.New(); // (should not compile with null/default)
        var newNonNullableWithNotEmpty = TestWithNonNullableNRT.New(VALUE, VALUE);

        TestNew();
        TestNotify();
        TestInstantiate();
        TestNotifyWithAction();

        // Teardown
        nullableWithNull.Free();
        nullableWithNotNull.Free();
        nonNullableWithEmpty.Free();
        nonNullableWithNotEmpty.Free();

        newNullableWithNull.Free();
        newNullableWithNotNull.Free();
        newNonNullableWithEmpty.Free();
        newNonNullableWithNotEmpty.Free();

        GD.Print("TEST PASS OK");

        GetTree().Quit();

        void TestNew()
        {
            newNullableWithNull.InstantiateValue1.Should().Be(null);
            newNullableWithNull.InstantiateValue2.Should().Be(default);
            newNullableWithNotNull.InstantiateValue1.Should().Be(VALUE);
            newNullableWithNotNull.InstantiateValue2.Should().Be(VALUE);
            newNonNullableWithEmpty.InstantiateValue1.Should().Be(DFLT);
            newNonNullableWithEmpty.InstantiateValue2.Should().Be(DFLT);
            newNonNullableWithNotEmpty.InstantiateValue1.Should().Be(VALUE);
            newNonNullableWithNotEmpty.InstantiateValue2.Should().Be(VALUE);
        }

        void TestInstantiate()
        {
            nullableWithNull.InstantiateValue1.Should().Be(null);
            nullableWithNull.InstantiateValue2.Should().Be(default);
            nullableWithNotNull.InstantiateValue1.Should().Be(VALUE);
            nullableWithNotNull.InstantiateValue2.Should().Be(VALUE);
            nonNullableWithEmpty.InstantiateValue1.Should().Be(DFLT);
            nonNullableWithEmpty.InstantiateValue2.Should().Be(DFLT);
            nonNullableWithNotEmpty.InstantiateValue1.Should().Be(VALUE);
            nonNullableWithNotEmpty.InstantiateValue2.Should().Be(VALUE);
        }

        void TestNotify()
        {
            nullableWithNull.NotifyTest.Should().Be(null);
            nullableWithNotNull.NotifyTest.Should().Be(null);
            nonNullableWithEmpty.NotifyTest.Should().Be(DFLT);
            nonNullableWithNotEmpty.NotifyTest.Should().Be(DFLT);

            nullableWithNull.NotifyTest = null;
            nullableWithNotNull.NotifyTest = VALUE;
            nonNullableWithEmpty.NotifyTest = DFLT;
            nonNullableWithNotEmpty.NotifyTest = VALUE;

            nullableWithNull.NotifyTest.Should().Be(null);
            nullableWithNotNull.NotifyTest.Should().Be(VALUE);
            nonNullableWithEmpty.NotifyTest.Should().Be(DFLT);
            nonNullableWithNotEmpty.NotifyTest.Should().Be(VALUE);
        }

        void TestNotifyWithAction()
        {
            nullableWithNull.NotifyActionValue.Should().Be(null);
            nullableWithNotNull.NotifyActionValue.Should().Be(null);
            nonNullableWithEmpty.NotifyActionValue.Should().Be(DFLT);
            nonNullableWithNotEmpty.NotifyActionValue.Should().Be(DFLT);

            nullableWithNull.NotifyTestWithAction.Should().Be(null);
            nullableWithNotNull.NotifyTestWithAction.Should().Be(null);
            nonNullableWithEmpty.NotifyTestWithAction.Should().Be(DFLT);
            nonNullableWithNotEmpty.NotifyTestWithAction.Should().Be(DFLT);

            nullableWithNull.NotifyTestWithAction = null;
            nullableWithNotNull.NotifyTestWithAction = VALUE;
            nonNullableWithEmpty.NotifyTestWithAction = DFLT;
            nonNullableWithNotEmpty.NotifyTestWithAction = VALUE;

            nullableWithNull.NotifyTestWithAction.Should().Be(null);
            nullableWithNotNull.NotifyTestWithAction.Should().Be(VALUE);
            nonNullableWithEmpty.NotifyTestWithAction.Should().Be(DFLT);
            nonNullableWithNotEmpty.NotifyTestWithAction.Should().Be(VALUE);

            nullableWithNull.NotifyActionValue.Should().Be(null);
            nullableWithNotNull.NotifyActionValue.Should().Be(VALUE);
            nonNullableWithEmpty.NotifyActionValue.Should().Be(DFLT);
            nonNullableWithNotEmpty.NotifyActionValue.Should().Be(VALUE);
        }
    }

    public override partial void _Ready();
}
