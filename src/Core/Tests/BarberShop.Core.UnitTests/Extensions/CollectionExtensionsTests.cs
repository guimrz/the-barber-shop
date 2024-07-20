using BarberShop.Core.Extensions;

namespace BarberShop.Core.UnitTests.Extensions;

public class CollectionExtensionsTests
{
    [Fact]
    public void IsNullOrEmpty_WithNullCollection_ReturnsTrue()
    {
        IEnumerable<object>? sut = null;

        bool actual = sut.IsNullOrEmpty();

        Assert.True(actual);
    }

    [Fact]
    public void IsNullOrEmpty_WithEmptyCollection_ReturnsTrue()
    {
        IEnumerable<object>? sut = Enumerable.Empty<object>();

        bool actual = sut.IsNullOrEmpty();

        Assert.True(actual);
    }

    [Fact]
    public void IsNullOrEmpty_WithEmptyCollection_ReturnsFalse()
    {
        IEnumerable<object>? sut = new object[1];

        bool actual = sut.IsNullOrEmpty();

        Assert.False(actual);
    }
}