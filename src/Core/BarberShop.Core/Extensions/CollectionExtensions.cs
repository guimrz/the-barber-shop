namespace BarberShop.Core.Extensions;

/// <summary>
/// Defines extensions for <see cref="IEnumerable{T}"/>
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Validates if the specified collection is a null reference or an empty collection.
    /// </summary>
    /// <typeparam name="T">The collection item type.</typeparam>
    /// <param name="value">the collection to be validated.</param>
    /// <returns>True if null or empty, otherwise returns false.</returns>
    public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? value)
    {
        return value.IsNull() || !value.Any();
    }
}