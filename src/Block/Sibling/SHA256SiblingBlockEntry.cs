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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using ASF.Node.List;

namespace ASF.Node.Block {
    public class SHA256SiblingBlockEntry<T> : GenericBlockSiblingEntry<T> {
        public SHA256SiblingBlockEntry (T data, String hash) : base (data, hash) { }
        protected SHA256SiblingBlockEntry (T data, long timeStamp, ulong index, String prevHash, String hash) : base (data, timeStamp, index, prevHash, hash) { }
        protected override String calc_hash (string s) {
            return ASF.Node.Block.BlockUtils.GenSHA256 (s);
        }
    }
}