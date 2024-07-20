namespace BarberShop.Core.Extensions;

/// <summary>
/// Defines extensions for <see cref="Object"/>.
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Validates if the specified object is a null reference.
    /// </summary>
    /// <param name="value">The object to be validated.</param>
    /// <returns>True if null, otherwise returns false.</returns>
    public static bool IsNull([NotNullWhen(false)] this object? value)
    {
        return value is null;
    }
}
