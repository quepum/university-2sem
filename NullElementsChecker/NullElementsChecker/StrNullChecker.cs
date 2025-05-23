// <copyright file="MyLinq.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace NullElementsChecker;

/// <summary>
/// Implementation of <see cref="INullElementsChecker"/> that specifically checks if a string object is null or empty.
/// </summary>
public class StrNullChecker : INullElementsChecker
{
    /// <summary>
    /// Determines whether the specified object is a null or empty string.
    /// </summary>
    /// <param name="obj">The object to check. Expected to be of type <see cref="string"/>.</param>
    /// <returns>
    /// <c>true</c> if the object is a null reference or an empty string
    /// <c>false</c> if the object is a non-null, non-empty string or of a different type.
    /// </returns>
    public bool IsNull(object obj)
    {
        return obj is string s && string.IsNullOrEmpty(s);
    }
}