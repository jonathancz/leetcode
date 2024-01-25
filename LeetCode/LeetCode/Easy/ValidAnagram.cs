using Xunit;

namespace LeetCode.Easy;

/// <summary>
/// 242. Valid Anagram
// Given two strings s and t, return true if t is an anagram of s, and false otherwise.
//
// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
// typically using all the original letters exactly once.
// Example 1:
// Input: s = "anagram", t = "nagaram"
// Output: true
// Example 2: 
// Input : s = "rat", t = "car"
// Output : false
/// </summary>
public class ValidAnagram
{
    [Theory]
    [InlineData("anagram", "nagaram", true)]
    [InlineData("rat", "car", false)]
    public void Solution(string s, string t, bool expectedResult)
    {
        var isAnagram = IsAnagram2(s, t);
        Assert.Equal(expectedResult, isAnagram);
    }

    private bool IsAnagram(string s, string t)
    {
        // 1. Convert s and t to char list
        var sArray = s.ToCharArray(); // ['a', 'n', 'a', 'g', 'r', 'a', 'm' ]
        var tArray = t.ToCharArray(); // ['n', 'a', 'g', 'a', 'r', 'a', 'm' ]

        bool result = false;
        foreach (var character in sArray)
        {
            result = tArray.Contains(character);
        }

        return result;
    }
    
    /// <summary>
    /// A cleaner way to approach this problem; By definition, anagrams contain the same length. Therefore,
    /// if we just order them by character, it should result in the same ordering.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    private bool IsAnagram2(string s, string t)
    {
        // 1. Convert s and t to char list
        var sArray = s.ToCharArray(); // ['a', 'n', 'a', 'g', 'r', 'a', 'm' ]
        var tArray = t.ToCharArray(); // ['n', 'a', 'g', 'a', 'r', 'a', 'm' ]

        return sArray.OrderBy(x => x).SequenceEqual(tArray.OrderBy(t => t));
    }
}