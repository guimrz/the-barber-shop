namespace BarberShop.Core.Extensions;

/// <summary>
/// Defines extensions for <see cref="String"/>.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Validates if the specified string is a null reference, an empty string or whitespaces only.
    /// </summary>
    /// <param name="value">The string to be validated.</param>
    /// <returns>True if is null, empty or whitespaces, otherwise returns false.</returns>
    public static bool IsNullOrWhitespaces([NotNullWhen(false)] this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }
}