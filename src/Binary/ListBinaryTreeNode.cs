//
//  GenericListBinaryTreeNode.cs
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

using ASF.Node.List;

namespace ASF.Node.Binary {
    public class ListBinaryTreeNode<T> : BinaryTreeNode {
        public ListBinaryTreeNode (string name, ListNode<T> data = null) : base (name, data) { }

        public override BinaryTreeNode<object> getNode (string name) {
            if (m_name == name)
                return this;

            ListNode<T> list = Data as ListNode<T>;
            list = list.Root.getNode (name);

            if (list != null)
                return new BinaryTreeNode<object> (list.Name, list.Data);

            if (m_nodes[1] != null)
                return m_nodes[1].getNode (name);
            if (m_nodes[2] != null)
                return m_nodes[2].getNode (name);

            return null;
        }
        public override BinaryTreeNode<object> removeNode (string name, ref bool removed) {
            ListNode<T> list = Data as ListNode<T>;
            list.removeNode (name, ref removed);

            return removed ? this : base.removeNode (name, ref removed);
        }
        public override BinaryTreeNode<object> removeNode (BinaryTreeNode<object> node, ref bool removed) {
            ListNode<T> list = Data as ListNode<T>;
            list.removeNode (node.Name, ref removed);

            return removed ? this : base.removeNode (node, ref removed);
        }
        public virtual ListBinaryTreeNode<T> addToList (string name, T data) {
            return addToList (new ListNode<T> (name, data));
        }
        public virtual ListBinaryTreeNode<T> addToList (ListNode<T> data) {
            ListNode<T> list = Data as ListNode<T>;
            list.setNode (data);
            return this;
        }

    }
}