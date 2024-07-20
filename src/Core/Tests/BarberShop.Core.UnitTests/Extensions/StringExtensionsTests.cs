using BarberShop.Core.Extensions;

namespace BarberShop.Core.UnitTests.Extensions;

public class StringExtensionsTests
{
    #region [ IsNullEmptyOrWhitespaces ]

    [Fact]
    public void IsNullEmptyOrWhitespaces_WithNullString_ReturnsTrue()
    {
        string? sut = null;

        var actual = sut.IsNullOrWhitespaces();

        Assert.True(actual);
    }

    [Fact]
    public void IsNullEmptyOrWhitespaces_WithEmptyString_ReturnsTrue()
    {
        string sut = string.Empty;

        var actual = sut.IsNullOrWhitespaces();

        Assert.True(actual);
    }

    [Fact]
    public void IsNullEmptyOrWhitespaces_WithWhitespacesString_ReturnsTrue()
    {
        string sut = "     ";

        var actual = sut.IsNullOrWhitespaces();

        Assert.True(actual);
    }

    [Fact]
    public void IsNullEmptyOrWhitespaces_ReturnsTrue()
    {
        string sut = "abc";

        var actual = sut.IsNullOrWhitespaces();

        Assert.False(actual);
    }
    #endregion [ IsNullEmptyOrWhitespaces ]
}