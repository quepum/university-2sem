// <copyright file="MyLinq.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace NullElementsChecker;

/// <summary>
/// Represents a node in a linked list.
/// </summary>
/// <typeparam name="T">The type of data stored in the node.</typeparam>
/// <param name="data">The data to be stored in the node.</param>
public class ListNode<T>(T data)
{
    /// <summary>
    /// Gets or sets the data contained in the node.
    /// </summary>
    public T Data { get; set; } = data;

    /// <summary>
    /// Gets or sets the reference to the next node in the linked list.
    /// </summary>
    public ListNode<T>? Next { get; set; }
}