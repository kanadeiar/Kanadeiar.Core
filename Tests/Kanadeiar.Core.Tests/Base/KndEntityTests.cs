using FluentAssertions;
using Kanadeiar.Core.Base;
using Xunit;

namespace Kanadeiar.Core.Tests.Encoders;

public class KndEntityTests
{
    [Fact]
    public void Ctor_Correct_ShouldOk()
    {
        var expected = 1;

        var actual = new KndEntityFake(expected);

        actual.Id.Should().Be(expected);
    }
    [Fact]
    public void Equals_Null_Should_False()
    {
        const object expected = null;
        var entity = new KndEntityFake(1);

        var actual = entity.Equals(expected);

        actual.Should().BeFalse();
    }
    [Fact]
    public void Equals_EqualCorrect_ShouldEqual()
    {
        var expected1 = new KndEntityFake(1);
        var expected2 = new KndEntityFake(1);

        var actual = expected1.Equals(expected2);

        actual.Should().BeTrue();
    }
    [Fact]
    public void Equals_NotEqual_ShouldNotEqual()
    {
        var expected1 = new KndEntityFake(1);
        var expected2 = new KndEntityFake(2);

        var actual = expected1.Equals(expected2);

        actual.Should().BeFalse();
    }
    [Fact]
    public void Equals_Object_ShouldEqual()
    {
        var expected1 = new KndEntityFake(1);
        object objExpected = new KndEntityFake(1);

        var actual = expected1.Equals(objExpected);

        actual.Should().BeTrue();
    }
}

public class KndEntityFake : KndEntity<int>
{
    public KndEntityFake(int Id) : base(Id)
    {
    }
}