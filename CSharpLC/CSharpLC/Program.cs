using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Xml.XPath;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine(isPal("A man, a plan, a canal: Panama"));
            //Search(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
            // Console.WriteLine(Search(new int[] { -1, 0, 3, 5, 9, 12 }, 2));


            /*
            int[,] floodTest = FloodFill(test, 1, 1, 2);
            */
            int[] test = new int[] { -2, -1, -3, -4, -1, -2, -1, -5, -4 };
            Console.WriteLine(MaxSubArray(test));


        }
        /*KADANES ALGORITHM
        * Initialize ->
            -->Max = 0
            -->tempMax = 0
          Foreach elm in a
          --> tempMax = Max(0, tempMax + elm) 
          --> max = Max()

          tempMax is a aux accumulator to test against the last found max.

*/


        public static int MaxSubArray(int[] nums)
        {
            int max = Int32.MinValue;
            int tempMax = 0;
            int negMax = Int32.MinValue;

            for (int j = 0; j < nums.Length; j++)
            {
                tempMax = Math.Max(0, tempMax + nums[j]);
                max = Math.Max(max, tempMax);
                negMax = Math.Max(negMax, nums[j]);
            }
            return Math.Max(negMax, max);
        }

        public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            if (image[sr][sc] != color)
            {
                FloodFillAux(image, sr, sc, color, image[sr][sc]);
                return image;
            }
            //recursion
            if (image[sr][sc] == color)
                return image;
            else
                return image;

        }
        public static void FloodFillAux(int[][] image, int sr, int sc, int color, int orig)
        {
            if (sr >= 0 && sr < image.Length && sc >= 0 && sc < image[sr].Length)
            {

                int oldColor = image[sr][sc];
                if (oldColor == color)
                {
                    return;
                }
                if (oldColor != color && oldColor == orig)
                {
                    image[sr][sc] = color;
                    FloodFillAux(image, sr - 1, sc, color, oldColor);
                    FloodFillAux(image, sr + 1, sc, color, oldColor);
                    FloodFillAux(image, sr, sc - 1, color, oldColor);
                    FloodFillAux(image, sr, sc + 1, color, oldColor);
                }
            }
        }


        public static void PrintInt2D(int[][] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = 0; j < list[i].Length; j++)
                    Console.Write("[" + list[i][j] + "] ");
                Console.WriteLine();
            }
        }



        public static int Search(int[] nums, int target)

        {

            return BinarySearch(nums, target, 0, nums.Length - 1);
        }


        public static int BinarySearch(int[] list, int target, int i, int j)
        {

            if (j >= 0 && i < list.Length && i <= j)
            {
                int mid = (j + i) / 2;
                if (list[mid] == target)
                    return mid;
                if (list[mid] < target)
                    return BinarySearch(list, target, mid + 1, j);
                if (list[mid] > target)
                    return BinarySearch(list, target, i, mid - 1);

            }
            return -1;
        }
        public static bool IsAnagram(string s, string t)
        {
            char[] sa = s.ToCharArray();
            char[] ta = t.ToCharArray();
            if (s.Length != t.Length)
            {
                return false;
            }

            Dictionary<char, int> sd = new Dictionary<char, int>();

            foreach (var c in sa)
            {
                if (sd.TryGetValue(c, out int value))
                {
                    sd[c] = value + 1;
                    Console.WriteLine("(k, v): " + sd[c]);
                }
                else
                {
                    sd.Add(c, 1);
                }
            }

            for (int i = 0; i < ta.Length; i++)
            {
                if (sd.TryGetValue(ta[i], out int value))
                    sd[ta[i]] = value - 1;
                else if (!sd.TryGetValue(ta[i], out int v2))
                    return false;

                else if (sd[ta[i]] < 0) return false;
            }

            return true;
        }

        public static TreeNode InvertTree(TreeNode tn)
        {
            TreeNode root = tn;
            InvertTree2(root);

            return root;
        }

        public static void InvertTree2(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            TreeNode hold = root.left;
            root.left = root.right;
            root.right = hold;

            InvertTree2(root.left);
            InvertTree2(root.right);
        }

        public static int MaxProfit(int[] prices)
        {
            int x = prices[0];
            int profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < x)
                {
                    x = prices[i];
                }

                if (prices[i] - x > profit)
                {
                    profit = (prices[i] - x);
                }
            }

            return profit;
        }

        public static bool isPal(String s)
        {
            String s2 = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsLetterOrDigit(s[i]))
                    s2 += Char.ToLower(s[i]);
            }

            char[] charArray = s2.ToCharArray();
            Array.Reverse(charArray);
            String s3 = new String(charArray);
            if (s3 == s2)
                return true;
            else
                return false;
        }

        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode h1 = list1;
            ListNode h2 = list2;
            ListNode l3 = null;
            ListNode head = null;
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();

            if (list1 == null)
            {
                return list2;
            }

            if (list2 == null)
            {
                return list1;
            }

            if (list2.val < list1.val)
            {
                l3 = new ListNode(list2.val);
                head = l3;
                list2 = list2.next;
            }
            else if (list1.val < list2.val)
            {
                l3 = new ListNode(list1.val);
                head = l3;
                list1 = list1.next;
            }
            else
            {
                l3 = new ListNode(list1.val);
                head = l3;
                list1 = list1.next;
            }

            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    l3.next = new ListNode(list1.val);
                    list1 = list1.next;
                }
                else
                {
                    l3.next = new ListNode(list2.val);
                    list2 = list2.next;
                }

                l3 = l3.next;
            }


            if (list1 != null)
            {
                l3.next = list1;
            }

            if (list2 != null)
            {
                l3.next = list2;
            }


            return head;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
