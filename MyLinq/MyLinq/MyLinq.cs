// <copyright file="MyLinq.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace MyLinq;

public static class MyLinq
{
    public static IEnumerable<int> GetPrimes()
    {
        yield return 2;
        yield return 3;

        int number = 5;

        while (true)
        {
            if (IsPrime(number))
            {
                yield return number;
            }

            number += 2;
        }
    }

    public static IEnumerable<T> Take<T>(this IEnumerable<T> seq, int n)
    {
        ArgumentNullException.ThrowIfNull(seq);
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        int counter = 0;
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

    public static IEnumerable<T> Skip<T>(this IEnumerable<T> seq, int n)
    {
        ArgumentNullException.ThrowIfNull(seq);
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        int counter = 0;
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
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}