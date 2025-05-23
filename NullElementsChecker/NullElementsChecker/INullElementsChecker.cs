// <copyright file="MyLinq.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace NullElementsChecker;

/// <summary>
/// Provides functionality to check if an object is null.
/// </summary>
public interface INullElementsChecker
{
    /// <summary>
    /// Determines whether the specified object is null.
    /// </summary>
    /// <param name="o">The object to check.</param>
    /// <returns>
    /// <c>true</c> if the specified object is null; otherwise, <c>false</c>.
    /// </returns>
    bool IsNull(object o);
}