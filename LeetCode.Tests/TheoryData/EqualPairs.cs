namespace LeetCode.Tests.TheoryData;

internal class EqualPairs : TheoryData<int[][], int>
{
    public EqualPairs()
    {
        Add(
            [
                [3, 2, 1], 
                [1, 7, 6], 
                [2, 7, 7]
            ], 1
        );

        Add(
            [
                [3, 1, 2, 2], 
                [1, 4, 4, 5], 
                [2, 4, 2, 2], 
                [2, 4, 2, 2]
            ], 3
        );
    }
}
