


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
class InvertBst
{
    /*
      Description: Utilizes a helper function to return the head of a newly inverted binary tree
      Inorder traversal, left -> root -> right*/
    public static TreeNode InvertTree(TreeNode tn)
    {
        TreeNode root = tn;
        InvertTreeHelp(root);

        return root;
    }

    public static void InvertTreeHelp(TreeNode root)
    {
        if (root == null)
        {
            return;
        }

        TreeNode hold = root.left;
        root.left = root.right;
        root.right = hold;

        InvertTreeHelp(root.left);

        InvertTreeHelp(root.right);
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
