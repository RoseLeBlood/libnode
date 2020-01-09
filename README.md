# libnode 
Namespace: ASF.Node

A generic node system for C# under LGPL for dotnet core. 

## ListNode
Namespace: ASF.Node.List

Eine einfache doppelte verkettete Liste. 

public class GenericListEntry<T>;
public class ListNode<T>  : Node<T, ListNode<T>>, IEnumerable<T>, IList<GenericListEntry<T>>;
public class ListNode : ListNode<Object>;

public class StreamListNode : ListNode;
public class ValueListNode<D> : ListNode, IComparable, IConvertible, 
    IFormattable, IComparable<D>, IEquatable<D>
    where D : IComparable, IConvertible, IFormattable, IComparable<D>, IEquatable<D>;

public class ByteListNode : ValueListNode<byte> ;
public class Int16ListNode : ValueListNode<short> ;
public class Int32ListNode : ValueListNode<int> ;
public class Int64ListNode : ValueListNode<long> ;
public class SByteListNode : ValueListNode<sbyte> ;
public class UInt16ListNode : ValueListNode<ushort> ;
public class UInt32ListNode : ValueListNode<uint>;
public class UInt64ListNode : ValueListNode<ulong> ;
public class DecimalListNode : ValueListNode<decimal> ;
public class DoubleListNode : ValueListNode<double> ;
public class SingleListNode : ValueListNode<float> ;

## BinaryTree 
Namespace: ASF.Node.Binary

This node is a auto very very simple balanced red/black Graph

public class GenericTreeNodeEntry<T>;
public class BinaryTreeNode<T> : Node<T, BinaryTreeNode<T>>, IEnumerable<T>,
    IList<GenericTreeNodeEntry<T>>;

public class BinaryTreeNode : BinaryTreeNode<Object>;
public class ListBinaryTreeNode<T> : BinaryTreeNode;
public class StreamBinaryTreeNode : BinaryTreeNode;

public class ValueBinaryTreeNode<D> : BinaryTreeNode, IComparable, 
    IConvertible, IFormattable, IComparable<D>, IEquatable<D>
	where D : IComparable, IConvertible, IFormattable, IComparable<D>, IEquatable<D>

public class ByteBinaryTreeNode : ValueBinaryTreeNode<byte> ;
public class Int16BinaryTreeNode : ValueBinaryTreeNode<short> ;
public class Int32BinaryTreeNode : ValueBinaryTreeNode<int> ;
public class Int64BinaryTreeNode : ValueBinaryTreeNode<long> ;
public class SByteBinaryTreeNode: ValueBinaryTreeNode<sbyte> ;
public class UInt16BinaryTreeNode : ValueBinaryTreeNode<ushort> ;
public class UInt32BinaryTreeNode : ValueBinaryTreeNode<uint>;
public class UInt64BinaryTreeNode : ValueBinaryTreeNode<ulong> ;
public class DecimalBinaryTreeNode : ValueBinaryTreeNode<decimal> ;
public class DoubleBinaryTreeNode : ValueBinaryTreeNode<double> ;
public class SingleBinaryTreeNode : ValueBinaryTreeNode<float> ;
	
## Star Node
Namespace: 

This node has a list of childs 

public class StarNode<T> : Node<T, StarNode<T>>;


## BlockChain Node System
Namespace: ASF.Node.Block

public abstract class GenericBlockEntry<T>;
public class SHA256BlockEntry<T> : GenericBlockEntry<T>;
public class SHA512BlockEntry<T> : GenericBlockEntry<T>; (STandardt using)

public class GenericBlockChain<T, ENTRY> 
    : Node<ENTRY, GenericBlockChain<T, ENTRY>>, IEnumerable<ENTRY>,
      IList<ENTRY>, ICollection<ENTRY> where ENTRY : GenericBlockEntry<T>;

public class BlockChain  : GenericBlockChain<Object> ;
public class StreamBlockChain  : GenericBlockChain<Stream>;
public class ValueBlockChain<D> : GenericBlockChain<D>, IComparable, IConvertible, 
    IFormattable, IComparable<D>, IEquatable<D>
	where D : IComparable, IConvertible, IFormattable, IComparable<D>, IEquatable<D>;

public class ByteBlockChain : ValueBlockChain<byte> ;
public class Int16BlockChain : ValueBlockChain<short> ;
public class Int32BlockChain : ValueBlockChain<int> ;
public class Int64BlockChain : ValueBlockChain<long> ;
public class SByteBlockChain : ValueBlockChain<sbyte> ;
public class UInt16BlockChain : ValueBlockChain<ushort> ;
public class UInt32BlockChain : ValueBlockChain<uint>;
public class UInt64BlockChain : ValueBlockChain<ulong> ;
public class DecimalBlockChain : ValueBlockChain<decimal> ;
public class DoubleBlockChain : ValueBlockChain<double> ;
public class SingleBlockChain : ValueBlockChain<float> ;




