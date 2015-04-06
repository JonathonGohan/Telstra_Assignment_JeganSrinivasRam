using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4BinarySearchTree
{
    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int value, Node left, Node right)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
    public class BinarySearchTree
    {
        static bool result = true;
        static Node topRoot = null;

        static Stack<Node> rootsLeftSideNodes = new Stack<Node>();
        static Stack<Node> rootsRightSideNodes = new Stack<Node>();
        static Node ParentNode = null;

        public static void IsValidBST(Node root)
        {
            Console.WriteLine("Root Node : " + root.Value + " ,  Left : " + (root.Left != null ? "" + root.Left.Value : "null") + " ,   Right : " + (root.Right != null ? "" + root.Right.Value : "null") + "\n");
            
            if ( root.Left != null ) 
                result = root.Value > root.Left.Value;
            if ( root.Right != null ) 
                result = root.Value < root.Right.Value;

            if (result && root.Left != null)
            {
                Console.WriteLine("Roots LEFT Subtree\n");
                checkLeftSide(root.Left);
            }

            if (result && root.Right != null)
            {
                Console.WriteLine("\nRoots RIGHT Subtree\n");
                checkRightSide(root.Right);
            }
        }

        private static void checkLeftSide(Node node)
        {
            Console.WriteLine("\tNode : " + node.Value + " ,  Left : " + (node.Left != null ? "" + node.Left.Value : "null") + " ,   Right : " + (node.Right != null ? "" + node.Right.Value : "null") );
            if( node.Left != null && node.Right != null )
            {
                rootsLeftSideNodes.Push(node);
                ParentNode = node;
                checkLeftSide(node.Left);
            }
            else if ( node.Left == null && node.Right == null)
            {
                if (node == ParentNode.Left)
                {
                    if (node.Value > ParentNode.Value || node.Value > topRoot.Value)
                    {
                        result = false;
                        return;
                    }
                }
                else if (node == ParentNode.Right)
                {
                    if (node.Value < ParentNode.Value || node.Value > topRoot.Value)
                    {
                        result = false;
                        return;
                    }
                }

                if (rootsLeftSideNodes.Count > 0)
                {
                    ParentNode = rootsLeftSideNodes.Pop();
                    checkLeftSide(ParentNode.Right);
                }
            }
            else
            {
                ParentNode = node;

                if (node.Left == null)
                    checkLeftSide(node.Right);
                else if (node.Right == null)
                    checkLeftSide(node.Left);
            }            
        }

        private static void checkRightSide(Node node)
        {
            Console.WriteLine("\tNode : " + node.Value + " ,  Left : " + (node.Left != null ? "" + node.Left.Value : "null") + " ,   Right : " + (node.Right != null ? "" + node.Right.Value : "null"));
            if (node.Left != null && node.Right != null)
            {
                rootsRightSideNodes.Push(node);
                ParentNode = node;
                checkRightSide(node.Left);
            }
            else if (node.Left == null && node.Right == null)
            {
                if (node == ParentNode.Left)
                {
                    if (node.Value > ParentNode.Value || node.Value < topRoot.Value)
                    {
                        result = false;
                        return;
                    }
                }
                else if (node == ParentNode.Right)
                {
                    if (node.Value < ParentNode.Value || node.Value < topRoot.Value)
                    {
                        result = false;
                        return;
                    }
                }
                if (rootsRightSideNodes.Count > 0)
                {
                    ParentNode = rootsRightSideNodes.Pop();
                    checkRightSide(ParentNode.Right);
                }
            }
            else 
            {
                ParentNode = node;

                if (node.Left == null)
                    checkRightSide(node.Right);
                else if (node.Right == null)
                   checkRightSide(node.Left);
            }
        }
        public static void Main(string[] args)
        {
            #region test sets
            /*Node n1 = new Node(1, null, null);
            Node n3 = new Node(3, null, null);
            Node n2 = new Node(2, n3, n1);*/
            
            /*Node n4 = new Node(1, null, null);
            Node n7 = new Node(4, null, null);
            Node n8 = new Node(7, null, null);
            Node n9 = new Node(13, null, null);
            Node n5 = new Node(6, n7, n8);
            Node n6 = new Node(14, n9, null);
            Node n3 = new Node(10, null, n6);
            Node n2 = new Node(3, n4, n5);
            Node n1 = new Node(8 , n2, n3);*/
            
            /*Node n4 = new Node(25, null, null);
            Node n7 = new Node(60, null, null);
            Node n8 = new Node(85, null, null);
            Node n9 = new Node(250, null, null);
            Node n5 = new Node(75, n7, n8);
            Node n6 = new Node(300, n9, null);
            Node n3 = new Node(200, null, n6);
            Node n2 = new Node(50, n4, n5);
            Node n1 = new Node(100 , n2, n3);*/

            /*Node n4 = new Node(25, null, null);
            Node n7 = new Node(60, null, null);
            Node n8 = new Node(85, null, null);
            Node n9 = new Node(250, null, null);
            Node n5 = new Node(75, n7, n8);
            Node n6 = new Node(300, n9, null);
            Node n3 = new Node(200, null, n6);
            Node n2 = new Node(50, n4, n5);
            Node n1 = new Node(100, n2, n3);*/

            /*Node n11 = new Node(67, null, null);
            Node n10 = new Node(19, null, null);
            Node n9 = new Node(140, null, null);
            Node n8 = new Node(9, null, null);
            Node n7 = new Node(76, null, null);
            Node n6 = new Node(54, null, n11);
            Node n5 = new Node(23, n10, null);
            Node n4 = new Node(12, n8, n9);
            Node n3 = new Node(72, n6, n7);
            Node n2 = new Node(17, n4, n5);
            Node n1 = new Node(50, n2, n3);*/

            /*Node n11 = new Node(67, null, null);
            Node n10 = new Node(19, null, null);
            Node n9 = new Node(14, null, null);
            Node n8 = new Node(9, null, null);
            Node n7 = new Node(76, null, null);
            Node n6 = new Node(54, null, n11);
            Node n5 = new Node(23, n10, null);
            Node n4 = new Node(12, n8, n9);
            Node n3 = new Node(72, n6, n7);
            Node n2 = new Node(17, n4, n5);
            Node n1 = new Node(50, n2, n3);*/

            /*Node n12 = new Node(95, null, null);
            Node n11 = new Node(89, null, n12);
            Node n10 = new Node(66, null, null);
            Node n9 = new Node(37, null, null);
            Node n8 = new Node(12, null, null);
            Node n7 = new Node(84, n10, n11);
            Node n6 = new Node(40, null, null);
            Node n5 = new Node(25, null, n9);
            Node n4 = new Node(10, null, n8);
            Node n3 = new Node(51, n6, n7);
            Node n2 = new Node(13, n4, n5);
            Node n1 = new Node(38, n2, n3);*/

            /*Node n2 = new Node(24, null, null);
            Node n1 = new Node(23, null, n2);*/

            #endregion

            Node n7 = new Node(56, null, null);
            Node n6 = new Node(11, null, null);
            Node n5 = new Node(80, n7, null);
            Node n4 = new Node(13, n6, null);
            Node n3 = new Node(35, null, n5);
            Node n2 = new Node(2, null, n4);
            Node n1 = new Node(23, n2, n3);

            topRoot = ParentNode = n1;

            IsValidBST(n1);
            Console.WriteLine("\n" + (result ? "Valid BST" : "Not a valid BST") + "\n");
        }
    }
}
