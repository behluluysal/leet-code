using LeetCode.Tests.TheoryData;

namespace LeetCode.Tests;

public class Questions_RoadMap_Tests
{
    #region [ Array & Hashing ]

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

    #endregion

    #region [ Stack ]

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

    [Theory]
    [InlineData(3, new string[] { "((()))", "(()())", "(())()", "()(())", "()()()" })]
    public void GenerateParenthesis(int n, IList<string> expectedOutput)
    {
        IList<string> output = Questions_RoadMap.GenerateParenthesis(n);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(12, new int[] { 10, 8, 0, 5, 3 }, new int[] { 2, 4, 1, 1, 3 }, 3)]
    public void CarFleet(int target, int[] position, int[] speed, int expectedOutput)
    {
        int output = Questions_RoadMap.CarFleet(target, position, speed);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 2, 1, 5, 6, 2, 3 }, 10)]
    [InlineData(new int[] { 2, 4 }, 4)]
    [InlineData(new int[] { 3, 6, 5, 7, 4, 8, 1, 0 }, 20)]
    public void LargestRectangleArea(int[] target, int expectedOutput)
    {
        int output = Questions_RoadMap.LargestRectangleArea(target);
        Assert.Equal(expectedOutput, output);
    }

    #endregion

    #region [ Two Pointer ]

    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("..A man, a plan, a canal: Panama...........", true)]
    [InlineData("race a car", false)]
    [InlineData(" ", true)]
    public void IsPalindrome(string s, bool expectedOutput)
    {
        bool output = Questions_RoadMap.IsPalindrome(s);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 1, 2 })]
    [InlineData(new int[] { 2, 3, 4 }, 6, new int[] { 1, 3 })]
    [InlineData(new int[] { -1, 0 }, -1, new int[] { 1, 2 })]
    public void TwoSumII(int[] numbers, int target, int[] expectedOutput)
    {
        int[] output = Questions_RoadMap.TwoSumII(numbers, target);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [ClassData(typeof(ThreeSumTestData))]
    public void ThreeSum(int[] numbers, int[][] expectedOutput)
    {
        IList<IList<int>> output = Questions_RoadMap.ThreeSum(numbers);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
    [InlineData(new int[] { 1, 1 }, 1)]
    public void MaxArea(int[] height, int expectedOutput)
    {
        int output = Questions_RoadMap.MaxArea(height);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 0, 2, 0, 3, 1, 0, 1, 3, 2, 1 }, 9)]
    [InlineData(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
    public void Trap(int[] height, int expectedOutput)
    {
        int output = Questions_RoadMap.Trap(height);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 0, 2, 0, 3, 1, 0, 1, 3, 2, 1 }, 9)]
    [InlineData(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
    public void TrapII(int[] height, int expectedOutput)
    {
        int output = Questions_RoadMap.TrapII(height);
        Assert.Equal(expectedOutput, output);
    }

    #endregion

    #region [ Sliding Window ]

    [Theory]
    [InlineData(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
    [InlineData(new int[] { 7, 6, 4, 3, 1 }, 0)]
    public void MaxProfit(int[] height, int expectedOutput)
    {
        int output = Questions_RoadMap.MaxProfit(height);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    [InlineData(" ", 1)]
    [InlineData("au", 2)]
    public void LengthOfLongestSubstring(string s, int expectedOutput)
    {
        int output = Questions_RoadMap.LengthOfLongestSubstring(s);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData("AABABBBA", 1, 5)]
    public void CharacterReplacement(string s, int k, int expectedOutput)
    {
        int output = Questions_RoadMap.CharacterReplacement(s, k);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData("ab", "eibdbaooo", true)]
    [InlineData("ab", "eidbaooo", true)]
    [InlineData("ab", "eidboaoo", false)]
    [InlineData("abc", "lecabee", true)]
    [InlineData("abc", "lecaabee", false)]
    [InlineData("adc", "dcda", true)]
    public void CheckInclusion(string s1, string s2, bool expectedOutput)
    {
        bool output = Questions_RoadMap.CheckInclusion(s1, s2);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData("DDADDBCA", "ABC", "BCA")]
    [InlineData("ADOBECODEBANC", "ABC", "BANC")]
    [InlineData("a", "a", "a")]
    [InlineData("a", "aa", "")]
    public void MinWindow(string s, string t, string expectedOutput)
    {
        string output = Questions_RoadMap.MinWindow(s, t);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3, new int[] { 3, 3, 5, 5, 6, 7 })]
    [InlineData(new int[] { 1, 2, 1, 0, 4, 2, 6 }, 3, new int[] { 2, 2, 4, 4, 6 })]
    [InlineData(new int[] { 1 }, 1, new int[] { 1 })]
    public void MaxSlidingWindow(int[] nums, int k, int[] expectedOutput)
    {
        int[] output = Questions_RoadMap.MaxSlidingWindow(nums, k);
        Assert.Equal(expectedOutput, output);
    }

    #endregion

    #region [ Linked List ]

    [Fact]
    public void MergeTwoLists()
    {
        ListNode list1 = new(1, new(2, new(4)));
        ListNode list2 = new(1, new(3, new(5)));
        ListNode result = Questions_RoadMap.MergeTwoLists(list1, list2);
        List<int> output = [];
        while (result != null)
        {
            output.Add(result.val);
            result = result.next;
        }
        Assert.Equal([1, 1, 2, 3, 4, 5], [.. output]);
    }

    #endregion
}
