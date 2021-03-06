//
//  SHA512BlockEntry.cs
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
using System.Security.Cryptography;

namespace ASF.Node.Block {
    [Serializable]
    public class SHA256BlockEntry<T> : GenericBlockEntry<T> {
        public SHA256BlockEntry (T data, String hash, Guid creater) : base (data, hash, creater) {  }
        public SHA256BlockEntry (T data, long timeStamp, ulong index, String prevHash, String hash,
                                    Guid creater) : base (data, timeStamp, index, prevHash, hash, creater) { }
        
        public SHA256BlockEntry (GenericBlockChain<T> root) : base (root) { }

        public SHA256BlockEntry (GenericBlockEntry<T> other) : base (other) { }

        protected override String calc_hash (string s) {
            return ASF.Node.Block.BlockUtils.GenSHA256 (s);
        }
    }
}