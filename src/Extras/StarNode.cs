//
//  StarNode.cs
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
using ASF.Node.List;

namespace ASF.Node.Extras {
    public class StarNode<T> : Node<T, StarNode<T>> {
        private ListNode<StarNode<T>> m_objects;

        public override StarNode<T> Root {
            get {
                return m_nodes[0];
            }
            protected set {
                if (m_nodes[0] == null) {
                    m_nodes[0] = value;
                } else {
                    m_nodes[0].setNode (value);
                }
            }
        }
        public bool IsRoot {
            get { return Root == null; }
        }

        public StarNode (string name, T data) : base (name, data, 1) {
            m_objects = new ListNode<StarNode<T>> ("/");
        }

        public override StarNode<T> getNode (string name) {
            if (this.Name == name)
                return this;

            if (Root != null) {
                return Root.getNode (name);
            }
            return m_objects.getNode (name).Data;
        }

        public override StarNode<T> setNode (StarNode<T> node) {
            if (getNode (node.Name) != null)
                return this;

            if (Root == null) {
                node.Root = this;
                OnSetNode (node);

                m_objects.setNode (new ListNode<StarNode<T>> (node.Name, node));
            }

            return this;
        }

        public override StarNode<T> removeNode (StarNode<T> node, ref bool removed) {
            if (Root == null) {
                m_objects.removeNode (node.Name, ref removed);
            }
            if (removed) OnRemoveNode (node);
            return this;
        }

        public override StarNode<T> removeNode (string name, ref bool removed) {
            StarNode<T> node = getNode (name);
            return removeNode (node, ref removed);
        }

        public override void Travers (TraversOrder order, StarNode<T> root) {
            if (root != null) {
                Console.WriteLine ("Stargraph IsRoot: {0}", root.IsRoot);
                if (root.IsRoot)
                    m_objects.Travers (order, root.m_objects);
            }
        }

        public override void Travers (TraversOrder order, funcTravers travers, StarNode<T> root) {
            if (root != null) {
                travers (root);
                if (root.IsRoot)
                    m_objects.Travers (order, root.m_objects);
            }
        }

        public override System.Collections.Generic.List<T> ToList () {
            System.Collections.Generic.List<T> list = new System.Collections.Generic.List<T> ();
            list.Add (this.Data);

            if (Root == null) {
                foreach (var item in m_objects.ToList ()) {
                    list.Add (item.Data);
                }
            }
            return list;
        }
    }
}