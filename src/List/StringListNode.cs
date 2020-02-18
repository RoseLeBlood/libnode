//
//  StringListNode.cs
//
//  Author:
//       Amber-Sophia <ambersophia.schroeck@outlook.de>
//
//  Copyright (c) 2020 amber-sophia
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
using System.Text;
using ASF.Node;

namespace ASF.Node.List { 
    public class StringListNode : ListNode, IComparable, IFormattable {

        public StringListNode (string name, String data = null) : base (name, data) { }

        public override string ToString () {
            StringBuilder st = new StringBuilder (string.Format ("[{0}:{1}] ", Name, Data));
            if (m_nodes[1] != null)
                st.Append (string.Format ("Next: {0} ", m_nodes[1]));
            if (m_nodes[0] != null)
                st.Append (string.Format ("Prev: {0} ", m_nodes[0]));

            return st.ToString ();
        }

        #region IComparable implementation
        public virtual int CompareTo (object obj) {
            return ((IComparable) Data).CompareTo (obj);
        }
        #endregion

        #region IFormattable implementation
        public virtual string ToString (string format, IFormatProvider formatProvider) {
            return ((IFormattable) Data).ToString (format, formatProvider);
        }
        #endregion 
    }
}