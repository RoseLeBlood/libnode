//
//  GenericBlockChain.cs
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

//using System.Text.Json;
//using System.Text.Json.Serialization;

using System.Collections.Generic;

namespace ASF.Node.Block {
    [Serializable]
    public class GenericBlockChain<T, ENTRY>
        : Node<ENTRY, GenericBlockChain<T, ENTRY>>,
        IEnumerable<ENTRY>,
        IList<ENTRY>,
        ICollection<ENTRY> where ENTRY : GenericBlockEntry<T> {

            public override GenericBlockChain<T, ENTRY> Root {
                get { return (Prev == null) ? this : m_nodes[0].Root; }
                protected set { Prev = value; }
            }
            public ENTRY this [int index] {
                get {
                    GenericBlockChain<T, ENTRY> root = Root;

                    do {
                        if ((int) root.Index == index)
                            return root.Data;
                        root = root.Next;
                    } while (root != null);
                    return null;
                }
                set { }
            }
            public int Count {
                get {
                    GenericBlockChain<T, ENTRY> root = this;
                    int count = 0;

                    do {
                        count++;

                        root = root.Next;
                    } while (root != null);
                    return count;
                }
            }
            public ulong Index {
                get {
                    GenericBlockChain<T, ENTRY> root = Root;
                    if (root.Name == Name)
                        return 0;

                    do {
                        if (root.Name == Name)
                            return Data.Index;

                        root = root.Next;
                    } while (root != null);
                    return 0;
                }
            }
            public bool IsReadOnly {
                get {
                    return false;
                }
            }
            
            public GenericBlockChain<T, ENTRY> Next {
                get { return m_nodes[1]; }
                protected set { m_nodes[1] = value; }
            }
            public GenericBlockChain<T, ENTRY> Prev {
                get { return m_nodes[0]; }
                protected set { m_nodes[0] = value; }
            }
            public GenericBlockChain (ENTRY data) : base (data.Hash, data, 2) { }

            public override GenericBlockChain<T, ENTRY> getNode (string hash) {
                if (this.Data.Hash == hash)
                    return this;

                if (Next != null)
                    return m_nodes[1].getNode (hash);
                if (Prev != null)
                    return m_nodes[0].getNode (hash);

                return null;
            }
            public override GenericBlockChain<T, ENTRY> setNode (GenericBlockChain<T, ENTRY> node) {
                if (Next == null) {
                    node.Prev = this;
                    node.Next = null;
                    node.Data.PrevHash = this.Data.Hash;
                    node.Data.Index = this.Data.Index + 1;

                    node.Name = node.Data.Hash;

                    m_nodes[1] = node;
                    OnSetNode (node);
                } else {
                    return m_nodes[1].setNode (node);
                }
                return this;
            }
            public override GenericBlockChain<T, ENTRY> removeNode (GenericBlockChain<T, ENTRY> node, ref bool removed) {
                removed = false;
                return this;
            }
            public override GenericBlockChain<T, ENTRY> removeNode (string name, ref bool removed) {
                removed = false;
                return this;
            }

            public override void Travers (TraversOrder order, GenericBlockChain<T, ENTRY> root) {
                /*if (Root != null && order == TraversOrder.ListOrder) {
                    Console.Write (Root.Data + " ");
                    if(root.Next != null) Travers (order, Root.Next);
                } else if (root != null && order == TraversOrder.ReservListOrder) {
                    Console.Write (Root.Data + " ");
                    if(root.Prev != null) Travers (order, root.Prev);
                }*/
            }
            public override void Travers (TraversOrder order, funcTravers travers, GenericBlockChain<T, ENTRY> chain) {
                
                if (order == TraversOrder.ListOrder) {
                    for(GenericBlockChain<T, ENTRY> root = chain; root != null; root = root.Next) {
                        travers (root);
                    }
                }
                else if (order == TraversOrder.ReservListOrder) {
                    for(GenericBlockChain<T, ENTRY> root = chain; root != null; root = root.Prev) {
                        travers (root);
                    }
                }                 
            }
            public virtual bool Transfer(string Hash, Guid Owner, Guid NewUser) {
                try {
                    GenericBlockChain<T, ENTRY> node = getNode(Hash);
                    ENTRY entry = node.Data; 
                    var lst = entry.Owners.Last as GenericBlockOwnerList;
                    var data = lst.Data;

                    TimeSpan ts = new TimeSpan (DateTime.Now.ToUniversalTime ().Ticks - (new DateTime (1970, 1, 1)).Ticks); // das Delta ermitteln

                    if(data.Owner != Owner) return false;
                    lst.setNode(new GenericBlockOwnerListEntry(Hash, NewUser, ts.TotalSeconds, data.Hash) );
                    
                } catch(Exception) {
                    return false;
                }
                
                return true;
            }

            public virtual bool IsGreaterThan (GenericBlockChain<T, ENTRY> other) {
                if (m_nodes[1] == null)
                    return false;

                ENTRY _a = m_nodes[1].Data;
                ENTRY _b = other.Data;

                return _a.IsGreaterThan (_b);
            }

            public static bool operator > (GenericBlockChain<T, ENTRY> a, GenericBlockChain<T, ENTRY> b) {
                return a.IsGreaterThan (b);
            }
            public static bool operator < (GenericBlockChain<T, ENTRY> a, GenericBlockChain<T, ENTRY> b) {
                return !a.IsGreaterThan (b);
            }

            public override List<ENTRY> ToList () {
                GenericBlockChain<T, ENTRY> root = Root;
                List<ENTRY> list = new List<ENTRY> ();

                do {
                    list.Add (root.Data);
                    root = root.Next;
                } while (root != null);

                return list;
            }

            #region IEnumerable implementation
            public System.Collections.IEnumerator GetEnumerator () {
                return GetEnumerator ();
            }

            IEnumerator<ENTRY> IEnumerable<ENTRY>.GetEnumerator () {
                GenericBlockChain<T, ENTRY> root = Root;

                do {
                    yield return root.Data;

                    root = root.Next;
                } while (root != null);
            }
            #endregion

            protected override void Dispose (bool disposing) {
                base.Dispose (disposing);

                if (disposing) {
                    if (Next != null)
                        m_nodes[1].Dispose (disposing);
                }
            }

            #region ICollection implementation
            public void Add (ENTRY item) {
                setNode (new GenericBlockChain<T, ENTRY> (item));
            }

            public void Clear () {
                throw new System.NotImplementedException ();
            }

            public bool Contains (ENTRY item) {
                return getNode (item.Hash) != null;
            }

            public void CopyTo (ENTRY[] array, int arrayIndex) {
                throw new System.NotImplementedException ();
            }

            public bool Remove (ENTRY item) {
                throw new System.NotImplementedException ();
            }
            #endregion

            #region IList implementation
            public int IndexOf (ENTRY item) {
                return (int) this.getNode (item.Hash).Index;
            }

            public ulong IndexOfEx (ENTRY item) {
                return this.getNode (item.Hash).Index;
            }

            public void Insert (int index, ENTRY item) {
                throw new System.NotImplementedException ();
            }

            public void RemoveAt (int index) {
                throw new System.NotImplementedException ();
            }

            #endregion 
            public override String ToString () {
                System.Text.StringBuilder st = new System.Text.StringBuilder ();

                GenericBlockChain<T, ENTRY> chain = this;

                do {
                    st.Append (chain.Data.ToString ());
                    if(chain.Next != null) st.Append(",\n");
                    chain = chain.Next;
                } while (chain != null);

                return st.ToString ();
            }
        }
    [Serializable]
    public class GenericBlockChain<T> : GenericBlockChain<T, SHA512BlockEntry<T>> {
        public GenericBlockChain (T data, String hash, Guid OwnerGuid) 
            : this (new SHA512BlockEntry<T> (data, hash, OwnerGuid)) { }

        public GenericBlockChain (SHA512BlockEntry<T> data) : base (data) { }
    }

}