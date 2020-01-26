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
using System.IO;
using System.Text;

namespace ASF.Node.Block {
    public abstract class GenericBlockEntry<T>
    {
        public T      Data { get; internal set; } 
        public double   TimeStamp { get; internal set; }
        public ulong    Index { get; internal set; }

        public String   Hash { get; internal set; }
        public String   PrevHash { get; internal set; }

        public GenericBlockChain<Object> BlockChain { get; internal set; }

        public GenericBlockEntry() {

        }
        public GenericBlockEntry(T data) {
            Data = (data != null) ? data : default(T);
            TimeStamp = getTimeStamp();
            Index = 0;
            PrevHash = "";
            Hash = "NO_HASH";
            update();
        }
        public GenericBlockEntry(T data, String hash) {
            
            Data = (data != null) ? data : default(T);
            TimeStamp = getTimeStamp();
            Index = 0;
            Hash = hash;
            PrevHash = "";
            
        }
        protected GenericBlockEntry(T data, double timeStamp, ulong index, String prevHash, String hash) {
            Data= (data != null) ? data : default(T);
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
        public virtual String update() {
            Hash = calc_hash(String.Format("{0}{1}{2}{3}", Data, TimeStamp, Index, PrevHash));
            return Hash;
        }

        public virtual bool IsGreaterThan(GenericBlockEntry<T> other) {
            return (this.Index > other.Index && this.TimeStamp > other.TimeStamp);
        }

        public static implicit operator GenericBlockEntry<T>(GenericBlockChain<T> node) {
            return new SHA512BlockEntry<T>(node);
        }
        protected abstract String calc_hash(string s) ;

        protected virtual double getTimeStamp() {
            TimeSpan ts = new TimeSpan(DateTime.Now.ToUniversalTime().Ticks - (new DateTime(1970, 1, 1)).Ticks);  // das Delta ermitteln
   
            return ts.TotalSeconds;
        }
        public override String ToString() {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("{");
            builder.AppendFormat("\tData: {0},\n\tTimeStamp: {1}\n\tIndex: {2}", Data, TimeStamp, Index);
            builder.AppendFormat("\n\tHash: {0},\n\tPrevHash: {1}\n", Hash, PrevHash);
            builder.AppendLine("}");

            return builder.ToString();
        }
            
    }
}