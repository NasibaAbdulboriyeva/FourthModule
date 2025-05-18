using System.Text;

namespace leetCode;

public class Program
{
    private static void Main(string[] args)
    {


    }
    //public class Solution
    //{
    //    public string Convert(string s, int numRows)
    //    {
    //        if (numRows == 1 || s.Length <= numRows)
    //            return s;

    //        var lists = BuildZigzagRows(s, numRows);
    //        var result = new StringBuilder();

    //        foreach (var list in lists)
    //        {
    //            foreach (var ch in list)
    //            {
    //                result.Append(ch);
    //            }
    //        }

    //        return result.ToString();
    //    }

    //    private List<List<char>> BuildZigzagRows(string s, int numRows)
    //    {
    //        var rows = new List<List<char>>();
    //        for (int i = 0; i < numRows; i++)
    //        {
    //            rows.Add(new List<char>());
    //        }

    //        int row = 0;
    //        int direction = 1;

    //        foreach (char c in s)
    //        {
    //            rows[row].Add(c);

    //            row += direction;
    //            if (row == numRows)
    //            {
    //                direction = -1;
    //                row = numRows - 2;
    //            }
    //            else if (row < 0)
    //            {
    //                direction = 1;
    //                row = 1;
    //            }
    //        }

    //        return rows;
    //    }
    //}

    public class Solution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums.Count() == 3)
            {
                return nums[0] + nums[1] + nums[3];
            }
            return 0;
        }
    }


}


