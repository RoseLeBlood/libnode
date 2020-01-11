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
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using ASF.Node.List;

namespace ASF.Node.Block {
    public abstract class GenericBlockSiblingEntry<T> : GenericBlockEntry<T> {

        public GenericBlockSiblingEntry<T> Sibling { get; internal set; } 
        public bool IsSibling { get; internal set; }

        public GenericBlockSiblingEntry() {
            Sibling = null;
        }
        public GenericBlockSiblingEntry(T data) 
            : base(data) { Sibling = null; }

        public GenericBlockSiblingEntry(T data, String hash)
            : base(data, hash) { Sibling = null; }

        protected GenericBlockSiblingEntry(T data, double timeStamp, ulong index, String prevHash, String hash) 
            : base(data, timeStamp, index, prevHash, hash) { Sibling = null; }

        public virtual GenericBlockSiblingEntry<T> addSiblingNode(GenericBlockSiblingEntry<T> node) {
            if(Sibling != null) {
               throw new System.Exception("Entry has allready a sibling");
            } else {
                node.PrevHash = this.Hash;
                node.IsSibling = true;
                Sibling = node;
            }
            return this;
        }

        public override String update() {
            using (StreamWriter writer = new StreamWriter(new MemoryStream())) {
                writer.WriteLine("{0}:{1}:{2}:{3}:{4}", Data, TimeStamp, PrevHash, Index, IsSibling);
                writer.Flush();

                var hashValue = calc_hash(writer.BaseStream);

                StringBuilder st = new StringBuilder() ;
                    foreach (byte value in hashValue) 
                        st.Append(string.Format(":{0}", value ));
                    Hash = st.ToString();
                
            }   
            return Hash;
        }
    }
}