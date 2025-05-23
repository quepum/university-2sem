// <copyright file="MyLinq.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace NullElementsChecker;

/// <summary>
/// Provides utility methods for counting null elements in collections.
/// </summary>
public static class NullElementsCounter
{
    /// <summary>
    /// Counts the number of elements in the list that are considered null by the specified checker.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list to check for null elements.</param>
    /// <param name="nullChecker">The checker that determines what constitutes a null element.</param>
    /// <returns>The number of elements in the list that are considered null.</returns>
    public static int CountNulls<T>(MyList<T> list, INullElementsChecker nullChecker)
    {
        ArgumentNullException.ThrowIfNull(list);

        ArgumentNullException.ThrowIfNull(nullChecker);

        return list.Count(item => nullChecker.IsNull(item!));
    }
}