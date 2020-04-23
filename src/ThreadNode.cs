//
//  ThreadNode.cs
//
//  Author:
//       Amber-Sophia Schroeck <ambersophia.schroeck@outlook.de>
//
//  Copyright (c) 2020 Amber-Sophia Schroeck
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
using System.Threading;
using ASF.Node.Block;

namespace ASF.Node {
    public class ThreadNodeEntry : SHA512BlockEntry<Thread> {
        private Object m_pThreadObject;

        public Object Parameter {
            get { return m_pThreadObject; }
        }
        

        public ThreadNodeEntry (Thread data, Guid creater, Object Arg = null)  
            : base (data, creater) {  m_pThreadObject = Arg; }
        public ThreadNodeEntry (Thread data, String hash, Guid creater, Object Arg = null)  
            : base (data, hash, creater) { m_pThreadObject = Arg;  }

        public override String update () {
            Hash = calc_hash (String.Format ("{0}{1}{2}{3}:{4}", RawEntry, TimeStamp, Index, PrevHash, m_pThreadObject));
            return Hash;
        }
    }
     public class ThreadNode : GenericBlockChain<Thread, ThreadNodeEntry> { 
    
        public int ThreadReturn { 
            get; set; 
        }
        public bool isAlive {
            get { return Entry.RawEntry.IsAlive; }
        }
        public static ThreadNode Current {
            get { return new ThreadNode(Thread.CurrentThread); }
        }

        public ThreadNode (String hash, Guid OwnerGuid, Object paramter, int maxStatckSize = Int16.MaxValue) 
            : this (new ThreadNodeEntry (new Thread(new ParameterizedThreadStart(static_OnThread), maxStatckSize), 
                                         hash, 
                                         OwnerGuid,
                                         paramter)) {  }
        public ThreadNode(Thread thr)
            : this (new ThreadNodeEntry (thr, Guid.NewGuid() ))  { }

        protected ThreadNode (ThreadNodeEntry data) 
            : base (data) { }

        public virtual void start() {
            Entry.RawEntry.Start(this);
        }
        
        public virtual void stop() {
            Entry.RawEntry.Abort();
        }

        public static void sleep(int ms) {
            Thread.Sleep(ms);
        }
        protected virtual int OnThread(Object obj) {
            return 0;
        }
        private static void static_OnThread(Object obj) {
            ThreadNode entry = (obj is ThreadNode) ? obj as ThreadNode : null;
            entry.ThreadReturn = entry.OnThread(entry.Entry.Parameter);
        }
    }
}