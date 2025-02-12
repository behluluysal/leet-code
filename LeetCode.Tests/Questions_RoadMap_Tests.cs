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

    [Theory]
    [InlineData(new int[] { 1, 1, 1, 2, 2, 3 }, 2, new int[] { 1, 2 })]
    [InlineData(new int[] { 1 }, 1, new int[] { 1 })]
    [InlineData(new int[] { 1, 2 }, 2, new int[] { 1, 2 })]
    public void TopKFrequent(int[] nums, int k, int[] expectedOutput)
    {
        int[] output = Questions_RoadMap.TopKFrequent(nums, k);
        Assert.Equal(expectedOutput, output);
    }

    [Fact]
    public void EncodeDecodeString()
    {
        string[] strs = ["neet", "code", "love", "you"];
        string output = Questions_RoadMap.Encode(strs);
        List<string> result = Questions_RoadMap.Decode(output);
        Assert.Equal(strs, result);
    }

    [Theory]
    [InlineData(new int[] { 100, 4, 200, 1, 3, 2 }, 4)]
    [InlineData(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 9)]
    [InlineData(new int[] { }, 0)]
    public void LongestConsecutive(int[] nums, int expectedOutput)
    {
        int output = Questions_RoadMap.LongestConsecutive(nums);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [ClassData(typeof(IsValidSudokuTestData))]
    public void IsValidSudoku(char[][] board, bool expectedOutput)
    {
        bool output = Questions_RoadMap.IsValidSudoku(board);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    [InlineData("([])", true)]
    public void IsValidParantheses(string s, bool expectedOutput)
    {
        bool output = Questions_RoadMap.IsValidParantheses(s);
        Assert.Equal(expectedOutput, output);
    }

    [Fact]
    public void MinStack()
    {
        MinStack obj = new();
        obj.Push(-2);
        obj.Push(1);
        obj.Push(-3);
        int val = obj.GetMin();
        Assert.Equal(-3, val);
        obj.Pop();
        val = obj.GetMin();
        Assert.Equal(-2, val);
    }

    [Theory]
    [InlineData(new string[] { "2", "1", "+", "3", "*" }, 9)]
    [InlineData(new string[] { "4", "13", "5", "/", "+" }, 6)]
    [InlineData(new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }, 22)]
    public void EvalRPN(string[] tokens, int expectedOutput)
    {
        int output = Questions_RoadMap.EvalRPN(tokens);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 30, 40, 50, 60 }, new int[] { 1, 1, 1, 0 })]
    [InlineData(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 }, new int[] { 1, 1, 4, 2, 1, 1, 0, 0 })]
    public void DailyTemperatures(int[] temperatures, int[] expectedOutput)
    {
        int[] output = Questions_RoadMap.DailyTemperatures(temperatures);
        Assert.Equal(expectedOutput, output);
    }
}
