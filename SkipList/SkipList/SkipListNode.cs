// <copyright file="SkipListNode.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace SkipList;

public class SkipListNode<T>(T key, int level)
{
    public T Key { get; private set; } = key;

    public SkipListNode<T>[] Forward { get; private set; } = new SkipListNode<T>[level + 1];
}