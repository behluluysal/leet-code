﻿using System.Text;

namespace LeetCode.Tests;

public static class Questions
{
    // https://leetcode.com/problems/merge-strings-alternately
    public static string MergeAlternately(string word1, string word2)
    {
        int maxLength = Math.Max(word1.Length, word2.Length);
        StringBuilder merged = new();
        for (int i = 0; i < maxLength; i++)
        {
            if (i < word1.Length)
            {
                merged = merged.Append(word1[i]);
            }
            if (i < word2.Length)
            {
                merged = merged.Append(word2[i]);
            }
        }
        return merged.ToString();
    }

    // https://leetcode.com/problems/greatest-common-divisor-of-strings
    public static string GcdOfStrings(string str1, string str2)
    {
        if (str1 + str2 != str2 + str1)
        {
            return string.Empty;
        }

        int gcdLength = Gcd(str1.Length, str2.Length);

        return str1[..gcdLength];
    }

    // https://leetcode.com/problems/kids-with-the-greatest-number-of-candie
    public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        int largest = candies[0];
        foreach (var candy in candies)
        {
            if (candy > largest)
            {
                largest = candy;
            }
        }
        List<bool> result = [];
        foreach (int candie in candies)
        {
            result.Add(candie + extraCandies >= largest);
        }
        return result;
    }

    // https://leetcode.com/problems/can-place-flowers
    public static bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        int lenght = flowerbed.Length;
        int previous = 0;
        int next = 0;

        for (int i = 0; i < lenght; i++)
        {
            if (i != flowerbed.Length - 1)
            {
                next = flowerbed[i + 1];
            }
            if (flowerbed[i] == 0 && previous == 0 && next == 0)
            {
                n--;
                flowerbed[i] = 1;
            }

            previous = flowerbed[i];
            if (n <= 0)
            {
                break;
            }
        }
        return n <= 0;
    }

    // https://leetcode.com/problems/can-place-flowers
    public static bool CanPlaceFlowers2(int[] flowerbed, int n)
    {
        if (n == 0)
        {
            return true;
        }
        flowerbed = [0, .. flowerbed, 0];
        for (int i = 1; i < flowerbed.Length - 1; i++)
        {
            if (flowerbed[i] == 0 && flowerbed[i + 1] == 0 && flowerbed[i - 1] == 0)
            {
                flowerbed[i] = 1;
                n--;
            }
            if (n == 0)
            {
                return true;
            }
        }
        return false;
    }

    // https://leetcode.com/problems/reverse-vowels-of-a-string
    public static string ReverseVowels(string s)
    {
        HashSet<char> vowels = ['a', 'e', 'o', 'u', 'i', 'A', 'E', 'O', 'U', 'I'];
        Stack<char> vowelsToReplace = new();
        StringBuilder result = new(s);

        for (int i = 0; i < s.Length; i++)
        {
            if (vowels.Contains(s[i]))
            {
                vowelsToReplace.Push(s[i]);
            }
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (vowels.Contains(s[i]))
            {
                result[i] = vowelsToReplace.Pop();
            }
        }
        return result.ToString();
    }

    // https://leetcode.com/problems/reverse-words-in-a-string
    public static string ReverseWords(string s)
    {
        // Ensure the string ends with space
        s += " ";

        Stack<string> words = new();
        int wordStartIndex = -1;
        for (int i = 0; i < s.Length; i++)
        {
            if (!s[i].Equals(' ') && wordStartIndex == -1)
            {
                wordStartIndex = i;
            }
            else if (wordStartIndex != -1 && (s[i].Equals(' ') || i == s.Length - 1))
            {
                words.Push(s[wordStartIndex..i]);
                wordStartIndex = -1;
            }
        }
        StringBuilder stringBuilder = new();
        int totalWords = words.Count;
        for (int i = 0; i < totalWords; i++)
        {
            stringBuilder.Append(words.Pop());
            if (i != totalWords - 1)
            {
                stringBuilder.Append(' ');
            }
        }

        return stringBuilder.ToString();
    }

    // https://leetcode.com/problems/product-of-array-except-self
    public static int[] ProductExceptSelf(int[] nums)
    {
        int[] leftItems = new int[nums.Length];

        leftItems[0] = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            leftItems[i] = nums[i - 1] * leftItems[i - 1];
        }

        int suffix = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            leftItems[i] = suffix * leftItems[i];
            suffix = suffix * nums[i];
        }

        return leftItems;
    }

    // https://leetcode.com/problems/increasing-triplet-subsequence
    public static bool IncreasingTriplet(int[] nums)
    {
        if (nums.Length < 3)
        {
            return false;
        }

        int first = int.MaxValue;
        int second = int.MaxValue;

        foreach (var num in nums)
        {
            if (num <= first)
            {
                first = num;
            }
            else if (num <= second)
            {
                second = num;
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    // https://leetcode.com/problems/string-compression/description/
    public static int Compress(char[] chars)
    {
        int newLenght = 0;
        for (int i = 0; i < chars.Length;)
        {
            char currentChar = chars[i];
            int count = 0;

            while (i < chars.Length && chars[i] == currentChar)
            {
                count++;
                i++;
            }

            chars[newLenght++] = currentChar;
            if (count > 1)
            {
                foreach (char countText in count.ToString())
                {
                    chars[newLenght++] = countText;
                }
            }
        }
        return newLenght;
    }

    // https://leetcode.com/problems/move-zeroes/
    public static int[] MoveZeroes(int[] nums)
    {
        int nonZeroIndex = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                (nums[nonZeroIndex], nums[i]) = (nums[i], nums[nonZeroIndex]);
                nonZeroIndex++;
            }
        }
        return nums;
    }

    // https://leetcode.com/problems/is-subsequence
    public static bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0)
        {
            return true;
        }

        int j = 0;
        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] == s[j])
            {
                j++;
            }
            if (j == s.Length)
            {
                return true;
            }
        }
        return false;
    }

    // https://leetcode.com/problems/container-with-most-water
    public static int MaxArea(int[] height)
    {
        int max = 0;
        int left = 0;
        int right = height.Length - 1;

        while (left < right)
        {
            int maxHeight = Math.Min(height[left], height[right]);
            int width = right - left;
            max = Math.Max(max, maxHeight * width);

            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return max;
    }

    // https://leetcode.com/problems/max-number-of-k-sum-pairs
    public static int MaxOperations(int[] nums, int k)
    {
        var countMap = new Dictionary<int, int>();
        int operations = 0;

        foreach (var num in nums)
        {
            int complement = k - num;
            if(complement <= 0)
            {
                continue;
            }

            if (countMap.TryGetValue(complement, out int value) && value > 0)
            {
                operations++;
                countMap[complement] = --value;
                if (countMap[complement] == 0)
                {
                    countMap.Remove(complement);
                }
            }
            else
            {
                if (!countMap.ContainsKey(num))
                {
                    countMap[num] = 0;
                }
                countMap[num]++;
            }
        }

        return operations;
    }

    #region [ Helpers ]

    private static int Gcd(int a, int b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }

    #endregion
}