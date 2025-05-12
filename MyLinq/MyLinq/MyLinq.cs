// <copyright file="MyLinq.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace MyLinq;

/// <summary>
/// Provides extension methods for working with sequences.
/// </summary>
public static class MyLinq
{
    /// <summary>
    /// Returns an infinite sequence of prime numbers.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> of prime numbers.</returns>
    public static IEnumerable<int> GetPrimes()
    {
        yield return 2;
        yield return 3;

        var number = 5;

        while (true)
        {
            if (IsPrime(number))
            {
                yield return number;
            }

            number += 2;
        }
    }

    /// <summary>
    /// Returns a specified number of contiguous elements from the start of a sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="seq"/>.</typeparam>
    /// <param name="seq">The sequence to return elements from.</param>
    /// <param name="n">The number of elements to return.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> that contains the specified number of elements from the start of the input sequence.</returns>
    public static IEnumerable<T> Take<T>(this IEnumerable<T> seq, int n)
    {
        ArgumentNullException.ThrowIfNull(seq);
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        var counter = 0;
        foreach (var elem in seq)
        {
            if (counter >= n)
            {
                break;
            }

            yield return elem;
            counter++;
        }
    }

    /// <summary>
    /// Skips a specified number of elements in a sequence and then returns the remaining elements.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="seq"/>.</typeparam>
    /// <param name="seq">The sequence to return elements from.</param>
    /// <param name="n">The number of elements to skip before returning the remaining elements.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> that contains the elements that occur after the specified index in the input sequence.</returns>
    public static IEnumerable<T> Skip<T>(this IEnumerable<T> seq, int n)
    {
        ArgumentNullException.ThrowIfNull(seq);
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        var counter = 0;
        foreach (var elem in seq)
        {
            if (counter > n)
            {
                yield return elem;
            }

            counter++;
        }
    }

    private static bool IsPrime(int number)
    {
        for (var i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}