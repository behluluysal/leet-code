using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tests.TheoryData;

internal class SearchMatrixTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new int[][]
            {
                [1,2,4,8],
                [10,11,12,13],
                [14,20,30,40]

            },
            10, true
        };

        yield return new object[]
        {
            new int[][]
            {
                [1,2,4,8],
                [10,11,12,13],
                [14,20,30,40]

            },
            15, false
        };
        
        yield return new object[]
        {
            new int[][]
            {
                [1,3,5,7],
                [10,11,16,20],
                [23,30,34,60]

            },
            3, true
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
