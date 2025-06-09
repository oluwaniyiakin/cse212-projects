using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    /// <summary>
    /// Insert a new node in the BST.
    /// </summary>
    public void Insert(int value)
    {
        if (_root == null)
        {
            _root = new Node(value);
        }
        else
        {
            _root.Insert(value);
        }
    }

    /// <summary>
    /// Check if the BST contains a value.
    /// </summary>
    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Enumerator for in-order traversal.
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var values = new List<int>();
        TraverseForward(_root, values);
        foreach (int value in values)
        {
            yield return value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void TraverseForward(Node? node, List<int> values)
    {
        if (node != null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    /// <summary>
    /// Reverse-order traversal (right, root, left).
    /// </summary>
    public IEnumerable Reverse()
    {
        var values = new List<int>();
        TraverseBackward(_root, values);
        foreach (int value in values)
        {
            yield return value;
        }
    }

    private void TraverseBackward(Node? node, List<int> values)
    {
        if (node != null)
        {
            TraverseBackward(node.Right, values);
            values.Add(node.Data);
            TraverseBackward(node.Left, values);
        }
    }

    /// <summary>
    /// Get the height of the tree.
    /// </summary>
    public int GetHeight()
    {
        return _root?.GetHeight() ?? 0;
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
