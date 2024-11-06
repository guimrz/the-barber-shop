using System.Reflection;

namespace BarberShop.Core.Utilites
{
    /// <summary>
    /// Defines utility methods for reflection.
    /// </summary>
    public static class ReflectionUtils
    {
        public static void SetRuntimePropertyValue(object obj, string propertyName, object value)
        {
            var property = obj.GetType().GetRuntimeProperty(propertyName);

            var method = property?.GetSetMethod(nonPublic: true);

            method?.Invoke(obj, [ value ]);
        }
    }
}
