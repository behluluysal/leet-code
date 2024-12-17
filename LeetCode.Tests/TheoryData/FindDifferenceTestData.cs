namespace LeetCode.Tests.TheoryData;

internal class FindDifferenceTestData : TheoryData<int[], int[], IList<IList<int>>>
{
    public FindDifferenceTestData()
    {
        // Test Case 1: Some overlapping elements
        Add(
            [1, 2, 3],
            [2, 4, 6],
            [
                [1, 3],
                [4, 6]
            ]
        );

        // Test Case 2: Identical arrays
        Add(
            [1, 2, 3, 3],
            [1, 1, 2, 2],
            [
                [3],
                []
            ]
        );
    }
}
