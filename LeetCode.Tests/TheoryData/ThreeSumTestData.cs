using System.Collections;

namespace LeetCode.Tests.TheoryData;

internal class ThreeSumTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new int[] { -1,0,1,2,-1,-4 },
            new int[][]
            {
                [-1,-1,2],
                [-1,0,1],
            }
        };

        yield return new object[]
        {
            new int[] { 0,0,0,0 },
            new int[][]
            {
                [0,0,0]
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
