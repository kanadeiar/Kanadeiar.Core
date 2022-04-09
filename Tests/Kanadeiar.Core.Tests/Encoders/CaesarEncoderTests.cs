using FluentAssertions;
using Kanadeiar.Core.Encoders;
using Xunit;

namespace Kanadeiar.Core.Tests.Encoders;

public class CaesarEncoderTests
{
    [Fact]
    public void Encode_ABCKey1_Should_BCD()
    {
        const string str = "ABC";
        const int key = 1;
        const string expected = "BCD";

        var actual = CaesarEncoder.Encode(str, key);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Decode_BCDKey1_Should_ABC()
    {
        const string str = "BCD";
        const int key = 1;
        const string expected = "ABC";

        var actual = CaesarEncoder.Decode(str, key);

        actual.Should().BeEquivalentTo(expected);
    }
}
