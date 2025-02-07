namespace LeetCode.Tests;

/// <summary>
/// The questions in this class are from neetcode roadmap
/// </summary>
public static class Questions_RoadMap
{
    #region [ Arrays & Hashing ]

    // https://leetcode.com/problems/contains-duplicate
    public static bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> numSet = [];
        foreach (int num in nums)
        {
            if (!numSet.Add(num))
            {
                return true;
            }
        }
        return false;
    }

    // https://leetcode.com/problems/valid-anagram
    public static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;

        Dictionary<char, int> letters = [];
        for (int i = 0; i < s.Length; i++)
        {
            if (letters.TryGetValue(s[i], out int value))
            {
                letters[s[i]] = ++value;
            }
            else
            {
                letters[s[i]] = 1;
            }

            if (letters.TryGetValue(t[i], out int value2))
            {
                letters[t[i]] = --value2;
            }
            else
            {
                letters[t[i]] = -1;
            }
        }

        foreach (var item in letters)
        {
            if (item.Value != 0) return false;
        }

        return true;
    }

    // https://leetcode.com/problems/two-sum
    public static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> remainingMap = [];
        for(int i = 0; i < nums.Length; i++)
        {
            int remaining = target - nums[i];
            if(remainingMap.TryGetValue(remaining, out int location))
            {
                return [location, i];
            }
            else
            {
                remainingMap[nums[i]] = i;
            }
        }
        return [0]; // You may assume that each input would have exactly one solution.
    }

    // https://leetcode.com/problems/group-anagrams
    public static List<List<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> anagramMap = [];
        foreach (string str in strs)
        {
            char[] chars = str.ToCharArray();
            Array.Sort(chars);
            string sorted = new(chars);
            if(anagramMap.TryGetValue(sorted, out List<string>? values))
            {
                values.Add(str);
            }
            else
            {
                anagramMap.Add(sorted, [str]);
            }
        }

        return [.. anagramMap.Values];
    }

    #endregion
}
