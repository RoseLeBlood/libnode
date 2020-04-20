//
//  ProzessNode.cs
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
using System;
using System.Diagnostics;
using ASF.Node.Block;

namespace ASF.Node {

    [Serializable] 
    public class ProcessNodeEntry : SHA512BlockEntry<Process> {

        public ProcessNode ChildProcess { get; set; }

        public ProcessNodeEntry (Process data, Guid creater)  : base (data, creater) {  }
        public ProcessNodeEntry (Process data, String hash, Guid creater)  : base (data, hash, creater) {  }
    
        public override String update () {
            Hash = calc_hash (String.Format ("{0}{1}{2}{3}", RawEntry, TimeStamp, Index, PrevHash));
            return Hash;
        }
    }

    [Serializable]    
    public class ProcessNode : GenericBlockChain<Process, ProcessNodeEntry> {

        public ProcessNode Child  {
            get { return Entry.ChildProcess; } 
            protected set { Entry.ChildProcess = value; }
        }

        public ProcessNode (Process process, String hash, Guid OwnerGuid) 
            : this (new ProcessNodeEntry (process, hash, OwnerGuid)) { Child = null; }

        public ProcessNode(string hash, ProcessStartInfo info, Guid OwnerGuid)
            : this(new Process(), hash, OwnerGuid) { 
                Entry.RawEntry.StartInfo = info; Child = null;
        }
        public ProcessNode (ProcessNodeEntry data) 
            : base (data) { }

        public bool start() {
            return Entry.RawEntry.Start();
        }
        public bool start(ProcessStartInfo info) {
            Entry.RawEntry.StartInfo = info;
            return start();
        }
        public void close() {
            Entry.RawEntry.Close();
        }
        public bool closeWindow() {
            return Entry.RawEntry.CloseMainWindow();
        }
        public void kill(bool child) {
            if(Child != null && child) Child.kill(child);
            Entry.RawEntry.Kill();
        }
        
        public ProcessNode addChild(ProcessNode node, bool start = true) {
            if(Child == null) {
                Child = node;
                if(start) Child.start();
                return Child; 
            } else {
                return Child.addChild(node, start);
            }
        }
    }
}