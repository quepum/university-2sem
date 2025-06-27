// <copyright file="MyLinq.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace NullElementsChecker;

/// <summary>
/// Implementation of <see cref="INullElementsChecker"/> that checks if an integer value is equal to zero
/// (treating 0 as a "null" equivalent).
/// </summary>
public class IntNullChecker : INullElementsChecker
{
    /// <summary>
    /// Determines whether the specified object is a zero integer value.
    /// </summary>
    /// <param name="obj">The object to check. Expected to be of type <see cref="int"/>.</param>
    /// <returns>
    /// <c>true</c> if the object is an integer with value 0;
    /// <c>false</c> if the object is a non-zero integer, null, or of a different type.
    /// </returns>
    public bool IsNull(object obj)
    {
        return obj is 0;
    }
}