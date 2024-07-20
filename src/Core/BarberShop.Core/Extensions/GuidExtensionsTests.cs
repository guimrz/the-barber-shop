namespace BarberShop.Core.Extensions;

/// <summary>
/// Defines extensions for <see cref="Guid"/>
/// </summary>
public static class GuidExtensionsTests
{
    /// <summary>
    /// Validates if the specified guid is a null reference or empty.
    /// </summary>
    /// <param name="value">The value to be validated.</param>
    /// <returns>True if is null or empty, otherwise returns false.</returns>
    public static bool IsNullOrEmpty(this Guid? value)
    {
        return value.IsNull() || value == Guid.Empty;
    }

    /// <summary>
    /// Validates if the specified guid is empty.
    /// </summary>
    /// <param name="value">The value to be validated.</param>
    /// <returns>True if is empty, otherwise returns false.</returns>
    public static bool IsEmpty(this Guid value)
    {
        return value == Guid.Empty;
    }
}