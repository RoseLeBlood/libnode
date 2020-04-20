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
using ASF.Node.List;

namespace ASF.Node.Block {
    [Serializable]
    public abstract class GenericBlockEntry<T> {
        public T RawEntry { get; internal set; }
        public double TimeStamp { get; internal set; }
        public ulong Index { get; internal set; }

        public String Hash { get; internal set; }
        public String PrevHash { get; internal set; }

        public Guid CreateUuid { get; internal set; }

        public GenericBlockOwnerList Owners { get; set; }

        public bool IsValid { get { return isValid (); } }

        public GenericBlockEntry () {

        }
        public GenericBlockEntry (T data, Guid creater) {
            RawEntry = (data != null) ? data : default (T);
            TimeStamp = getTimeStamp ();
            Index = 0;
            PrevHash = "";
            Hash = "NO_HASH";
            CreateUuid = creater;
            update ();

            Owners = new GenericBlockOwnerList(Hash, new GenericBlockOwnerListEntry(Hash, creater, TimeStamp));
        }
        public GenericBlockEntry (T data, String hash, Guid creater) {

            RawEntry = (data != null) ? data : default (T);
            TimeStamp = getTimeStamp ();
            Index = 0;
            Hash = hash;
            PrevHash = "";
            CreateUuid = creater;
            Owners = new GenericBlockOwnerList(Hash, new GenericBlockOwnerListEntry(Hash, creater, TimeStamp));

        }
        protected GenericBlockEntry (T data, double timeStamp, ulong index, String prevHash, String hash,
                                    Guid creater ) {
            RawEntry = (data != null) ? data : default (T);
            TimeStamp = timeStamp;
            Index = index;
            Hash = hash;
            PrevHash = "";
            CreateUuid = creater;
            Owners = new GenericBlockOwnerList(Hash, new GenericBlockOwnerListEntry(Hash, creater, TimeStamp));
        }

        public GenericBlockEntry (GenericBlockChain<T> root) : this (root.Entry) {

        }

        public GenericBlockEntry (GenericBlockEntry<T> other) : this (other.RawEntry,
            other.TimeStamp,
            other.Index,
            other.PrevHash,
            other.Hash,
            other.CreateUuid) {

        }
        public virtual String update () {
            Hash = calc_hash (String.Format ("{0}{1}{2}{3}:{4}", 
                RawEntry, TimeStamp, Index, PrevHash, CreateUuid));
            return Hash;
        }

        public virtual bool IsGreaterThan (GenericBlockEntry<T> other) {
            return (this.Index > other.Index && this.TimeStamp > other.TimeStamp);
        }

        public static implicit operator GenericBlockEntry<T> (GenericBlockChain<T> node) {
            return new SHA512BlockEntry<T> (node);
        }
        protected abstract String calc_hash (string s);

        protected virtual double getTimeStamp () {
            TimeSpan ts = new TimeSpan (DateTime.Now.ToUniversalTime ().Ticks - (new DateTime (1970, 1, 1)).Ticks); // das Delta ermitteln

            return ts.TotalSeconds;
        }
        public override String ToString () {
            StringBuilder builder = new StringBuilder ();

            builder.Append ("{");
            builder.AppendFormat ("\t\"RawEntry\": \"{0}\",\n\t\"TimeStamp\": \"{1}\",\n\t\"Index\": \"{2}\",", RawEntry, TimeStamp, Index);
            builder.AppendFormat ("\n\t\"Hash\": \"{0}\",\n\t\"PrevHash\": \"{1}\",\n", Hash, PrevHash);
            builder.AppendFormat ("\n\t\"Creater\": \"{0}\",", CreateUuid);
            
            builder.AppendFormat ("\n\t\"Transfers\": {0}", Owners.ToString());

            builder.AppendLine ("\n},");

            return builder.ToString ();
        }
        public bool isValid () {
            string _hash = calc_hash (String.Format ("{0}{1}{2}{3}:{4}", 
                RawEntry, TimeStamp, Index, PrevHash, CreateUuid));
            return Hash == _hash;
        }

    }
}