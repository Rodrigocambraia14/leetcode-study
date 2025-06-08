using System.Diagnostics;

Stopwatch stopWatch = new();

stopWatch.Start();

var result = Solution.RomanToInt("MCMXCIV");

stopWatch.Stop();

Console.WriteLine(stopWatch.Elapsed);

public static class Solution
{
    //    Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.


    //Example 1:

    //Input: nums = [2, 7, 11, 15], target = 9
    //Output: [0, 1]
    //Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
    //Example 2:

    //Input: nums = [3, 2, 4], target = 6
    //Output: [1, 2]
    //Example 3:

    //Input: nums = [3, 3], target = 6
    //Output: [0, 1]
    public static int[] TwoSum(int[] nums, int target)
    {
        //key is the number, value is the index
        Dictionary<int, int> dict = new();

        for (int i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];

            if (dict.TryGetValue(complement, out int index))
            {
                return [index, i];
            }

            dict[nums[i]] = i;
        }

        return [];
    }

    //    Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

    // Symbol Value
    //I             1
    //V             5
    //X             10
    //L             50
    //C             100
    //D             500
    //M             1000
    //For example, 2 is written as II in Roman numeral, just two ones added together. 12 is written as XII, which is simply X + II.The number 27 is written as XXVII, which is XX + V + II.

    //Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV.Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX.There are six instances where subtraction is used:

    //I can be placed before V (5) and X(10) to make 4 and 9. 
    //X can be placed before L(50) and C(100) to make 40 and 90. 
    //C can be placed before D(500) and M(1000) to make 400 and 900.
    //Given a roman numeral, convert it to an integer.
    public static int RomanToInt(string s)
    {
        int sum = 0;
        int prev = 0;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            int val =  s[i] switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => 0,
            };;

            if (val < prev)
            {
                sum -= val;
                prev = val;
                continue;
            }

            sum += val;
            prev = val;
        }

        return sum;
    }
}






