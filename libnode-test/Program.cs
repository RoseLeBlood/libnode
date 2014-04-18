using System;
using node;
using System.IO;


namespace libnodetest
{
	class MainClass
	{
        public static void TreeTest()
        {
            Int32BinaryTreeNode node = new Int32BinaryTreeNode ("value1", 2);
            node.setNode (new Int32BinaryTreeNode ("value2", 34));
            node.setNode (new Int32BinaryTreeNode ("value3", 35));
            node.setNode (new Int32BinaryTreeNode ("value4", 166));
            node.setNode (new SingleBinaryTreeNode ("value5", 78.65f));
            node.setNode (new SByteBinaryTreeNode ("value6", 64));
            node.setNode (new DoubleBinaryTreeNode ("value7", 0.37999999));
            node.setNode (new DecimalBinaryTreeNode ("value8", 1276));
            node.setNode (new StreamBinaryTreeNode("valueStream", new MemoryStream()));


            Console.WriteLine("Inorder traversal");
            node.Travers(TraversOrder.Inorder, node.Root);
            Console.WriteLine("\n");
     
            Console.WriteLine("Preorder traversal");
            node.Travers(TraversOrder.Preorder, node.Root);
            Console.WriteLine("\n");
     
            Console.WriteLine("Postorder traversal");
            node.Travers(TraversOrder.Postorder, node.Root);
            Console.WriteLine("\n");
        }
        public static void ListTest()
        {
            Int32ListNode node = new Int32ListNode ("value1", 2);
            node.setNode (new Int32ListNode ("value2", 34));
            node.setNode (new Int32ListNode ("value3", 35));
            node.setNode (new Int32ListNode ("value4", 166));
            node.setNode (new SingleListNode ("value5", 78.65f));
            node.setNode (new SByteListNode ("value6", 64));
            node.setNode (new DoubleListNode ("value7", 0.37999999));
            node.setNode (new DecimalListNode ("value8", 1276));
            node.setNode (new StreamListNode("valueStream", new MemoryStream()));


            Console.WriteLine("List Order traversal");
            node.Travers(TraversOrder.ListOrder, node.Root);
            Console.WriteLine("\n");
        }
		public static void Main (string[] args)
		{
            TreeTest();

            ListTest();

		    Console.ReadLine ();
		}

	}
}
