using BarberShop.Core.Extensions;

namespace BarberShop.Core.UnitTests.Extensions
{
    public class GuidExtensions
    {
        [Fact]
        public void IsNullOrEmpty_WithEmptyGuid_ReturnsTrue()
        {
            Guid? value = Guid.Empty;

            var actual = value.IsNullOrEmpty();

            Assert.True(actual);
        }

        [Fact]
        public void IsNullOrEmpty_WithNull_ReturnsTrue()
        {
            Guid? value = null;

            var actual = value.IsNullOrEmpty();

            Assert.True(actual);
        }

        [Fact]
        public void IsNullOrEmpty_ReturnsFalse()
        {
            Guid? value = Guid.NewGuid();

            var actual = value.IsNullOrEmpty();

            Assert.False(actual);
        }

        [Fact]
        public void IsEmpty_WithEmptyGuid_ReturnsTrue()
        {
            Guid value = Guid.Empty;

            var actual = value.IsEmpty();

            Assert.True(actual);
        }

        [Fact]
        public void IsEmpty_ReturnsFalse()
        {
            Guid value = Guid.NewGuid();

            var actual = value.IsEmpty();

            Assert.False(actual);
        }
    }
}