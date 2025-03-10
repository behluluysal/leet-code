using BenchmarkDotNet.Attributes;

namespace LeetCode.Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class FirstLetterFinder
{
    private readonly char[] input;
    public FirstLetterFinder()
    {
        string sample = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwx";
        input = sample.ToCharArray();
    }

    [Benchmark]
    public char UsingList()
    {
        List<char> seen = [];
        foreach (char c in input)
        {
            if (seen.Contains(c))
                return c;
            seen.Add(c);
        }
        return '\0';
    }

    [Benchmark]
    public char UsingHashMap()
    {
        Dictionary<char, bool> seen = [];
        foreach (char c in input)
        {
            if (seen.ContainsKey(c))
                return c;
            seen[c] = true;
        }
        return '\0';
    }

    [Benchmark]
    public char UsingHashSet()
    {
        HashSet<char> seen = [];
        foreach (char c in input)
        {
            if (seen.Contains(c))
                return c;
            seen.Add(c);
        }
        return '\0';
    }
}