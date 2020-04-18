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
using ASF.Node.List;

namespace ASF.Node {
    [Serializable]    
    public class ProcessNode : ListNode<Process> {

        public ProcessNode Child {
            get; protected set;
        }

        public ProcessNode (string name, Process data) 
            : base(name, data) { Child = null; }

        public ProcessNode(string name)
            : base(name) { Data = new Process(); Child = null; }
        public ProcessNode(string name, ProcessStartInfo info)
            : base(name) { Data = new Process(); Data.StartInfo = info; Child = null; }
        public bool start() {
            return Data.Start();
        }
        public bool start(ProcessStartInfo info) {
            Data.StartInfo = info;
            return start();
        }
        public void close() {
            Data.Close();
        }
        public bool closeWindow() {
            return Data.CloseMainWindow();
        }
        public void kill(bool child) {
            if(Child != null && child) Child.kill(child);
            Data.Kill();
        }

        public override void OnSetNode (Node<Process, ListNode<Process>> node) { }
        public override void OnRemoveNode (Node<Process, ListNode<Process>> node) { }
    }
}