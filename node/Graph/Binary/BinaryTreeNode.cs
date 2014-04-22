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
using System.Collections.Generic;

namespace node
{
    public class GenericTreeNodeEntry<T>
    {
        public string Name { get; set; }
        public T      Data { get; set; }

        public GenericTreeNodeEntry(ListNode<T> root)
            : this(root.Name, root.Data)
        {
        }
        public GenericTreeNodeEntry(string name, T data)
        {
            Name = name;
            Data = data;
        }


        public static implicit operator GenericTreeNodeEntry<T>(BinaryTreeNode<T> node)
        {
            return new GenericTreeNodeEntry<T>(node.Name, node.Data);
        }
        
    }
    [Serializable]
	public class BinaryTreeNode<T> : Node<T, BinaryTreeNode<T>>, IEnumerable<T>, IList<GenericTreeNodeEntry<T>>
	{
		internal bool m_now = false;

        public int Count
        {
            get
            {
                return this.ToList().Count;
            }
        }
        public GenericTreeNodeEntry<T> this[int index]
        {
            get
            {
                return _ToList()[index];
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public int Depth
        {
            get
            {
                int depth = 0;
                BinaryTreeNode<T> node = this;
                while(node.Parent != null)
                {
                    node = node.Parent;
                    depth++;
                }
                return depth;
            }
        }

		public override BinaryTreeNode<T> Root
        {
            get
            {
                if (m_nodes [0] == null)
                    return this;
                else
                    return m_nodes [0].Root;
            }
            protected set
            {
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

        public BinaryTreeNode()
        {

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
					node.Parent = this;
                    m_nodes[2] = node;
                    Console.WriteLine("[{0}] Set Node Right: {1}", Name, m_nodes[2].Name);
				}
				else
					m_nodes[2].setNode (node);
			} 
			else 
			{
				if (m_nodes[1] == null) 
				{
                    node.Parent = this;
					m_nodes[1] = node;
                    Console.WriteLine("[{0}] Set Node Left: {1}", Name, m_nodes[1].Name);
				}
				else
					m_nodes[1].setNode (node);
			}

			m_now = !m_now;
			return this;
		}

		public override BinaryTreeNode<T> removeNode(BinaryTreeNode<T> node, ref bool removed)
		{
			BinaryTreeNode<T> _node = node as BinaryTreeNode<T>;
            removed = false;
			// fall 1 keine kinder
			if (_node.m_nodes[1] == null && _node.m_nodes[2] == null) 
			{
				_node.m_nodes[0] = null;
				_node.Dispose ();
                removed = true;
			}
			// fall 2 rechts sind kinder
			else if(_node.m_nodes[2] != null && _node.m_nodes[1] == null)
			{
				_node.m_nodes[0] = _node.m_nodes[2];
				_node.Dispose ();
                removed = true;
			}
			// fall 3 links sind kinder
			else if(_node.m_nodes[1] != null && _node.m_nodes[2] == null)
			{
				_node.m_nodes[0] = _node.m_nodes[1];
				_node.Dispose ();
                removed = true;
			}
			// fall 4 rechts und links sind kinder
			else if(_node.m_nodes[1] != null && _node.m_nodes[2] != null)
			{
				_node.m_nodes[1].setNode (_node.m_nodes[2]);

				_node.m_nodes[0] = _node.m_nodes[1];
				_node.Dispose ();
                removed = true;
			}
			return this;
		}
		public override BinaryTreeNode<T> removeNode(string name, ref bool removed)
		{
			return removeNode (getNode (name), ref removed);
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

        public override void Travers(TraversOrder order, funcTravers travers, BinaryTreeNode<T> root)
        {

            if (travers == null)
                throw new ArgumentNullException("travers");

          
            switch (order)
            {
                case TraversOrder.Inorder:
                    if (root != null)
                    {
                        Travers(order, travers, root.m_nodes [1]);
                        travers(root);
                        Travers(order, travers, root.m_nodes [2]);
                    }
                    break;
                case TraversOrder.Postorder:
                    if (root != null)
                    {
                        Travers(order, travers, root.m_nodes [1]);
                        Travers(order, travers, root.m_nodes [2]);
                        travers(root);
                    }
                    break;
                case TraversOrder.Preorder:
                    if (root != null)
                    {
                        travers(root);
                        Travers(order, travers, root.m_nodes [1]);
                        Travers(order, travers, root.m_nodes [2]);
                    }
                    break;
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
        public virtual bool IsGreaterThan(BinaryTreeNode b)
        {
            if(m_nodes [1] == null)
                return false;

            Object _a = ((Object)m_nodes [1].Data);
            Object _b = ((Object)b.Data);

            if (_a.IsNumber() && _b.IsNumber())
            {

                return (Convert.ToDecimal(_a)) > (Convert.ToDecimal(_b));

            }
            return false;
        }
        public override List<T> ToList()
        {
            List<T> liste = new List<T>();

            addToList(this, ref liste);
            return liste;
        }

        protected void addToList(BinaryTreeNode<T> root, ref List<T> liste)
        {
            if (root != null)
            {
                liste.Add(root.Data);
                addToList(root.Left, ref liste);
                addToList(root.Right, ref liste);
            }
        }
        public static bool operator > (BinaryTreeNode<T> a, BinaryTreeNode<T> b)
        {
            return a.IsGreaterThan(b as BinaryTreeNode);
        }
        public static bool operator < (BinaryTreeNode<T> a, BinaryTreeNode<T> b)
        {
            return !a.IsGreaterThan(b as BinaryTreeNode);
        }

        public static implicit operator BinaryTreeNode<T>(ListNode<T> node)
        {
            ListNode<T> _root = node;
            BinaryTreeNode<T> _new = new BinaryTreeNode<T>();

            do
            {
                _new.setNode(new BinaryTreeNode<T>(node.Name, node.Data));
                _root = _root.Next;
            } while (_root != null);

            return _new;
        }
        #region IEnumerable implementation
        public System.Collections.IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region IEnumerable implementation
        private List<GenericTreeNodeEntry<T>> _ToList()
        {
            List<GenericTreeNodeEntry<T>> liste = new List<GenericTreeNodeEntry<T>>();

            _addToList(this, ref liste);
            return liste;
        }

        private void _addToList(BinaryTreeNode<T> root, ref List<GenericTreeNodeEntry<T>> liste)
        {
            if (root != null)
            {
                liste.Add(new GenericTreeNodeEntry<T>(root.Name, root.Data));
                _addToList(root.Left, ref liste);
                _addToList(root.Right, ref liste);
            }
        }
        IEnumerator<GenericTreeNodeEntry<T>> IEnumerable<GenericTreeNodeEntry<T>>.GetEnumerator()
        {
            List<GenericTreeNodeEntry<T>> list = Root._ToList();
            return list.GetEnumerator();
        }
        #endregion

        #region ICollection implementation
        public void Add(GenericTreeNodeEntry<T> item)
        {
            setNode(new BinaryTreeNode<T>( item.Name, item.Data));
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(GenericTreeNodeEntry<T> item)
        {
            return getNode(item.Name) != null;
        }

        public void CopyTo(GenericTreeNodeEntry<T>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(GenericTreeNodeEntry<T> item)
        {
            bool removed = false;
            removeNode(item.Name, ref removed);
            return removed;
        }


        #endregion

        #region IList implementation
        public int IndexOf(GenericTreeNodeEntry<T> item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, GenericTreeNodeEntry<T> item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }


        #endregion  


        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.ToList().GetEnumerator();
        }
       
	}
	public class BinaryTreeNode : BinaryTreeNode<Object>
	{
		public BinaryTreeNode (string name, Object data) : base(name, data) { }
	}
}

