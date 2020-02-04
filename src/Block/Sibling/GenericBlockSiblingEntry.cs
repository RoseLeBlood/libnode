//
//  GenericBlockSiblingEntry.cs
//
//  Author:
//       sophia <annasophia.schroeck@outlook.de>
//
//  Copyright (c) 2020 sophia
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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ASF.Node.List;

namespace ASF.Node.Block {
    public abstract class GenericBlockSiblingEntry<T> : GenericBlockEntry<T> {
        protected GenericBlockSiblingEntry<T> m_pSibling;
        protected bool m_bIsSibling;

        public GenericBlockSiblingEntry<T> Sibling {
            get { return m_pSibling; }
            protected set { m_pSibling = value; }
        }
        public bool IsSibling {
            get { return m_bIsSibling; }
            protected set { m_bIsSibling = value; }
        }

        public GenericBlockSiblingEntry () {
            m_pSibling = null;
            m_bIsSibling = false;
        }
        public GenericBlockSiblingEntry (T data) : base (data) { m_pSibling = null; m_bIsSibling = false; }

        public GenericBlockSiblingEntry (T data, String hash) : base (data, hash) { m_pSibling = null; m_bIsSibling = false; }

        protected GenericBlockSiblingEntry (T data, double timeStamp, ulong index, String prevHash, String hash) : base (data, timeStamp, index, prevHash, hash) { Sibling = null; m_bIsSibling = false; }

        public virtual GenericBlockSiblingEntry<T> addSiblingNode (GenericBlockSiblingEntry<T> node) {
            if (Sibling != null) {
                throw new System.Exception ("Entry has allready a sibling");
            } else {
                node.PrevHash = this.Hash;
                node.IsSibling = true;
                m_pSibling = node;
            }
            return this;
        }

        public override String update () {
            Hash = calc_hash (String.Format ("{0}{1}{2}{3}{4}", Data, TimeStamp, Index, PrevHash, m_pSibling));
            return Hash;
        }
        public override String ToString () {
            StringBuilder builder = new StringBuilder ();

            builder.AppendLine ("{");
            builder.AppendFormat ("\t\"Data\": \"{0}\",\n\t\"TimeStamp\": \"{1}\",\n\t\"Index\": \"{2}\",", Data, TimeStamp, Index);
            builder.AppendFormat ("\n\t\"Hash\": \"{0}\",\n\t\"PrevHash\": \"{1}\",\n\t\"IsSibling\": \"{2}\",", Hash, PrevHash, m_bIsSibling);
            if (m_bIsSibling) {
                builder.AppendFormat ("\n\t\"Sibling\": {0}", Sibling.ToString ());
            }
            builder.AppendLine ("\n},");

            return builder.ToString ();
        }
    }
}