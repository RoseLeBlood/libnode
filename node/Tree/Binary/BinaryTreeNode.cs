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

        public override BinaryTreeNode<T> this[int value]
        {
            get
            {
                return m_nodes[value];
            }
        }
		public override BinaryTreeNode<T> Root 
		{
			get
			{
				if (m_nodes[0] == null)
					return this;
				else
					return m_nodes[0].Root;
			}
		}
        public BinaryTreeNode<T> Parent 
        {
            get { return m_nodes[0]; }
            set { m_nodes[0] = value; }
        }
		public BinaryTreeNode<T> Right 
		{
			get { return m_nodes[2]; }
		}
		public BinaryTreeNode<T> Left
		{
			get { return m_nodes[1]; }
		}


		public BinaryTreeNode (string name)
			: base(name, 3) // 0: root, 1: left, 2:right
		{

		}
		public BinaryTreeNode (string name, T data)
			: base(name, data, 3)
		{
		}

		public override BinaryTreeNode<T> getNode(string name)
		{
			if (m_name == name)
				return this;

			if (m_nodes[1] != null)
				return m_nodes[1].getNode (name);
			if (m_nodes[2] != null)
				return m_nodes[2].getNode (name);

			return null;
		}
		public override BinaryTreeNode<T> setNode(BinaryTreeNode<T> node)
		{
			if (m_now) 
			{
				if (m_nodes[2] == null) 
				{
					m_nodes[2] = setParent(node);
                    Console.WriteLine("[{0}] Set Node Right: {1}", Name, m_nodes[2].Name);
				}
				else
					m_nodes[2].setNode (node);
			} 
			else 
			{
				if (m_nodes[1] == null) 
				{
					m_nodes[1] = setParent(node);
                    Console.WriteLine("[{0}] Set Node Left: {1}", Name, m_nodes[1].Name);
				}
				else
					m_nodes[1].setNode (node);
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
			if (_node.m_nodes[1] == null && _node.m_nodes[2] == null) 
			{
				_node.m_nodes[0] = null;
				_node.Dispose ();
			}
			// fall 2 rechts sind kinder
			else if(_node.m_nodes[2] != null && _node.m_nodes[1] == null)
			{
				_node.m_nodes[0] = _node.m_nodes[2];
				_node.Dispose ();
			}
			// fall 3 links sind kinder
			else if(_node.m_nodes[1] != null && _node.m_nodes[2] == null)
			{
				_node.m_nodes[0] = _node.m_nodes[1];
				_node.Dispose ();
			}
			// fall 4 rechts und links sind kinder
			else if(_node.m_nodes[1] != null && _node.m_nodes[2] != null)
			{
				_node.m_nodes[1].setNode (_node.m_nodes[2]);

				_node.m_nodes[0] = _node.m_nodes[1];
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
				if (m_nodes[1] != null) 
				{
					m_nodes[1].Dispose (disposing);
				}
				if (m_nodes[2] != null) 
				{
					m_nodes[2].Dispose (disposing);
				}
			}
		}
        public override void Travers(OnTravers travers, BinaryTreeNode<T> Root = null)
        {
            if (travers != null)
            {
                travers(this, Root == null ? this.Data : Root.Data);
            }
        }
        public override void Travers(TraversOrder order, BinaryTreeNode<T> Root)
        {
            switch (order)
            {
                case TraversOrder.Inorder:
                    if (Root != null)
                    {
                        Travers(order, Root.m_nodes[1]);
                        Console.Write(Root.Data + " ");
                        Travers(order, Root.m_nodes[2]);
                    }
                    break;
                case TraversOrder.Postorder:
                    if (Root != null)
                    {
                        Travers(order, Root.m_nodes[1]);
                        Travers(order, Root.m_nodes[2]);
                        Console.Write(Root.Data + " ");
                    }
                    break;
                case TraversOrder.Preorder:
                    if (Root != null)
                    {
                        Console.Write(Root.Data + " ");
                        Travers(order, Root.m_nodes[1]);
                        Travers(order, Root.m_nodes[2]);
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

