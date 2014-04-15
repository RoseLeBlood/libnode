//
//  Node.cs
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
    public enum TraversOrder
    {
        Preorder,
        Inorder,
        Postorder
    }

        
	public abstract class Node<T, D> : Disposable
		where T : class
	{
        public delegate void OnTravers(Node<T,D> node, Object o); 

		protected string m_name;

		protected T      m_data;
        protected D[]     m_nodes;

        public abstract D this [int value]
        { 
            get;
        }

		public string Name 
		{ 
			get { return m_name; } 
			set { m_name = value; }
		}
		public T Data
		{
			get { return m_data; }
			set { m_data = value; }
		}
		protected Node (string name, int nodes) 
		{
			m_name = name;
            m_nodes = new D[nodes ];
		}
		protected Node(string name, T data, int nodes)
		{
			m_name = name;
			m_data = data;
            m_nodes = new D[nodes ];
		}
			
		public virtual D Root { get; protected set; }

		public abstract D getNode(string name);
		public abstract D setNode(D node);
		public abstract D removeNode(D node);
		public abstract D removeNode(string name);

        public abstract void Travers(TraversOrder order, D Root);
        public abstract void Travers(OnTravers travers, D Root);

       
		public override string ToString ()
		{
			return string.Format ("[Node: Name={0}, Data={1}, Root={2}]", Name, Data, Root);
		}
		protected override void Dispose (bool disposing)
		{
			base.Dispose (disposing);
			if (disposing)
			{
				m_data = null;
			}
		}
        protected abstract D setParent(D node);
	}
}

