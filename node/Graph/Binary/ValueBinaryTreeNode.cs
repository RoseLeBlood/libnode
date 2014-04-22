//
//  BinaryTrees.cs
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
using System.Numerics;
using System.Text;

namespace node
{
    [Serializable]
	public class ValueBinaryTreeNode<D> : BinaryTreeNode, IComparable, IConvertible, IFormattable, IComparable<D>, IEquatable<D>
		where D : IComparable, IConvertible, IFormattable, IComparable<D>, IEquatable<D>
	{
		public ValueBinaryTreeNode (string name, Object data = null) : base(name, data) { }

		public override BinaryTreeNode<Object> setNode(BinaryTreeNode<Object> node)
		{
			if (getNode (node.Name) != null)
				throw new Exception ("Node ist schon im Baum");


            if (m_nodes[1] == null)
            {
                node.Parent = this;
                m_nodes[1] = node;


                Console.WriteLine("[{0}:{2}] Set Node Left: {1}:{3} Parent: {4}", Name, m_nodes[1].Name, Data, m_nodes[1].Data,
                                  Parent != null ? Parent.Name : "Root");
                return this;
            }
            else if (m_nodes[2] == null)
            {
                node.Parent = this;
                m_nodes[2] = node;
				Console.WriteLine("[{0}:{2}] Set Node Right: {1}:{3} Parent: {4}", Name, m_nodes[2].Name, Data, m_nodes[2].Data,
                                  Parent != null ? Parent.Name : "Root");
                return this;
            }

            if(m_nodes[1] > node)
            {
                m_nodes[1].setNode(node);
            }
            else 
            {
                m_nodes[2].setNode(node);
            }
			
			return this;
		}

        public override string ToString()
        {
            StringBuilder st = new StringBuilder(string.Format("[{0}:{1}] ", Name, Data));
            if(m_nodes[1] != null)
                st.Append(string.Format("Left: {0} ", m_nodes[1]));
            if(m_nodes[2] != null)
                st.Append(string.Format("Right: {0} ", m_nodes[2]));

            return st.ToString();
        }
        #region IComparable implementation
        public virtual int CompareTo(object obj)
        {
            return ((IComparable)Data).CompareTo(obj);
        }
        #endregion       

        #region IConvertible implementation
        public virtual TypeCode GetTypeCode()
        {
            return ((IConvertible)Data).GetTypeCode();
        }

        public virtual bool ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)Data).ToBoolean(provider);
        }

        public virtual byte ToByte(IFormatProvider provider)
        {
            return ((IConvertible)Data).ToByte(provider);
        }

        public virtual char ToChar(IFormatProvider provider)
        {
            return ((IConvertible)Data).ToChar(provider);
        }

        public virtual DateTime ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)Data).ToDateTime(provider);
        }

        public virtual decimal ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)Data).ToDecimal(provider);
        }

        public virtual double ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)Data).ToDouble(provider);
        }

        public virtual short ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)Data).ToInt16(provider);
        }

        public virtual int ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)Data).ToInt32(provider);
        }

        public virtual long ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)Data).ToInt64(provider);
        }

        public virtual sbyte ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)Data).ToSByte(provider);
        }

        public virtual float ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)Data).ToSingle(provider);
        }

        public virtual string ToString(IFormatProvider provider)
        {
            return ((IConvertible)Data).ToString(provider);
        }

        public virtual object ToType(Type conversionType, IFormatProvider provider)
        {
            return ((IConvertible)Data).ToType(conversionType, provider);
        }

        public virtual ushort ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)Data).ToUInt16(provider);
        }

        public virtual uint ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)Data).ToUInt32(provider);
        }

        public virtual ulong ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)Data).ToUInt64(provider);
        }
        #endregion        

        #region IFormattable implementation
        public virtual string ToString(string format, IFormatProvider formatProvider)
        {
            return ((IFormattable)Data).ToString(format, formatProvider);
        }
        #endregion  

        #region IComparable implementation
        public virtual int CompareTo(D other)
        {
            return ((IComparable<D>)Data).CompareTo(other);
        }
        #endregion        
        #region IEquatable implementation
        public virtual bool Equals(D other)
        {
            return ((IEquatable<D>)Data).Equals(other);
        }
        #endregion
	}

    [Serializable]
	public class ByteBinaryTreeNode : ValueBinaryTreeNode<byte> 
	{ public ByteBinaryTreeNode (string name, byte value) : base(name, value) { } }
    [Serializable]
	public class Int16BinaryTreeNode : ValueBinaryTreeNode<short> 
	{ public Int16BinaryTreeNode (string name, short value) : base(name, value) { } }
    [Serializable]
	public class Int32BinaryTreeNode : ValueBinaryTreeNode<int> 
	{ public Int32BinaryTreeNode (string name, int value) : base(name, value) { } }
    [Serializable]
	public class Int64BinaryTreeNode : ValueBinaryTreeNode<long> 
	{ public Int64BinaryTreeNode (string name, long value) : base(name, value) { } }
    [Serializable]
	public class SByteBinaryTreeNode : ValueBinaryTreeNode<sbyte> 
	{ public SByteBinaryTreeNode (string name, sbyte value) : base(name, value) { } }
    [Serializable]
	public class UInt16BinaryTreeNode : ValueBinaryTreeNode<ushort> 
	{ public UInt16BinaryTreeNode (string name, ushort value) : base(name, value) { } }
    [Serializable]
	public class UInt32BinaryTreeNode : ValueBinaryTreeNode<uint> 
	{ public UInt32BinaryTreeNode (string name, uint value) : base(name, value) { } }
    [Serializable]
	public class UInt64BinaryTreeNode : ValueBinaryTreeNode<ulong> 
	{ public UInt64BinaryTreeNode (string name, ulong value) : base(name, value) { } }
	[Serializable]
	public class DecimalBinaryTreeNode : ValueBinaryTreeNode<decimal> 
	{ public DecimalBinaryTreeNode (string name, decimal value) : base(name, value) { } }
    [Serializable]
	public class DoubleBinaryTreeNode : ValueBinaryTreeNode<double> 
	{ public DoubleBinaryTreeNode (string name, double value) : base(name, value) { } }
    [Serializable]
	public class SingleBinaryTreeNode : ValueBinaryTreeNode<float> 
	{ public SingleBinaryTreeNode (string name, float value) : base(name, value) { } }
}

