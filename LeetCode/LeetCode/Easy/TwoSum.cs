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
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new [] {0 ,1})]
    [InlineData(new int[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new[] { 0, 1 })]
    public void Solution(int[] nums, int target, int[] expectedResult)
    {
        var result = GetTwoSums(nums, target);
        // Assert.True(result.SequenceEqual(expectedResult));
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
                    var secondIndex = Array.IndexOf(nums, nums[j]);
                    result.AddRange(new[] { firstIndex, secondIndex });
                    return result.ToArray();
                }
            }
        }

        return result.ToArray();
    }
}