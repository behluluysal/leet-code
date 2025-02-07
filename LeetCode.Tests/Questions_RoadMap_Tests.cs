using LeetCode.Tests.TheoryData;

namespace LeetCode.Tests;

public class Questions_RoadMap_Tests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 1 }, true)]
    [InlineData(new int[] { 1, 2, 3, 4 }, false)]
    [InlineData(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, true)]
    public void ContainsDuplicate(int[] nums, bool expectedOutput)
    {
        bool output = Questions_RoadMap.ContainsDuplicate(nums);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData("anagram", "nagaram", true)]
    [InlineData("rat", "car", false)]
    public void IsAnagram(string word1, string word2, bool expectedOutput)
    {
        bool output = Questions_RoadMap.IsAnagram(word1, word2);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    public void TwoSum(int[] nums, int target, int[] expectedOutput)
    {
        int[] output = Questions_RoadMap.TwoSum(nums, target);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [ClassData(typeof(GroupAnagramsTestData))]
    public void GroupAnagrams(string[] strs, List<List<string>> expectedOutput)
    {
        List<List<string>> output = Questions_RoadMap.GroupAnagrams(strs);
        Assert.Equal(expectedOutput, output);
    }
}
