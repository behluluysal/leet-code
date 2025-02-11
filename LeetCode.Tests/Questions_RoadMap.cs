using System.Text;

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
        for (int i = 0; i < nums.Length; i++)
        {
            int remaining = target - nums[i];
            if (remainingMap.TryGetValue(remaining, out int location))
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
            if (anagramMap.TryGetValue(sorted, out List<string>? values))
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

    // https://leetcode.com/problems/top-k-frequent-elements
    public static int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> map = [];
        List<int>[] buckets = new List<int>[nums.Length + 1];
        List<int> result = [];

        foreach (int num in nums)
        {
            if (!map.TryAdd(num, 1))
                map[num]++;
        }

        foreach (var kvp in map)
        {
            int freq = kvp.Value;
            if (buckets[freq] is null)
                buckets[freq] = [];
            buckets[freq].Add(kvp.Key);
        }

        for (int i = buckets.Length - 1; i > 0 && result.Count < k; i--)
        {
            if (buckets[i] is not null)
            {
                result.AddRange(buckets[i]);
            }
        }

        return result.Take(k).ToArray();
    }

    // https://neetcode.io/problems/string-encode-and-decode
    public static string Encode(IList<string> strs)
    {
        StringBuilder builder = new();
        foreach (string str in strs)
        {
            builder.Append($"{str.Length}#{str}");
        }
        return builder.ToString();
    }

    public static List<string> Decode(string s)
    {
        List<string> result = [];
        int index = 0;
        while (index < s.Length)
        {
            int tempIndex = index;
            while (s[tempIndex] != '#')
            {
                tempIndex++;
            }
            int lenght = int.Parse(s[index..tempIndex]);
            index = tempIndex + 1;
            result.Add(s.Substring(index, lenght));
            index += lenght;
        }
        return result;
    }

    // https://leetcode.com/problems/longest-consecutive-sequence
    public static int LongestConsecutive(int[] nums)
    {
        if (nums.Length == 0) return 0;
        HashSet<int> set = [.. nums];
        int max = 0;
        foreach (int element in set)
        {
            if (set.Contains(element - 1))
                continue;
            int counter = 1;
            int nextNumber = element + 1;
            while (set.Contains(nextNumber))
            {
                counter++;
                nextNumber++;
            }
            if (counter > max)
                max = counter;
        }
        return max;
    }

    // https://leetcode.com/problems/valid-sudoku
    public static bool IsValidSudoku(char[][] board)
    {
        Dictionary<int, HashSet<char>> rows = [];
        Dictionary<int, HashSet<char>> columns = [];
        Dictionary<int, HashSet<char>> subMatricies = [];
        int row = 0;
        int column = 0;
        int subMatrix = 0;

        char[] flattenedBoard = new char[81];
        for (int i = 0; i < 9; i++)
            for (int j = 0; j < 9; j++)
                flattenedBoard[i * 9 + j] = board[i][j];

        for (int index = 0; index < 81; index++)
        {
            if (index % 9 == 0 && index != 0)
            {
                row++;
                column = 0;
                if(row % 3 != 0)
                    subMatrix -= 3;
            }
            if (index % 3 == 0 && index != 0)
            {
                subMatrix++;
            }
            column++;
            char currentValue = flattenedBoard[index];

            if (currentValue == '.')
                continue;

            if (rows.TryGetValue(row, out var rowList))
            {
                if (rowList.Contains(currentValue))
                    return false;
                rowList.Add(currentValue);
            }
            else
                rows.Add(row, [currentValue]);

            if (columns.TryGetValue(column, out var columnList))
            {
                if (columnList.Contains(currentValue))
                    return false;
                columnList.Add(currentValue);
            }
            else
                columns.Add(column, [currentValue]);

            if (subMatricies.TryGetValue(subMatrix, out var subMatrixList))
            {
                if (subMatrixList.Contains(currentValue))
                    return false;
                subMatrixList.Add(currentValue);
            }
            else
                subMatricies.Add(subMatrix, [currentValue]);

        }

        return true;
    }

    #endregion

    #region [ Stack ]

    // https://leetcode.com/problems/valid-parentheses
    public static bool IsValidParantheses(string s)
    {

        Stack<char> stack = [];
        Dictionary<char, char> map = new()
        {
            { ')' ,'(' },
            { '}' ,'{' },
            { ']' ,'[' }
        };

        foreach (char element in s)
        {
            if(map.ContainsKey(element))
            {
                if(stack.TryPeek(out char value) && value == map[element])
                    stack.Pop();
                else
                    return false;
            }
            else
                stack.Push(element);
        }
        return stack.Count == 0;
    }

    #endregion
}
