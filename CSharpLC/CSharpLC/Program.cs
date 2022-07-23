using System;
using System.Collections.Generic;

namespace ConsoleApplication1 
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ListNode l1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            ListNode l2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            ListNode l3 = MergeTwoLists(l1, l2);
            while (l3.next != null)
            {
                Console.WriteLine(l3.val);
                l3 = l3.next;
            }

            if (l3 != null)
                Console.WriteLine(l3.val);
        }

        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode h1 = list1;
            ListNode h2 = list2;
            ListNode l3 = null;
            ListNode head = null;
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();
            /*
            while (l1.next != null || l2.next != null)
            {
                if (l1 == null)
                {
                    if (l3 != null)
                    {
                        l3.next = l2;
                        return h3;
                    }
                    else
                    {
                        l3 = l2;
                        return h3;
                    }
                }

                if (l2 == null)
                {
                    if (l3 != null)
                    {
                        l3.next = l2;
                        return h3;
                    }
                    else
                    {
                        l3 = l2;
                        return h3;
                    }
                }

                if (l1.val > l2.val && l1 != null)
                {
                    if (l3 == null)
                    {
                        l3 = new ListNode(l2.val);
                        h3 = l3;
                        l3.next = new ListNode(l1.val);
                        l3 = l3.next;
                    }
                    else
                    {
                        l3.val = l2.val;
                        l3.next = new ListNode(l1.val);
                        l3 = l3.next;
                    }
                }

                if (l2.val > l1.val && l2 != null)
                {
                    if (l3 == null)
                    {
                        l3 = new ListNode(l1.val);
                        h3 = l3;
                        l3.next = new ListNode(l2.val);
                        l3 = l3.next;
                    }
                    else
                    {
                        l3.val = l1.val;
                        l3.next = new ListNode(l2.val);
                        l3 = l3.next;
                    }
                }

                if (l2.val == l1.val)
                {
                    if (l3 == null)
                    {
                        l3 = new ListNode(l2.val);
                        l3.next = new ListNode(l1.val);
                        h3 = l3;
                        l3 = l3.next;
                    }
                    else
                    {
                        l3.val = l2.val;
                        l3.next = new ListNode(l1.val);
                        l3 = l3.next;
                    }
                }

                l3.next = new ListNode();
                l3 = l3.next;
                if (l2.next != null)
                {
                    l2 = l2.next;
                }

                if (l1.next != null)
                {
                    l1 = l1.next;
                }
            }
            */

            /*
            if (l1 == null)
            {
                l3 = l2;
                head = l3;
            }
            else if (l2 == null)
            {
                l3 = l1;
                head = l3;
            }
            else
            {
                l3 = l1;
                head = l3;
                l3.next = new ListNode();
                l3 = l3.next;
                while (l2.next != null)
                {
                    while (l3.next != null)
                    {
                        
                    }
                }
            }
            */

            /*
            if (l1 != null && l2 != null)
            {
                if (l1.val > l2.val)
                {
                    l3.val = l2.val;
                    l3.next = new ListNode(l1.val);
                }
                else
                {
                    l3.val = l1.val;
                    l3.next = new ListNode(l2.val);
                }
            }
            */
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

            /*
            while (list1 != null)
            {
                l3.next = new ListNode(list1.val);
                list1 = list1.next;
                l3 = l3.next;
            }

            while (list2 != null)
            {
                l3.next = new ListNode(list2.val);
                list2 = list2.next;
                l3 = l3.next;
            }
            */
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
}