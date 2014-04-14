//
//  BinaryTree.cs
//
//  Author:
//       sophia <annasophia.schroeck@outlook.de>
//
//  Copyright (c) 2014 sophia
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;

namespace node
{

	public class BinaryTreeNode<T> : Node<T, BinaryTreeNode<T>>
		where T : class
	{
		internal bool m_now = false;

		public override BinaryTreeNode<T> Root 
		{
			get
			{
				if (m_root == null)
					return this;
				else
					return m_root.Root;
			}
		}
        public BinaryTreeNode<T> Parent
        {
            get { return m_root; }
            set { m_root = value; }
        }
		public BinaryTreeNode<T> Right 
		{
			get { return m_right; }
		}
		public BinaryTreeNode<T> Left
		{
			get { return m_left; }
		}


		public BinaryTreeNode (string name)
			: base(name)
		{
		}
		public BinaryTreeNode (string name, T data)
			: base(name, data)
		{
		}

		public override BinaryTreeNode<T> getNode(string name)
		{
			if (m_name == name)
				return this;

			if (m_left != null)
				return m_left.getNode (name);
			if (m_right != null)
				return m_right.getNode (name);

			return null;
		}
		public override BinaryTreeNode<T> setNode(BinaryTreeNode<T> node)
		{
			if (m_now) 
			{
				if (m_right == null) 
				{
					m_right = setParent(node);
                    Console.WriteLine("[{0}] Set Node Right: {1}", Name, m_left.Name);
				}
				else
					m_right.setNode (node);
			} 
			else 
			{
				if (m_left == null) 
				{
					m_left = setParent(node);
                    Console.WriteLine("[{0}] Set Node Left: {1}", Name, m_left.Name);
				}
				else
					m_left.setNode (node);
			}

			m_now = !m_now;
			return this;
		}
        protected override BinaryTreeNode<T> setParent(BinaryTreeNode<T> node)
        {
            node.Parent = this;
            return node;
        }
		public override BinaryTreeNode<T> removeNode(BinaryTreeNode<T> node)
		{
			BinaryTreeNode<T> _node = node as BinaryTreeNode<T>;

			// fall 1 keine kinder
			if (_node.m_left == null && _node.m_right == null) 
			{
				_node.m_root = null;
				_node.Dispose ();
			}
			// fall 2 rechts sind kinder
			else if(_node.m_right != null && _node.m_left == null)
			{
				_node.m_root = _node.m_right;
				_node.Dispose ();
			}
			// fall 3 links sind kinder
			else if(_node.m_left != null && _node.m_right == null)
			{
				_node.m_root = _node.m_left;
				_node.Dispose ();
			}
			// fall 4 rechts und links sind kinder
			else if(_node.m_left != null && _node.m_right != null)
			{
				_node.m_left.setNode (_node.m_right);

				_node.m_root = _node.m_left;
				_node.Dispose ();
			}
			return this;
		}
		public override BinaryTreeNode<T> removeNode(string name)
		{
			return removeNode (getNode (name));
		}
		protected override void Dispose (bool disposing)
		{
			base.Dispose (disposing);

			if (disposing) 
			{
				if (m_left != null) 
				{
					m_left.Dispose (disposing);
				}
				if (m_right != null) 
				{
					m_right.Dispose (disposing);
				}
			}
		}
        public override void Travers(TraversOrder order, BinaryTreeNode<T> Root)
        {
            switch (order)
            {
                case TraversOrder.Inorder:
                    if (Root != null)
                    {
                        Travers(order, Root.m_left);
                        Console.Write(Root.Data + " ");
                        Travers(order, Root.m_right);
                    }
                    break;
                case TraversOrder.Postorder:
                    if (Root != null)
                    {
                        Travers(order, Root.m_left);
                        Travers(order, Root.m_right);
                        Console.Write(Root.Data + " ");
                    }
                    break;
                case TraversOrder.Preorder:
                    if (Root != null)
                    {
                        Console.Write(Root.Data + " ");
                        Travers(order, Root.m_left);
                        Travers(order, Root.m_right);
                    }
                    break;
            }
        }
	}
	public class BinaryTreeNode : BinaryTreeNode<Object>
	{
		public BinaryTreeNode (string name, Object data) : base(name, data) { }
	}
}

