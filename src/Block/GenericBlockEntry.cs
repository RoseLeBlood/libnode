//
//  GenericBlockEntry.cs
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
using System.Collections.Generic;
using System.Collections;
using ASF.Node.List;

namespace ASF.Node.Block {
    public class GenericBlockEntry<T>
    {
        private static ulong m_iIndex = 0;

        public T      Data { get; internal set; }
        public long   TimeStamp { get; internal set; }
        public ulong    Index { get; internal set; }

        public String   Hash { get; internal set; }
        public String   PrevHash { get; internal set; }

        public GenericBlockEntry() {

        }
        public GenericBlockEntry(T data, long timeStamp) {
            Data = data;
            TimeStamp = timeStamp;
            Index = (++m_iIndex);
            PrevHash = "";
            calc_hash();
        }
        public GenericBlockEntry(T data, String hash) {
            Data = data;
            TimeStamp = 0;
            Index = (++m_iIndex);
            Hash = hash;
            PrevHash = "";
        }
        protected GenericBlockEntry(T data, long timeStamp, ulong index, String prevHash, String hash) {
            Data = data;
            TimeStamp = timeStamp;
            Index = index;
            Hash = hash;
            PrevHash = "";
        }

        public GenericBlockEntry(GenericBlockChain<T> root) 
            : this(root.Data) {

        }

        public GenericBlockEntry(GenericBlockEntry<T> other) 
            : this(other.Data, 
                   other.TimeStamp, 
                   other.Index, 
                   other.PrevHash,
                   other.Hash) {

        }
        public String update() {
            calc_hash();
            return Hash;
        }

        public virtual bool IsGreaterThan(GenericBlockEntry<T> other) {
            return (this.Index > other.Index && this.TimeStamp > other.TimeStamp);
        }

        public static implicit operator GenericBlockEntry<T>(GenericBlockChain<T> node) {
            return new GenericBlockEntry<T>(node);
        }
        protected virtual void calc_hash() {
            //Hash = Data + TimeStamp + PrevHash + Index + Name;
        }
    }
}