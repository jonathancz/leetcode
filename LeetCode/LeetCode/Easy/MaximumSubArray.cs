using Xunit;

namespace LeetCode.Easy;

// Given an integer array nums, find the subarray
// with the largest sum, and return its sum.
//
// Example 1:=================================================
//
// Input: nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4]
// Output: 6
// Explanation: The subarray [4,-1,2,1] has the largest sum 6.
//
// Example 2: =================================================
//
// Input: nums = [1]
// Output: 1
// Explanation: The subarray [1] has the largest sum 1.
//
// Example 3: ==================================================
//
// Input: nums = [5,4,-1,7,8]
// Output: 23
// Explanation: The subarray [5,4,-1,7,8] has the largest sum 23.
public class MaximumSubArray
{
    [Theory]
    [InlineData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
    [InlineData(new int[] { 1 }, 1)]
    [InlineData(new int[] { 5, 4, -1, 7, 8 }, 23)]
    public void Solution(int[] nums, int expectedResult)
    {
        var result = MaxSubArray(nums);
        
        Assert.Equal(expectedResult, result);
    }


    public int MaxSubArray(int[] nums)
    {
        var maxSubSum = nums[0];
        var currentSum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (currentSum < 0) // If at any point the sum is zero, we want to reset it to zero
            {
                currentSum = 0;
            }

            currentSum += nums[i];
            maxSubSum = Math.Max(maxSubSum, currentSum);
        }

        return maxSubSum;
    }
}