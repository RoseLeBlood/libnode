//
//  ListNode.cs
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
using System.Collections;
using ASF.Node;

namespace ASF.Node.List
{
    public class GenericListEntry<T>
    {
        public string Name { get; set; }
        public T      Data { get; set; }

        public GenericListEntry(ListNode<T> root)
            : this(root.Name, root.Data)
        {
        }
        public GenericListEntry(string name, T data)
        {
            Name = name;
            Data = data;
        }


        public static implicit operator GenericListEntry<T>(ListNode<T> node)
        {
            return new GenericListEntry<T>(node.Name, node.Data);
        }
        
    }

    public class ListNode<T>  : Node<T, ListNode<T>>, IEnumerable<T>, IList<GenericListEntry<T>>
    {
        public override ListNode<T> Root
        {
            get
            {
                if(Prev == null)
                    return this;
                else
                    return Prev.Root;
            }
            protected set
            {
                Prev = value;
            }
        }
        public GenericListEntry<T> this[int index]
        {
            get
            {
                ListNode<T> root = Root;

                do
                {
                    if(root.Index == index )
                        return new GenericListEntry<T>(root);

                    root = root.Next;
                } while (root != null);
                return null;
            }
            set
            {
                ListNode<T> root = Root;
                if(root.Index == index)
                    root.Data = value.Data;

                do
                {
                    if(root.Index == index )
                        root.Data = value.Data;

                    root = root.Next;
                } while (root != null);
            }
        }
        public int Count
        {
            get
            {
                ListNode<T> root = this;
                int count = 0;

                do
                {
                    count++;

                    root = root.Next;
                } while (root != null);
                return count;
            }
        }
        public int Index
        {
            get
            {
                ListNode<T> root = Root;
                if(root.Name == Name)
                        return 0;

                int index = 0;

                do
                {
                    index++;

                    if(root.Name == Name )
                        return index;

                    root = root.Next;
                } while (root != null);
                return -1;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public ListNode<T> Next
        {
            get { return m_nodes [1]; }
            set { m_nodes [1] = value; }
        }
        public ListNode<T> Prev
        {
            get { return m_nodes [0]; }
            set { m_nodes [0] = value; }
        }

        public ListNode(string name)
            : base(name, 2)
        {
        }
        public ListNode(string name, T data)
            : base(name, data, 2)
        {

        }
        public override ListNode<T> getNode(string name)
        {
            if(this.Name == name)
                return this;

            if(Next != null)
                return Next.getNode(name);
            if(Prev !=null)
                return Prev.getNode(name);

            return null;
        }

        public override ListNode<T> setNode(ListNode<T> node)
        {
            if (Next == null)
            {
                node.Prev = this;
                Next = node;
                Console.WriteLine("[{0}] Set Node Next: {1}", Data, Next.Data);
            } 
            else
            {
                Next.setNode(node);
            }
            return this;
        }

        public override ListNode<T> removeNode(ListNode<T> node, ref bool removed)
        {
            removed = false;

            if(node == null)
                return this;

            if (node.Prev != null && node.Next != null)
            {
                node.Prev = node.Next;
                removed = true;
            }
            else if (node.Prev != null && node.Next == null)
            {
                node.Prev.Next = null;
                removed = true;
            }
            else if (node.Prev == null && node.Next != null)
            {
                node.Next.Prev = null;
                removed = true;
            }
            return this;
        }

        public override ListNode<T> removeNode(string name, ref bool removed)
        {
            return removeNode(getNode(name), ref removed);
        }

        public override void Travers(TraversOrder order, ListNode<T> Root)
        {
            if (Root != null && order == TraversOrder.ListOrder)
            {
                Console.Write(Root.Data + " ");
                Travers(order, Root.Next);
            }
        }

        public override void Travers(TraversOrder order, funcTravers travers, ListNode<T> root)
        {
            if (root != null && order == TraversOrder.ListOrder)
            {
                travers(root.Next);
                Travers(order,travers, root.Next);
            }
            if (root != null && order == TraversOrder.ReservListOrder)
            {
                travers(root.Next);
                Travers(order,travers, root.Prev);
            }
        }    
        public override List<T> ToList()
        {
            ListNode<T> root = Root;
            List<T> list = new List<T>();

            do
            {
                list.Add(root.Data);
 
                root = root.Next;
            } while (root != null);

            return list;
        }

        #region IEnumerable implementation
        public System.Collections.IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
  
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            ListNode<T> root = Root;

            do
            {
                yield return root.Data;

                root = root.Next;
            } while (root != null);
        }
        #endregion


        #region ICollection implementation
        public void Add(GenericListEntry<T> item)
        {
            setNode(new ListNode<T>(item.Name, item.Data));
        }

        public void Clear()
        {
            this.Dispose(true);
        }

        public bool Contains(GenericListEntry<T> item)
        {
            return getNode(item.Name) != null;
        }

        public void CopyTo(GenericListEntry<T>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(GenericListEntry<T> item)
        {
            if(getNode(item.Name) == null)
                return false;

            bool removed = false;
            removeNode(item.Name, ref removed);
            return removed;
        }


        #endregion

        #region IList implementation
        public int IndexOf(GenericListEntry<T> item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, GenericListEntry<T> item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }


        #endregion        

        IEnumerator<GenericListEntry<T>> IEnumerable<GenericListEntry<T>>.GetEnumerator()
        {
            ListNode<T> root = Root;

            do
            {
                yield return new GenericListEntry<T>(root.Name, root.Data);

                root = root.Next;
            } while (root != null);
        }
       
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (Next != null)
                    Next.Dispose(disposing);
            }
        }

    }
    public class ListNode : ListNode<Object>
    {
        public ListNode (string name, Object data) : base(name, data) { }

    }
}

