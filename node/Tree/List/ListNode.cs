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

namespace node
{
    public class ListNode<T>  : Node<T, ListNode<T>>
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

        public override ListNode<T> this[int value]
        {
            get
            {
                return m_nodes[value];
            }
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

        public override ListNode<T> removeNode(ListNode<T> node)
        {
            if(node == null)
                return this;

            if (node.Prev != null && node.Next != null)
            {
                node.Prev = node.Next;
            }
            else if (node.Prev != null && node.Next == null)
            {
                node.Prev.Next = null;
            }
            else if (node.Prev == null && node.Next != null)
            {
                node.Next.Prev = null;
            }
            return this;
        }

        public override ListNode<T> removeNode(string name)
        {
            return removeNode(getNode(name));
        }

        public override void Travers(TraversOrder order, ListNode<T> Root)
        {
            if (Root != null && order == TraversOrder.ListOrder)
            {
                Console.Write(Root.Data + " ");
                Travers(order, Root.Next);
            }
        }

        public override void Travers(Node<T, ListNode<T>>.funcTravers travers, ListNode<T> Root)
        {
            throw new System.NotImplementedException();
        }

    }
    public class ListNode : ListNode<Object>
    {
        public ListNode (string name, Object data) : base(name, data) { }

        public override void Travers(funcTravers travers, ListNode<object> Root)
        {
            if (travers != null && Root != null)
            {
                travers(this.Data, Root.m_nodes);
            }
        }

    }
}

