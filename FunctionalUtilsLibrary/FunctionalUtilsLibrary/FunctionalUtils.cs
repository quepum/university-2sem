// <copyright file="FunctionalUtils.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FunctionalUtilsLibrary;

/// <summary>
/// Contains 3 generic functions.
/// </summary>
public class FunctionalUtils
{
    /// <summary>
    /// Transforms each element of the collection using the specified function.
    /// </summary>
    /// <typeparam name="T">The type of the input collection items.</typeparam>
    /// <typeparam name="TOut">The type of the output collection items.</typeparam>
    /// <param name="collection">The input collection of items.</param>
    /// <param name="transformation">Element transformation function.</param>
    /// <returns>A new collection containing converted items.</returns>
    public static List<TOut> Map<T, TOut>(IEnumerable<T> collection, Func<T, TOut> transformation)
    {
        if (collection == null || transformation == null)
        {
            throw new ArgumentNullException(nameof(collection), "Input data is null.");
        }

        var result = new List<TOut>();
        foreach (var item in collection)
        {
            result.Add(transformation(item));
        }

        return result;
    }

    /// <summary>
    /// Filters the elements of the collection, leaving only those that satisfy the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the collection items.</typeparam>
    /// <param name="collection">The input collection of items.</param>
    /// <param name="transformation">The filtering condition.</param>
    /// <returns>A new collection containing filtered items.</returns>
    public static List<T> Filter<T>(IEnumerable<T> collection, Func<T, bool> transformation)
    {
        if (collection == null || transformation == null)
        {
            throw new ArgumentNullException(nameof(collection), "Input data is null.");
        }

        var result = new List<T>();
        foreach (var item in collection)
        {
            if (transformation(item))
            {
                result.Add(item);
            }
        }

        return result;
    }

    /// <summary>
    /// Collapses the collection into a single value using an accumulator.
    /// </summary>
    /// <typeparam name="T">The type of the collection items.</typeparam>
    /// <typeparam name="TOut">The type of the initial and result values.</typeparam>
    /// <param name="collection">The input collection of items.</param>
    /// <param name="initialValue">The initial value of the accumulator.</param>
    /// <param name="transformation">Battery function.</param>
    /// <returns>The resulting value after processing the entire collection.</returns>
    public static TOut Fold<T, TOut>(IEnumerable<T> collection, TOut initialValue, Func<TOut, T, TOut> transformation)
    {
        if (collection == null || transformation == null)
        {
            throw new ArgumentNullException(nameof(collection), "Input data is null.");
        }

        var result = initialValue;
        foreach (var item in collection)
        {
            result = transformation(result, item);
        }

        return result;
    }
}