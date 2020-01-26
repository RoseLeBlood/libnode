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

## Example BlockChain
```C#
using System;
using ASF.Node.Block;

namespace nodechain
{
    public class Program
    {
        static void Main(string[] args)
        {
            Int32SiblingBlockChain chain = new Int32SiblingBlockChain(43, 
                "b3c903359afb3c480ccbb9e0f5b5652d0ba3c5837ed2f048af7f03fcac0a9d0817c83903b7be82f4da28e26409ac85c67a55d62a8d3c7daa4da36492f7cfe553");

            for(int i = 0; i < 10; i++)
                chain.Add(new SHA512SiblingBlockEntry<Int32>(i));

            Console.WriteLine("[\n{0}\n]", chain.ToString());
        }
    }
}
```
Ausgabe:
```JSON
[
{
	Data: 43,
	TimeStamp: 1580049446,0561264
	Index: 0
	Hash: b3c903359afb3c480ccbb9e0f5b5652d0ba3c5837ed2f048af7f03fcac0a9d0817c83903b7be82f4da28e26409ac85c67a55d62a8d3c7daa4da36492f7cfe553,
	PrevHash: 
	IsSibling: False
},
{
	Data: 0,
	TimeStamp: 1580049446,0829911
	Index: 1
	Hash: 0723A14744FD731721DF640F5B2A558A9649489C8D11FA3C2FA74AD2EB55D64AE9DE99C794090AFA96E74F168405439EC19466702D00BFFFEECCA0839E7A4EC3,
	PrevHash: b3c903359afb3c480ccbb9e0f5b5652d0ba3c5837ed2f048af7f03fcac0a9d0817c83903b7be82f4da28e26409ac85c67a55d62a8d3c7daa4da36492f7cfe553
	IsSibling: False
},
{
	Data: 1,
	TimeStamp: 1580049446,0995457
	Index: 2
	Hash: A98DAA065F9ADFB7A74985A2E940548EEE8E5E09473C88052D135984BDD5A47B1001C4A29D264A3B6AF201DE5C2408A370BC09CFB6605E6590FF505A4E0AEB6F,
	PrevHash: 0723A14744FD731721DF640F5B2A558A9649489C8D11FA3C2FA74AD2EB55D64AE9DE99C794090AFA96E74F168405439EC19466702D00BFFFEECCA0839E7A4EC3
	IsSibling: False
},
{
	Data: 2,
	TimeStamp: 1580049446,0998416
	Index: 3
	Hash: 5D4777B073483529681B789B5F2817C136EFE8E46995311D3BADDBC85812BD8A8384AEB74948A1E632379686EB17530AA0524AC9C846A03881A70C863823AF70,
	PrevHash: A98DAA065F9ADFB7A74985A2E940548EEE8E5E09473C88052D135984BDD5A47B1001C4A29D264A3B6AF201DE5C2408A370BC09CFB6605E6590FF505A4E0AEB6F
	IsSibling: False
},
{
	Data: 3,
	TimeStamp: 1580049446,0998664
	Index: 4
	Hash: A152E015377E37BD3D321D7FDFA6A854BC6C0B8B703B03332BED4F984A45D632535B53C019E69F1E7A176AF5E17C1A6F7A148D6584524778623FA71A5D9119F9,
	PrevHash: 5D4777B073483529681B789B5F2817C136EFE8E46995311D3BADDBC85812BD8A8384AEB74948A1E632379686EB17530AA0524AC9C846A03881A70C863823AF70
	IsSibling: False
},
{
	Data: 4,
	TimeStamp: 1580049446,099881
	Index: 5
	Hash: D213437AF5FE3681F1C83031083E9C9151B9BEC52BFD60431F272C8B150B1F491E870EE67A9963FEC69075354D7976A52225F37387FDECAABA1C26D1308D22D9,
	PrevHash: A152E015377E37BD3D321D7FDFA6A854BC6C0B8B703B03332BED4F984A45D632535B53C019E69F1E7A176AF5E17C1A6F7A148D6584524778623FA71A5D9119F9
	IsSibling: False
},
{
	Data: 5,
	TimeStamp: 1580049446,099896
	Index: 6
	Hash: 55B002CB0455278A58E813330C9BA556D991641343EE4468BF081324B1AACB3E4BC02B3BD691994561D9DAD9F9FF6843414A2EC74C07FFB57412968BB6B4CD09,
	PrevHash: D213437AF5FE3681F1C83031083E9C9151B9BEC52BFD60431F272C8B150B1F491E870EE67A9963FEC69075354D7976A52225F37387FDECAABA1C26D1308D22D9
	IsSibling: False
},
{
	Data: 6,
	TimeStamp: 1580049446,0999103
	Index: 7
	Hash: 36D21B5B47907CA349D7E2B9D4EF1C7348DE8D3DC5270A5638EAF0B9A5A4C8787DDD68E17F33ADA2606503E8F722AC74D98ECAB8E7AAC89228FEA2E04E65DF05,
	PrevHash: 55B002CB0455278A58E813330C9BA556D991641343EE4468BF081324B1AACB3E4BC02B3BD691994561D9DAD9F9FF6843414A2EC74C07FFB57412968BB6B4CD09
	IsSibling: False
},
{
	Data: 7,
	TimeStamp: 1580049446,099924
	Index: 8
	Hash: 6D77F438EDB6424FBE7E239018C6A829C26874B94EF1013F0B047ED414BD84E9F7F3E9E8ED7F490806D5D5E224BBB5EA939F40EF8A5F8D21116C6E2D674358E4,
	PrevHash: 36D21B5B47907CA349D7E2B9D4EF1C7348DE8D3DC5270A5638EAF0B9A5A4C8787DDD68E17F33ADA2606503E8F722AC74D98ECAB8E7AAC89228FEA2E04E65DF05
	IsSibling: False
},
{
	Data: 8,
	TimeStamp: 1580049446,099955
	Index: 9
	Hash: 6A0292AB921E099847F69BFEF14C5D4D6A4E8C8E915A941DBF85455337833A4321F451CF2E37E4DA8B8EB9F2CF091CE9D9D3F7656611647A6F8D2863B2EA1AEB,
	PrevHash: 6D77F438EDB6424FBE7E239018C6A829C26874B94EF1013F0B047ED414BD84E9F7F3E9E8ED7F490806D5D5E224BBB5EA939F40EF8A5F8D21116C6E2D674358E4
	IsSibling: False
},
{
	Data: 9,
	TimeStamp: 1580049446,099976
	Index: 10
	Hash: B7A8BC499CEF9EC0F540B0E8725EC190651696F9F089AD0BD52FB20F9D20A6DBDC0AFAAB0C45A986292D59A26741A7F8C7F0D1F433401C1B9815655F8DB0CA44,
	PrevHash: 6A0292AB921E099847F69BFEF14C5D4D6A4E8C8E915A941DBF85455337833A4321F451CF2E37E4DA8B8EB9F2CF091CE9D9D3F7656611647A6F8D2863B2EA1AEB
	IsSibling: False
},
]
```



