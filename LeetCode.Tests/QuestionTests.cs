using LeetCode.Tests.TheoryData;

namespace LeetCode.Tests;

public class QuestionTests
{
    [Theory]
    [InlineData("abc", "pqr", "apbqcr")]
    [InlineData("ab", "pqrs", "apbqrs")]
    [InlineData("abcd", "pq", "apbqcd")]
    public void MergeStringsAlternately(string word1, string word2, string expectedOutput)
    {
        string output = Questions.MergeAlternately(word1, word2);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData("ABCABC", "ABC", "ABC")]
    [InlineData("ABABAB", "ABAB", "AB")]
    [InlineData("LEET", "CODE", "")]
    public void GcdOfStrings(string str1, string str2, string expectedOutput)
    {
        string output = Questions.GcdOfStrings(str1, str2);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 4, 2, 1, 1, 2 }, 1, new bool[] { true, false, false, false, false })]
    [InlineData(new int[] { 2, 3, 5, 1, 3 }, 3, new bool[] { true, true, true, false, true })]
    [InlineData(new int[] { 12, 1, 12 }, 10, new bool[] { true, false, true })]
    public void KidsWithCandies(int[] candies, int extraCandies, IList<bool> expectedOutput)
    {
        IList<bool> output = Questions.KidsWithCandies(candies, extraCandies);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 1, 0, 0, 0, 1 }, 1, true)]
    [InlineData(new int[] { 1, 0, 0, 0, 1 }, 2, false)]
    [InlineData(new int[] { 1, 0, 0, 0, 1, 0, 0 }, 2, true)]
    [InlineData(new int[] { 0 }, 1, true)]
    [InlineData(new int[] { 0 }, 2, false)]
    [InlineData(new int[] { 0, 1 }, 1, false)]
    [InlineData(new int[] { 0, 0 }, 1, true)]
    [InlineData(new int[] { 0, 0 }, 2, false)]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 1, 0, 0 }, 0, true)]
    public void CanPlaceFlowers(int[] flowerbed, int n, bool expectedOutput)
    {
        bool output = Questions.CanPlaceFlowers(flowerbed, n);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 1, 0, 0, 0, 1 }, 1, true)]
    [InlineData(new int[] { 1, 0, 0, 0, 1 }, 2, false)]
    [InlineData(new int[] { 1, 0, 0, 0, 1, 0, 0 }, 2, true)]
    [InlineData(new int[] { 0 }, 1, true)]
    [InlineData(new int[] { 0 }, 2, false)]
    [InlineData(new int[] { 0, 1 }, 1, false)]
    [InlineData(new int[] { 0, 0 }, 1, true)]
    [InlineData(new int[] { 0, 0 }, 2, false)]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 1, 0, 0 }, 0, true)]
    public void CanPlaceFlowers2(int[] flowerbed, int n, bool expectedOutput)
    {
        bool output = Questions.CanPlaceFlowers2(flowerbed, n);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData("IceCreAm", "AceCreIm")]
    [InlineData("leetcode", "leotcede")]
    public void ReverseVowels(string s, string expectedOutput)
    {
        string output = Questions.ReverseVowels(s);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData("the sky is blue", "blue is sky the")]
    [InlineData("  hello world  ", "world hello")]
    public void ReverseWords(string s, string expectedOutput)
    {
        string output = Questions.ReverseWords(s);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
    [InlineData(new int[] { -1, 1, 0, -3, 3 }, new int[] { 0, 0, 9, 0, 0 })]
    public void ProductExceptSelf(int[] nums, int[] expectedOutput)
    {
        int[] output = Questions.ProductExceptSelf(nums);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, true)]
    [InlineData(new int[] { 5, 4, 3, 2, 1 }, false)]
    public void IncreasingTriplet(int[] nums, bool expectedOutput)
    {
        bool output = Questions.IncreasingTriplet(nums);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new char[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c' }, 6)]
    [InlineData(new char[] { 'a' }, 1)]
    [InlineData(new char[] { 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b' }, 4)]
    public void Compress(char[] chars, int expectedOutput)
    {
        int output = Questions.Compress(chars);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 })]
    public void MoveZeroes(int[] nums, int[] expectedOutput)
    {
        int[] output = Questions.MoveZeroes(nums);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData("abc", "ahbgdc", true)]
    [InlineData("axc", "ahbgdc", false)]
    [InlineData("", "ahbgdc", true)]
    [InlineData("abc", "", false)]
    public void IsSubsequence(string s, string t, bool expectedOutput)
    {
        bool output = Questions.IsSubsequence(s, t);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
    [InlineData(new int[] { 1, 1 }, 1)]
    public void MaxArea(int[] height, int expectedOutput)
    {
        int output = Questions.MaxArea(height);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, 5, 2)]
    [InlineData(new int[] { 3, 1, 3, 4, 3 }, 6, 1)]
    [InlineData(new int[] { 2, 5, 4, 4, 1, 3, 4, 4, 1, 4, 4, 1, 2, 1, 2, 2, 3, 2, 4, 2 }, 3, 4)]
    public void MaxOperations(int[] nums, int k, int expectedOutput)
    {
        int output = Questions.MaxOperations(nums, k);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 1, 12, -5, -6, 50, 3 }, 4, 12.75)]
    [InlineData(new int[] { 5 }, 1, 5)]
    public void FindMaxAverage(int[] nums, int k, double expectedOutput)
    {
        double output = Questions.FindMaxAverage(nums, k);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData("abciiidef", 3, 3)]
    [InlineData("aeiou", 2, 2)]
    [InlineData("leetcode", 3, 2)]
    [InlineData("weallloveyou", 7, 4)]
    public void MaxVowels(string s, int k, int expectedOutput)
    {
        int output = Questions.MaxVowels(s, k);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, 2, 6)]
    [InlineData(new int[] { 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1 }, 3, 10)]
    [InlineData(new int[] { 0, 0, 0 }, 0, 0)]
    [InlineData(new int[] { 1, 1, 1, 0, 0, 0, 0 }, 1, 4)]
    [InlineData(new int[] { 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 }, 1, 5)]
    public void LongestOnes(int[] nums, int k, int expectedOutput)
    {
        int output = Questions.LongestOnes(nums, k);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 1, 1, 0, 1 }, 3)]
    [InlineData(new int[] { 0, 1, 1, 1, 0, 1, 1, 0, 1 }, 5)]
    [InlineData(new int[] { 1, 1, 1 }, 2)]
    [InlineData(new int[] { 0, 0, 0 }, 0)]
    public void LongestSubarray(int[] nums, int expectedOutput)
    {
        int output = Questions.LongestSubarray(nums);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { -5, 1, 5, 0, -7 }, 1)]
    [InlineData(new int[] { -4, -3, -2, -1, 4, 3, 2 }, 0)]
    public void LargestAltitude(int[] nums, int expectedOutput)
    {
        int output = Questions.LargestAltitude(nums);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 1, 7, 3, 6, 5, 6 }, 3)]
    [InlineData(new int[] { 1, 2, 3 }, -1)]
    public void PivotIndex(int[] nums, int expectedOutput)
    {
        int output = Questions.PivotIndex(nums);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [ClassData(typeof(FindDifferenceTestData))]
    public void FindDifference(int[] nums1, int[] nums2, IList<IList<int>> expectedOutput)
    {
        var output = Questions.FindDifference(nums1, nums2);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 2, 1, 1, 3 }, true)]
    [InlineData(new int[] { 1, 2 }, false)]
    [InlineData(new int[] { -4, 3, 3 }, true)]
    [InlineData(new int[] { 2, 2 }, true)]
    [InlineData(new int[] { 3, 5, -2, -3, -6, -6 }, false)]
    public void UniqueOccurrences(int[] nums, bool expectedOutput)
    {
        bool output = Questions.UniqueOccurrences(nums);
        Assert.Equal(expectedOutput, output);
    }

}
