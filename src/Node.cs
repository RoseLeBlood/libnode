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
using System.Collections.Generic;

namespace ASF.Node {
    public enum TraversOrder {
        Preorder,
        Inorder,
        Postorder,
        ListOrder,
        ReservListOrder
    }

    [Serializable]
    public abstract class Node<T, D> : Disposable
    //where T : class
    {
        public delegate void funcTravers (D node);

        protected string m_name;

        protected T m_data;
        protected D[] m_nodes;

        public string Name {
            get { return m_name; }
            set { m_name = value; }
        }
        public T Data {
            get { return m_data; }
            set { m_data = value; }
        }
        internal Node () { }
        protected Node (string name, int nodes) {
            m_name = name;
            m_nodes = new D[nodes];
        }
        protected Node (string name, T data, int nodes) {
            m_name = name;
            m_data = data;
            m_nodes = new D[nodes];
        }

        public abstract D Root { get; protected set; }

        public abstract D getNode (string name);
        public abstract D setNode (D node);
        public abstract D removeNode (D node, ref bool removed);
        public abstract D removeNode (string name, ref bool removed);

        public abstract void Travers (TraversOrder order, D Root);
        public abstract void Travers (TraversOrder order, funcTravers travers, D Root);
        public abstract List<T> ToList ();

        public override string ToString () {
            return string.Format ("[Node: Name={0}, Data={1}, Root={2}]", Name, Data, Root);
        }
        protected override void Dispose (bool disposing) {
            base.Dispose (disposing);
            if (disposing) {
                m_data = default (T);
            }
        }
        //protected abstract D setParent(D node);
        public virtual void OnSetNode (Node<T, D> node) { }
        public virtual void OnRemoveNode (Node<T, D> node) { }
    }

}