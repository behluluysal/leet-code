using System.Collections;

namespace LeetCode.Tests.TheoryData;

internal class GroupAnagramsTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new string[] { "eat", "tea", "tan", "ate", "nat", "bat" },
            new List<List<string>>
            {
                new() { "eat", "tea", "ate" },
                new() { "tan", "nat" },
                new() { "bat" }
            }
        };

        yield return new object[]
        {
            new string[] { "act","pots","tops","cat","stop","hat" },
            new List<List<string>>
            {
                new() { "act", "cat" },
                new() { "pots", "tops", "stop" },
                new() { "hat" }
            }
        };

        yield return new object[]
        {
            new string[] { "x" },
            new List<List<string>>
            {
                new() { "x", }
            }
        };

        yield return new object[]
        {
            new string[] { "" },
            new List<List<string>>
            {
                new() { "", }
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
