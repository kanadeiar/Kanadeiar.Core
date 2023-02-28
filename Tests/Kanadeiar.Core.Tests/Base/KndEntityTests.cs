using FluentAssertions;
using Kanadeiar.Core.Base;
using Xunit;

namespace Kanadeiar.Core.Tests.Encoders;

public class KndEntityTests
{
    [Fact]
    public void Equals_Null_Should_False()
    {
        const object expected = null;
        var entity = new KndEntityFake(1);

        var actual = entity.Equals(expected);

        actual.Should().BeFalse();
    }
}

public class KndEntityFake : KndEntity<int>
{
    public KndEntityFake(int Id) : base(Id)
    {
    }
}