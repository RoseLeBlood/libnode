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
    public class ThreadNodeEntry : SHA512BlockEntry<ThreadNode> {
        public ThreadNodeEntry (ThreadNode data, Guid creater)  : base (data, creater) {  }
        public ThreadNodeEntry (ThreadNode data, String hash, Guid creater)  : base (data, hash, creater) {  }
    
        public override String update () {
            Hash = calc_hash (String.Format ("{0}{1}{2}{3}", RawEntry, TimeStamp, Index, PrevHash));
            return Hash;
        }
    }
    public class ThreadNode : GenericBlockChain<ThreadNode, ThreadNodeEntry> { 
        protected Thread m_pThread;

        public bool isAlive {
            get { return m_pThread.IsAlive; }
        }

        public ThreadNode (String hash, Guid OwnerGuid, int maxStatckSize = Int16.MaxValue) 
            : this (new ThreadNodeEntry (null, hash, OwnerGuid)) { 
                createThread(maxStatckSize); 
                Entry.RawEntry = this;
                Entry.update();
            }


        public ThreadNode (ThreadNodeEntry data, int maxStatckSize = Int16.MaxValue) 
            : base (data) { createThread(maxStatckSize); }

        public virtual void start(Object obj) {
            m_pThread.Start(obj);
        }
        
        public virtual void stop() {
            m_pThread.Abort();
        }

        public static void sleep(int ms) {
            Thread.Sleep(ms);
        }

        protected virtual void OnThread(Object obj) {

        }
        private void createThread(int stackSize) {
            m_pThread = new Thread(new ParameterizedThreadStart(OnThread), stackSize);
        }
    }
}