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
                if (row % 3 != 0)
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
            if (map.ContainsKey(element))
            {
                if (stack.TryPeek(out char value) && value == map[element])
                    stack.Pop();
                else
                    return false;
            }
            else
                stack.Push(element);
        }
        return stack.Count == 0;
    }

    // https://leetcode.com/problems/evaluate-reverse-polish-notation
    public static int EvalRPN(string[] tokens)
    {
        Stack<int> stack = [];
        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int currentVal))
            {
                stack.Push(currentVal);
                continue;
            }
            int val2 = stack.Pop();
            int val1 = stack.Pop();

            if (token == "+")
            {
                stack.Push(val1 + val2);
            }
            else if (token == "-")
            {
                stack.Push(val1 - val2);
            }
            else if (token == "*")
            {
                stack.Push(val1 * val2);
            }
            else if (token == "/")
            {
                stack.Push(val1 / val2);
            }
        }
        return stack.Pop();
    }

    // https://leetcode.com/problems/daily-temperatures
    public static int[] DailyTemperatures(int[] temperatures)
    {
        int[] result = new int[temperatures.Length];
        int index = 0;
        Stack<(int index, int temp)> stack = [];
        foreach (int temperature in temperatures)
        {
            while (stack.Count > 0 && temperature > stack.Peek().temp)
            {
                var tuple = stack.Pop();
                result[tuple.index] = index - tuple.index;
            }
            stack.Push((index, temperature));
            index++;
        }
        return result;
    }

    // https://leetcode.com/problems/generate-parentheses/
    public static IList<string> GenerateParenthesis(int n)
    {
        List<string> result = [];
        GenerateParenthesisHelper(result, new StringBuilder(), 0, 0, n);
        return result;
    }

    // https://leetcode.com/problems/car-fleet
    public static int CarFleet(int target, int[] position, int[] speed)
    {
        List<(int position, int speed)> fleet = [];
        for (int i = 0; i < position.Length; i++)
        {
            fleet.Add((position[i], speed[i]));
        }

        fleet = [.. fleet.OrderByDescending(car => car.position)];

        Stack<double> stack = [];
        foreach (var car in fleet)
        {
            double time = (double)(target - car.position) / car.speed;
            stack.Push(time);
            if (stack.Count >= 2 && stack.Peek() <= stack.ElementAt(1))
            {
                stack.Pop();
            }
        }

        return stack.Count;
    }

    // https://leetcode.com/problems/largest-rectangle-in-histogram/
    public static int LargestRectangleArea(int[] heights)
    {
        Stack<(int index, int height)> stack = [];
        int maxArea = 0;
        int index = 0;
        foreach (int height in heights)
        {
            // On every pop, that means current element can be draw a rectangle backwards.
            // To supply the width of that operation, use a temp index.
            int tempIndex = index;
            while (stack.Count > 0 && height < stack.Peek().height)
            {
                (int itemIndex, int itemHeight) = stack.Pop();
                int newArea = itemHeight * (index - itemIndex);
                maxArea = newArea > maxArea ? newArea : maxArea;
                tempIndex = itemIndex;
            }
            stack.Push((tempIndex, height));
            index++;
        }

        foreach ((int itemIndex, int itemHeight) in stack)
        {
            int newArea = itemHeight * (index - itemIndex);
            maxArea = newArea > maxArea ? newArea : maxArea;
        }
        return maxArea;
    }

    #endregion

    #region [ Two Pointer ]

    // https://leetcode.com/problems/valid-palindrome
    public static bool IsPalindrome(string s)
    {
        int head = 0, tail = s.Length - 1;
        while (head < tail)
        {
            if (!IsAlphaNumeric(s[head]))
            {
                head++;
                continue;
            }
            else if (!IsAlphaNumeric(s[tail]))
            {
                tail--;
                continue;
            }

            if (char.ToLower(s[head]) != char.ToLower(s[tail]))
                return false;
            head++;
            tail--;
        }
        return true;
    }

    // https://leetcode.com/problems/two-sum-ii-input-array-is-sorted
    public static int[] TwoSumII(int[] numbers, int target)
    {
        int head = 0, tail = numbers.Length - 1;
        while (head < tail)
        {
            if (numbers[head] + numbers[tail] == target)
                return [head + 1, tail + 1];
            if (numbers[head] + numbers[tail] < target)
                head++;
            else
                tail--;
        }
        return [];
    }

    // https://leetcode.com/problems/3sum
    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> result = [];
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            int target = 0 - nums[i];
            int left = i + 1;
            int right = nums.Length - 1;
            while (left < right)
            {

                if (nums[left] + nums[right] == target)
                {
                    result.Add([nums[i], nums[left], nums[right]]);
                    left++;
                    right--;
                    while (left < right && nums[left] == nums[left - 1])
                    {
                        left++;
                    }
                }
                else if (nums[left] + nums[right] < target)
                    left++;
                else
                    right--;
            }
        }
        return result;
    }

    // https://leetcode.com/problems/container-with-most-water
    public static int MaxArea(int[] height)
    {
        int max = 0;
        int left = 0, right = height.Length - 1;
        while (left < right)
        {
            int lowerHeight = Math.Min(height[left], height[right]);
            int currentArea = lowerHeight * (right - left);
            if (max < currentArea)
                max = currentArea;
            if (height[left] < height[right])
                left++;
            else
                right--;
        }
        return max;
    }

    // https://leetcode.com/problems/trapping-rain-water/
    // This solution is not using two pointer approach. Check TrapII for two pointer solution.
    public static int Trap(int[] height)
    {
        int[] prefix = new int[height.Length];
        int[] suffix = new int[height.Length];
        int totalWater = 0;
        int max = 0;
        for (int i = 0; i < height.Length; i++)
        {
            prefix[i] = max;
            if (max < height[i])
                max = height[i];
        }
        max = 0;
        for (int i = height.Length - 1; i > 0; i--)
        {
            suffix[i] = max;
            if (max < height[i])
                max = height[i];
        }

        for (int i = 0; i < height.Length; i++)
        {
            int min = Math.Min(prefix[i], suffix[i]);
            int water = min - height[i];
            totalWater += water > 0 ? water : 0;
        }

        return totalWater;
    }
    public static int TrapII(int[] height)
    {
        int totalWater = 0;
        int left = 0;
        int right = height.Length - 1;
        int leftMax = height[0];
        int rightMax = height[^1];

        while (left < right)
        {
            if (leftMax < rightMax)
            {
                left++;
                leftMax = Math.Max(leftMax, height[left]);
                totalWater += (leftMax - height[left]);
            }
            else
            {
                right--;
                rightMax = Math.Max(rightMax, height[right]);
                totalWater += (rightMax - height[right]);
            }
        }
        return totalWater;
    }

    #endregion

    #region [ Sliding Window ]

    // https://leetcode.com/problems/best-time-to-buy-and-sell-stock
    public static int MaxProfit(int[] prices)
    {
        int sellPoint = 1, buyPrice = prices[0];
        int maxProfit = 0;
        for (; sellPoint < prices.Length; sellPoint++)
        {
            if (prices[sellPoint] < buyPrice)
                buyPrice = prices[sellPoint];

            int profit = prices[sellPoint] - buyPrice;

            if (profit > maxProfit)
                maxProfit = profit;
        }
        return maxProfit;
    }

    // https://leetcode.com/problems/longest-substring-without-repeating-characters
    public static int LengthOfLongestSubstring(string s)
    {
        HashSet<char> window = [];
        int left = 0, right = 0;
        int max = 0;
        while (right < s.Length)
        {
            if (!window.Contains(s[right]))
            {
                window.Add(s[right++]);
            }
            else
            {
                max = max < window.Count ? window.Count : max;
                while (window.Contains(s[right]))
                {
                    window.Remove(s[left++]);
                }
            }
        }
        return max < window.Count ? window.Count : max;
    }

    // https://leetcode.com/problems/longest-repeating-character-replacement
    public static int CharacterReplacement(string s, int k)
    {
        Dictionary<char, int> dictionary = [];
        int max = 0, mostCharInDictionary = 0, left = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (dictionary.TryGetValue(s[i], out int value))
                dictionary[s[i]] = ++value;
            else
                dictionary.Add(s[i], 1);

            mostCharInDictionary = Math.Max(mostCharInDictionary, dictionary[s[i]]);
            int windowLength = i - left + 1;
            while (windowLength - mostCharInDictionary > k)
            {
                dictionary[s[left]]--;
                left++;
                windowLength = i - left + 1;
            }
            max = Math.Max(max, windowLength);

        }
        return max;
    }

    // https://leetcode.com/problems/permutation-in-string
    public static bool CheckInclusion(string s1, string s2)
    {
        int[] s1Set = new int[26];
        int left = -1, windowSize = 0;

        for (int i = 0; i < s1.Length; i++)
        {
            s1Set[s1[i] - 'a']++;
        }

        for (int right = 0; right < s2.Length; right++)
        {
            if (s1Set[s2[right] - 'a'] == 0)
            {
                // shrink the window until we get space for the current element s2[right]
                // if s2[right] is not desired (meaning not in s1) shrink the window completely
                while (windowSize > 0 && s1Set[s2[right] - 'a'] == 0)
                {
                    windowSize--;
                    s1Set[s2[left] - 'a']++;
                    left++;
                }

                // after shrinking if we do not have space for s[right] it means we dont wanted this char at all
                // window is deleted until we find a new desired char, set left to -1
                // otherwise it means while shrinking the window we popped a char which is the same with s2[right]
                // that means add that again to window (in else statement)
                if (s1Set[s2[right] - 'a'] == 0)
                    left = -1;
                else
                {
                    s1Set[s2[right] - 'a']--;
                    windowSize++;
                }
            }
            else
            {
                s1Set[s2[right] - 'a']--;
                windowSize++;
                // if the sequence is just starting set the window start
                if (left == -1)
                    left = right;
            }
            if (windowSize == s1.Length)
                return true;
        }
        return false;
    }

    // https://leetcode.com/problems/minimum-window-substring
    public static string MinWindow(string s, string t)
    {
        Dictionary<char, int> tMap = [];
        Queue<char> queue = [];
        int min = 100001, start = 0, end = 0;

        for (int i = 0; i < t.Length; i++)
        {
            if (tMap.TryGetValue(t[i], out int value))
                tMap[t[i]] = ++value;
            else
                tMap.Add(t[i], 1);
        }

        int count = tMap.Count;

        for (int right = 0; right < s.Length; right++)
        {
            char current = s[right];
            queue.Enqueue(current);
            if (tMap.TryGetValue(current, out int value))
            {
                tMap[current] = --value;
                if (value == 0)
                    count--;

                while (count == 0)
                {
                    char topElement = queue.Peek();
                    if (tMap.TryGetValue(topElement, out int value2))
                    {
                        if (queue.Count < min)
                        {
                            min = queue.Count;
                            start = right - min + 1;
                            end = right + 1;
                        }
                        tMap[topElement] = ++value2;
                        count = value2 > 0 ? count + 1 : count;
                    }
                    queue.Dequeue();
                }
            }

        }
        return min == 100001 ? string.Empty : s[start..end];
    }

    #endregion

    #region [ Helpers ]

    private static void GenerateParenthesisHelper(List<string> result, StringBuilder current, int open, int close, int max)
    {
        if (current.Length == max * 2)
        {
            result.Add(current.ToString());
            return;
        }

        if (open < max)
        {
            current.Append('(');
            GenerateParenthesisHelper(result, current, open + 1, close, max);
            current.Remove(current.Length - 1, 1);
        }

        if (close < open)
        {
            current.Append(')');
            GenerateParenthesisHelper(result, current, open, close + 1, max);
            current.Remove(current.Length - 1, 1);
        }
    }

    private static bool IsAlphaNumeric(char c)
    {
        return (c >= 'A' && c <= 'Z' ||
                c >= 'a' && c <= 'z' ||
                c >= '0' && c <= '9');
    }

    #endregion
}
