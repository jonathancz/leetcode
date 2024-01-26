using System.Runtime.InteropServices.JavaScript;
using Xunit;

namespace LeetCode.Easy;

// Given an array of integers nums and an integer target, return indices of the two numbers
// such that they add up to target. You may assume that each input would have exactly one
// solution, and you may not use the same element twice.
// 
// You can return the answer in any order.
//
// Example 1:
//
// Input: nums = [2,7,11,15], target = 9
// Output: [0,1]
// Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
// Example 2:
//
// Input: nums = [3,2,4], target = 6
// Output: [1,2]
// Example 3:
//
// Input: nums = [3,3], target = 6
// Output: [0,1]
public class TwoSum
{
    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new[] { 0, 1 })]
    public void Solution(int[] nums, int target, int[] expectedResult)
    {
        var result = GetTwoSums(nums, target);
        var result2 = GetTwoSumsDictionary(nums, target);
        Assert.True(result.SequenceEqual(expectedResult));
        Assert.True(result2.SequenceEqual(expectedResult));
    }

    /// <summary>
    /// This is optimized because there is only one pass through.
    /// There is this neat trick:
    /// First, we go through the array, and subtract each number with the target.
    /// If the difference is a number that is within the dictionary, we include that in the result.
    /// If not, continue traversing through the array.
    /// For instance
    /// Array: { 3, 2, 4 }
    /// Target : 6
    /// We traverse through the array, starting at 3.
    /// We subtract; 6 - 3 = 3. Is the difference present in the dictionary?
    /// No, add to dictionary (we add 3 as the key, and value as 0 which is the index), and keep traversing.
    /// Now, we're at 2.
    /// 6 - 2 = 4. Is the difference present in the dictionary?
    /// No, add to dictionary and keep traversing.
    /// At this point the Dictionary looks like this:
    ///
    /// Number Value | Index
    ///      3       |   0
    ///      2       |   1
    ///
    /// And lastly, we're at 4.
    /// 6 - 4 = 2. Is the difference in the dictionary? Yes.
    /// That means that the indices that include the numbers that their sum equals the target is:
    /// [1, 2]
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    private int[] GetTwoSumsDictionary(int[] nums, int target)
    {
        // <Value, Index in the Array>
        Dictionary<int, int> dictionary = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int currentNumber = nums[i];
            int difference = target - currentNumber;
            if (dictionary.TryGetValue(difference, out int index))
            {
                return new[] { index, i };
            }

            // If the difference is not found in the dictionary, we want to add it to the dictionary.
            dictionary[currentNumber] = i;
        }

        return Array.Empty<int>();
    }

    private int[] GetTwoSums(int[] nums, int target)
    {
        var result = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 1; j < nums.Length; j++)
            {
                if ((nums[i] + nums[j] == target))
                {
                    var firstIndex = Array.IndexOf(nums, nums[i]);
                    result.AddRange(new[] { firstIndex, j });
                    return result.ToArray();
                }
            }
        }
        return result.ToArray();
    }
}