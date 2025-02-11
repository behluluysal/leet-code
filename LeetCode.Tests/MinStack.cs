namespace LeetCode.Tests;

// https://leetcode.com/problems/min-stack
public class MinStack
{

    private readonly Stack<int> _stack;
    private readonly Stack<int> _minStack;
    int _lastMin = int.MaxValue;

    public MinStack()
    {
        _stack = [];
        _minStack = [];
    }

    public void Push(int val)
    {
        _stack.Push(val);

        _lastMin = val < _lastMin ? val : _lastMin;
        _minStack.Push(_lastMin);
    }

    public void Pop()
    {
        _stack.Pop();
        int val = _minStack.Pop();
        if (val == _lastMin) _lastMin = _minStack.Peek();
        if (_minStack.Count == 0) _lastMin = int.MaxValue;
    }

    public int Top()
    {
        return _stack.Peek();
    }

    public int GetMin()
    {
        return _lastMin;
    }
}