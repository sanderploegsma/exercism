using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    public BinarySearchTree(int value)
    {
        Value = value;
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        Value = values.First();
        foreach (var value in values.Skip(1))
        {
            Add(value);
        }
    }

    public int Value { get; }

    public BinarySearchTree Left { get; private set; }

    public BinarySearchTree Right { get; private set; }

    public BinarySearchTree Add(int value) => 
        value > Value ? AddRight(value) : AddLeft(value);

    private BinarySearchTree AddLeft(int value)
    {
        if (Left != null)
            Left.Add(value);
        else
            Left = new BinarySearchTree(value);
        
        return this;
    }

    private BinarySearchTree AddRight(int value)
    {
        if (Right != null)
            Right.Add(value);
        else
            Right = new BinarySearchTree(value);
        
        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        if (Left != null)
        {
            foreach (var value in Left)
            {
                yield return value;
            }
        }

        yield return Value;

        if (Right != null)
        {
            foreach (var value in Right)
            {
                yield return value;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}