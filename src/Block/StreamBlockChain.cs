//
//  StreamBlockChain.cs
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

namespace ASF.Node.Block {

    public class StreamBlockChain : GenericBlockChain<Stream> {
        public virtual bool CanRead {
            get { return Stream.CanRead; }
        }

        public virtual bool CanSeek {
            get { return Stream.CanSeek; }
        }

        public virtual bool CanWrite {
            get { return Stream.CanWrite; }
        }

        public virtual long Length {
            get { return Stream.Length; }
        }

        public virtual long Position {
            get { return Stream.Position; }
            set { Stream.Position = value; }
        }

        public Stream Stream {
            get { return ((Stream) Data.Data); }
        }

        public StreamBlockChain (Stream data, String hash) : base (data, hash) { }

        public StreamBlockChain (SHA512BlockEntry<Stream> data) : base (data) { }

        public virtual void Flush () {
            Stream.Flush ();
        }

        public virtual int Read (byte[] buffer, int offset, int count) {
            return Stream.Read (buffer, offset, count);
        }

        public virtual long Seek (long offset, SeekOrigin origin) {
            return Stream.Seek (offset, origin);
        }

        public virtual void SetLength (long value) {
            Stream.SetLength (value);
        }

        public virtual void Write (byte[] buffer, int offset, int count) {
            Stream.Write (buffer, offset, count);
        }
    }
}