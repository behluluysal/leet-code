namespace LeetCode.Tests;

// https://leetcode.com/problems/number-of-recent-calls
public class RecentCounter
{
    private readonly Queue<int> _counter;
    public RecentCounter()
    {
        _counter = new();
    }

    public int Ping(int t)
    {
        int range = t - 3000;
        _counter.Enqueue(t);
        while(_counter.Peek() < range)
        {
            _counter.Dequeue();
        }
        return _counter.Count;
    }
}