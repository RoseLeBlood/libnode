//
//  ValueSiblingBlockChain.cs
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
using System.Numerics;
using System.Text;

namespace ASF.Node.Block {
    [Serializable]
    public class ValueSiblingBlockChain<D> : GenericSiblingBlockChain<D>, IComparable, IConvertible, IFormattable, IComparable<D>, IEquatable<D>
        where D : IComparable, IConvertible, IFormattable, IComparable<D>, IEquatable<D> {
            public D Value {
                get { return m_data.RawEntry; }
            }
            public ValueSiblingBlockChain (D data, String hash, Guid OwnerGuid) : base (data, hash, OwnerGuid) { }
            public ValueSiblingBlockChain (SHA512SiblingBlockEntry<D> data) : base (data) { }

            #region IComparable implementation
            public virtual int CompareTo (object obj) {
                return Value.CompareTo (obj);
            }
            #endregion    

            #region IConvertible implementation
            public virtual TypeCode GetTypeCode () {
                return Value.GetTypeCode ();
            }

            public virtual bool ToBoolean (IFormatProvider provider) {
                return Value.ToBoolean (provider);
            }

            public virtual byte ToByte (IFormatProvider provider) {
                return Value.ToByte (provider);
            }

            public virtual char ToChar (IFormatProvider provider) {
                return Value.ToChar (provider);
            }

            public virtual DateTime ToDateTime (IFormatProvider provider) {
                return Value.ToDateTime (provider);
            }

            public virtual decimal ToDecimal (IFormatProvider provider) {
                return Value.ToDecimal (provider);
            }

            public virtual double ToDouble (IFormatProvider provider) {
                return Value.ToDouble (provider);
            }

            public virtual short ToInt16 (IFormatProvider provider) {
                return Value.ToInt16 (provider);
            }

            public virtual int ToInt32 (IFormatProvider provider) {
                return Value.ToInt32 (provider);
            }

            public virtual long ToInt64 (IFormatProvider provider) {
                return Value.ToInt64 (provider);
            }

            public virtual sbyte ToSByte (IFormatProvider provider) {
                return Value.ToSByte (provider);
            }

            public virtual float ToSingle (IFormatProvider provider) {
                return Value.ToSingle (provider);
            }

            public virtual string ToString (IFormatProvider provider) {
                return Value.ToString (provider);
            }

            public virtual object ToType (Type conversionType, IFormatProvider provider) {
                return Value.ToType (conversionType, provider);
            }

            public virtual ushort ToUInt16 (IFormatProvider provider) {
                return Value.ToUInt16 (provider);
            }

            public virtual uint ToUInt32 (IFormatProvider provider) {
                return Value.ToUInt32 (provider);
            }

            public virtual ulong ToUInt64 (IFormatProvider provider) {
                return Value.ToUInt64 (provider);
            }
            #endregion  

            #region IFormattable implementation
            public virtual string ToString (string format, IFormatProvider formatProvider) {
                return ((IFormattable) Value).ToString (format, formatProvider);
            }
            #endregion  

            #region IComparable implementation
            public virtual int CompareTo (D other) {
                return ((IComparable<D>) Value).CompareTo (other);
            }
            #endregion        
            #region IEquatable implementation
            public virtual bool Equals (D other) {
                return ((IEquatable<D>) Value).Equals (other);
            }
            #endregion
        }

    [Serializable]
    public class ByteSiblingBlockChain : ValueSiblingBlockChain<byte> {
        public ByteSiblingBlockChain (byte data, String hash, Guid OwnerGuid) : base (data, hash, OwnerGuid) { }
        public ByteSiblingBlockChain (SHA512SiblingBlockEntry<byte> data) : base (data) { }
    }

    [Serializable]
    public class Int16SiblingBlockChain : ValueSiblingBlockChain<short> {
        public Int16SiblingBlockChain (short data, String hash, Guid OwnerGuid) : base (data, hash, OwnerGuid) { }
        public Int16SiblingBlockChain (SHA512SiblingBlockEntry<Int16> data) : base (data) { }
    }

    [Serializable]
    public class Int32SiblingBlockChain : ValueSiblingBlockChain<int> {
        public Int32SiblingBlockChain (int data, String hash, Guid OwnerGuid) : base (data, hash, OwnerGuid) { }
        public Int32SiblingBlockChain (SHA512SiblingBlockEntry<Int32> data) : base (data) { }
    }

    [Serializable]
    public class Int64SiblingBlockChain : ValueSiblingBlockChain<long> {
        public Int64SiblingBlockChain (long data, String hash, Guid OwnerGuid) : base (data, hash, OwnerGuid) { }
        public Int64SiblingBlockChain (SHA512SiblingBlockEntry<Int64> data) : base (data) { }
    }

    [Serializable]
    public class SByteSiblingBlockChain : ValueSiblingBlockChain<sbyte> {
        public SByteSiblingBlockChain (sbyte data, String hash, Guid OwnerGuid) : base (data, hash, OwnerGuid) { }
        public SByteSiblingBlockChain (SHA512SiblingBlockEntry<sbyte> data) : base (data) { }
    }

    [Serializable]
    public class UInt16SiblingBlockChain : ValueSiblingBlockChain<ushort> {
        public UInt16SiblingBlockChain (ushort data, String hash, Guid OwnerGuid) : base (data, hash, OwnerGuid) { }
        public UInt16SiblingBlockChain (SHA512SiblingBlockEntry<ushort> data) : base (data) { }
    }

    [Serializable]
    public class UInt32SiblingBlockChain : ValueSiblingBlockChain<uint> {
        public UInt32SiblingBlockChain (uint data, String hash, Guid OwnerGuid) : base (data, hash, OwnerGuid) { }
        public UInt32SiblingBlockChain (SHA512SiblingBlockEntry<uint> data) : base (data) { }
    }

    [Serializable]
    public class UInt64SiblingBlockChain : ValueSiblingBlockChain<ulong> {
        public UInt64SiblingBlockChain (ulong data, String hash, Guid OwnerGuid) : base (data, hash, OwnerGuid) { }
        public UInt64SiblingBlockChain (SHA512SiblingBlockEntry<ulong> data) : base (data) { }
    }

    [Serializable]
    public class DecimalSiblingBlockChain : ValueSiblingBlockChain<decimal> {
        public DecimalSiblingBlockChain (decimal data, String hash, Guid OwnerGuid) : base (data, hash, OwnerGuid) { }
        public DecimalSiblingBlockChain (SHA512SiblingBlockEntry<decimal> data) : base (data) { }
    }

    [Serializable]
    public class DoubleSiblingBlockChain : ValueSiblingBlockChain<double> {
        public DoubleSiblingBlockChain (double data, String hash, Guid OwnerGuid) : base (data, hash, OwnerGuid) { }
        public DoubleSiblingBlockChain (SHA512SiblingBlockEntry<double> data) : base (data) { }
    }

    [Serializable]
    public class SingleSiblingBlockChain : ValueSiblingBlockChain<float> {
        public SingleSiblingBlockChain (float data, String hash, Guid OwnerGuid) : base (data, hash, OwnerGuid) { }
        public SingleSiblingBlockChain (SHA512SiblingBlockEntry<float> data) : base (data) { }
    }
}