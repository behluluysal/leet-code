﻿using System.Collections;

namespace LeetCode.Tests.TheoryData;

public class IsValidSudokuTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new char[][]
            {
                ['5','3','.','.','7','.','.','.','.'],
                ['6','.','.','1','9','5','.','.','.'],
                ['.','9','8','.','.','.','.','6','.'],
                ['8','.','.','.','6','.','.','.','3'],
                ['4','.','.','8','.','3','.','.','1'],
                ['7','.','.','.','2','.','.','.','6'],
                ['.','6','.','.','.','.','2','8','.'],
                ['.','.','.','4','1','9','.','.','5'],
                ['.','.','.','.','8','.','.','7','9']

            }, true
        };

        yield return new object[]

        {
            new char[][]
            {
                ['1','2','.','.','3','.','.','.','.'],
                ['4','.','.','5','.','.','.','.','.'],
                ['.','9','8','.','.','.','.','.','3'],
                ['5','.','.','.','6','.','.','.','4'],
                ['.','.','.','8','.','3','.','.','5'],
                ['7','.','.','.','2','.','.','.','6'],
                ['.','.','.','.','.','.','2','.','.'],
                ['.','.','.','4','1','9','.','.','8'],
                ['.','.','.','.','8','.','.','7','9']
            }, true
        };

        yield return new object[]
        {
            new char[][]
            {
                ['.','.','.','.','5','.','.','1','.'],
                ['.','4','.','3','.','.','.','.','.'],
                ['.','.','.','.','.','3','.','.','1'],
                ['8','.','.','.','.','.','.','2','.'],
                ['.','.','2','.','7','.','.','.','.'],
                ['.','1','5','.','.','.','.','.','.'],
                ['.','.','.','.','.','2','.','.','.'],
                ['.','2','.','9','.','.','.','.','.'],
                ['.','.','4','.','.','.','.','.','.']
            }, false
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
