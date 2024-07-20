using BarberShop.Core.Extensions;

namespace BarberShop.Core.UnitTests.Extensions;

public class ObjectExtensionsTests
{
    [Fact]
    public void IsNull_ReturnsTrue()
    {
        object? value = null;

        bool actual = value.IsNull();

        Assert.True(actual);
    }

    [Fact]
    public void IsNull_ReturnsFalse()
    {
        object? value = new();

        bool actual = value.IsNull();

        Assert.False(actual);
    }
}