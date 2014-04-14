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
	public class ComparableBinaryTreeNode<D> : BinaryTreeNode<IComparable>, IComparable<D>
		where D : IComparable
	{
		public ComparableBinaryTreeNode (string name, IComparable data = null) : base(name, data) { }

		public override BinaryTreeNode<IComparable> setNode(BinaryTreeNode<IComparable> node)
		{
			if (getNode (node.Name) != null)
				throw new Exception ("Node ist schon im Baum");


            if (m_left == null)
            {
                m_left = setParent(node);
                Console.WriteLine("[{0}:{2}] Set Node Left: {1}:{3} Parent: {4}", Name, m_left.Name, Data, m_left.Data,
                                  Parent != null ? Parent.Name : "Root");
                return this;
            }
            else if (m_right == null)
            {
                m_right = setParent(node);
				Console.WriteLine("[{0}:{2}] Set Node Right: {1}:{3} Parent: {4}", Name, m_right.Name, Data, m_right.Data,
                                  Parent != null ? Parent.Name : "Root");
                return this;
            }

            if (((ComparableBinaryTreeNode<D>)m_left).CompareTo((D)node.Data) == 0)
            {
                m_left.setNode(node);
            }
            else 
            {
                m_right.setNode(node);
            }
			
			return this;
		}		
		public int CompareTo (D other)
		{
			return Data.CompareTo(other);
		}
        public override string ToString()
        {
            StringBuilder st = new StringBuilder(string.Format("[{0}:{1}] ", Name, Data));
            if(m_left != null)
                st.Append(string.Format("Left: {0} ", m_left));
            if(m_right != null)
                st.Append(string.Format("Right: {0} ", m_right));

            return st.ToString();
        }
	}

	public class ByteBinaryTreeNode : ComparableBinaryTreeNode<byte> 
	{ public ByteBinaryTreeNode (string name, byte value) : base(name, value) { } }
	public class Int16BinaryTreeNode : ComparableBinaryTreeNode<short> 
	{ public Int16BinaryTreeNode (string name, short value) : base(name, value) { } }
	public class Int32BinaryTreeNode : ComparableBinaryTreeNode<int> 
	{ public Int32BinaryTreeNode (string name, int value) : base(name, value) { } }
	public class Int64BinaryTreeNode : ComparableBinaryTreeNode<long> 
	{ public Int64BinaryTreeNode (string name, long value) : base(name, value) { } }
	public class SByteBinaryTreeNode : ComparableBinaryTreeNode<sbyte> 
	{ public SByteBinaryTreeNode (string name, sbyte value) : base(name, value) { } }
	public class UInt16BinaryTreeNode : ComparableBinaryTreeNode<ushort> 
	{ public UInt16BinaryTreeNode (string name, ushort value) : base(name, value) { } }
	public class UInt32BinaryTreeNode : ComparableBinaryTreeNode<uint> 
	{ public UInt32BinaryTreeNode (string name, uint value) : base(name, value) { } }
	public class UInt64BinaryTreeNode : ComparableBinaryTreeNode<ulong> 
	{ public UInt64BinaryTreeNode (string name, ulong value) : base(name, value) { } }
	public class BigIntBinaryTreeNode : ComparableBinaryTreeNode<BigInteger> 
	{ public BigIntBinaryTreeNode (string name, BigInteger value) : base(name, value) { } }
	public class DecimalBinaryTreeNode : ComparableBinaryTreeNode<decimal> 
	{ public DecimalBinaryTreeNode (string name, decimal value) : base(name, value) { } }
	public class DoubleBinaryTreeNode : ComparableBinaryTreeNode<double> 
	{ public DoubleBinaryTreeNode (string name, double value) : base(name, value) { } }
	public class SingleBinaryTreeNode : ComparableBinaryTreeNode<float> 
	{ public SingleBinaryTreeNode (string name, float value) : base(name, value) { } }
}

