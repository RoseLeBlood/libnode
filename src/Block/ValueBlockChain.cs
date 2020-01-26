//
//  ValueBlockChain.cs
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
using System.Text;



namespace ASF.Node.Block {
    [Serializable]
	public class ValueBlockChain<D> : GenericBlockChain<D>, IComparable, IConvertible, IFormattable, IComparable<D>, IEquatable<D>
		where D : IComparable, IConvertible, IFormattable, IComparable<D>, IEquatable<D>
	{
        public D Value {
            get { return m_data.Data; }
        }
		public ValueBlockChain(D data, String hash ) : base(data, hash) { }
        public ValueBlockChain(SHA512BlockEntry<D> data) : base(data) { }

        #region IComparable implementation
        public virtual int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }
        #endregion    

         #region IConvertible implementation
        public virtual TypeCode GetTypeCode()
        {
            return Value.GetTypeCode();
        }

        public virtual bool ToBoolean(IFormatProvider provider)
        {
            return Value.ToBoolean(provider);
        }

        public virtual byte ToByte(IFormatProvider provider)
        {
            return Value.ToByte(provider);
        }

        public virtual char ToChar(IFormatProvider provider)
        {
            return Value.ToChar(provider);
        }

        public virtual DateTime ToDateTime(IFormatProvider provider)
        {
            return Value.ToDateTime(provider);
        }

        public virtual decimal ToDecimal(IFormatProvider provider)
        {
            return Value.ToDecimal(provider);
        }

        public virtual double ToDouble(IFormatProvider provider)
        {
            return Value.ToDouble(provider);
        }

        public virtual short ToInt16(IFormatProvider provider)
        {
            return Value.ToInt16(provider);
        }

        public virtual int ToInt32(IFormatProvider provider)
        {
            return Value.ToInt32(provider);
        }

        public virtual long ToInt64(IFormatProvider provider)
        {
            return Value.ToInt64(provider);
        }

        public virtual sbyte ToSByte(IFormatProvider provider)
        {
            return Value.ToSByte(provider);
        }

        public virtual float ToSingle(IFormatProvider provider)
        {
            return Value.ToSingle(provider);
        }

        public virtual string ToString(IFormatProvider provider)
        {
            return Value.ToString(provider);
        }

        public virtual object ToType(Type conversionType, IFormatProvider provider)
        {
            return Value.ToType(conversionType, provider);
        }

        public virtual ushort ToUInt16(IFormatProvider provider)
        {
            return Value.ToUInt16(provider);
        }

        public virtual uint ToUInt32(IFormatProvider provider)
        {
            return Value.ToUInt32(provider);
        }

        public virtual ulong ToUInt64(IFormatProvider provider)
        {
            return Value.ToUInt64(provider);
        }
        #endregion  

        #region IFormattable implementation
        public virtual string ToString(string format, IFormatProvider formatProvider)
        {
            return ((IFormattable)Value).ToString(format, formatProvider);
        }
        #endregion  

        #region IComparable implementation
        public virtual int CompareTo(D other)
        {
            return ((IComparable<D>)Value).CompareTo(other);
        }
        #endregion        
        #region IEquatable implementation
        public virtual bool Equals(D other)
        {
            return ((IEquatable<D>)Value).Equals(other);
        }
        #endregion

        public override string ToString() {
            StringBuilder st = new StringBuilder(string.Format("[{0}] ", Value));
            if(m_nodes[1] != null)
                st.Append(string.Format("Next: {0} ", m_nodes[1]));
            return st.ToString();
        }
    }

    [Serializable]
	public class ByteBlockChain : ValueBlockChain<byte> 
	{ public ByteBlockChain (byte value, string hash) : base(value, hash)  { }
      public ByteBlockChain(SHA512BlockEntry<byte> data) : base(data) { } }
    [Serializable]
	public class Int16BlockChain : ValueBlockChain<short> 
	{ public Int16BlockChain (short value, string hash) : base(value, hash)  { }
      public Int16BlockChain(SHA512BlockEntry<Int16> data) : base(data) { } }
    [Serializable]
	public class Int32BlockChain : ValueBlockChain<int> 
	{ public Int32BlockChain (int value, string hash) : base(value, hash)  { }
      public Int32BlockChain(SHA512BlockEntry<Int32> data) : base(data) { } }
    [Serializable]
	public class Int64BlockChain : ValueBlockChain<long> 
	{ public Int64BlockChain (long value, string hash) : base(value, hash)  { }
      public Int64BlockChain(SHA512BlockEntry<Int64> data) : base(data) { } }
    [Serializable]
	public class SByteBlockChain : ValueBlockChain<sbyte> 
	{ public SByteBlockChain (sbyte value, string hash) : base(value, hash)  { }
      public SByteBlockChain(SHA512BlockEntry<sbyte> data) : base(data) { } }
    [Serializable]
	public class UInt16BlockChain : ValueBlockChain<ushort> 
	{ public UInt16BlockChain (ushort value, string hash) : base(value, hash)  { }
      public UInt16BlockChain(SHA512BlockEntry<ushort> data) : base(data) { } }
    [Serializable]
	public class UInt32BlockChain : ValueBlockChain<uint> 
	{ public UInt32BlockChain (uint value, string hash) : base(value, hash) { }
      public UInt32BlockChain(SHA512BlockEntry<uint> data) : base(data) { } }
    [Serializable]
	public class UInt64BlockChain : ValueBlockChain<ulong> 
	{ public UInt64BlockChain (ulong value, string hash) : base(value, hash) { }
      public UInt64BlockChain(SHA512BlockEntry<ulong> data) : base(data) { } }
	[Serializable]
	public class DecimalBlockChain : ValueBlockChain<decimal> 
	{ public DecimalBlockChain (decimal value, string hash) : base(value, hash) { }
      public DecimalBlockChain(SHA512BlockEntry<decimal> data) : base(data) { } }
    [Serializable]
	public class DoubleBlockChain : ValueBlockChain<double> 
	{ public DoubleBlockChain (double value, string hash) : base(value, hash) { }
      public DoubleBlockChain(SHA512BlockEntry<double> data) : base(data) { } }
    [Serializable]
	public class SingleBlockChain : ValueBlockChain<float> 
	{ public SingleBlockChain (float value, string hash) : base(value, hash) { }
      public SingleBlockChain(SHA512BlockEntry<float> data) : base(data) { } }
}