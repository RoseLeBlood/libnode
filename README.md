# libnode 
Namespace: ASF.Node

A generic node system for C# under LGPL for dotnet core. With BinaryTree, a list with next and prev and
generic classes to build your own classic blockchain or a blockchain with sibling. 

## Example BlockChain
```C#
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ASF.Node;
using ASF.Node.Block;

namespace nodechain {
    public class Program {
        static Guid ProgramGuid { get; set; } = new Guid ("9eccdf50-edc0-474a-bab6-2424c71a4f4e");
        static String JsonText;

        static void Main (string[] args) {

            String FileName = String.Format("{0}.json", ProgramGuid);

            Int32SiblingBlockChain chain = new Int32SiblingBlockChain (43,
                "b3c903359afb3c480ccbb9e0f5b5652d0ba3c5837ed2f048af7f03fcac0a9d0817c83903b7be82f4da28e26409ac85c67a55d62a8d3c7daa4da36492f7cfe553",
                ProgramGuid);

            for (int i = 0; i < 10; i++)
                chain.Add (new SHA512SiblingBlockEntry<Int32> (i, ProgramGuid));


            JsonText = "{\n" + String.Format ("\"{0}\":\n[", ProgramGuid);
            chain.Travers(TraversOrder.ListOrder, ChainTravers, chain.Root);
            JsonText += "]\n}";

            System.IO.File.WriteAllText(FileName , JsonText);
            Console.WriteLine("Chain written to \"{0}\".", FileName);
        }
        public static void ChainTravers(GenericBlockChain<int, SHA512SiblingBlockEntry<int>> root) {
            var option = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            JsonText += String.Format ("{0}\n", JsonSerializer.Serialize  (root.Data, option));
            if(root.Next != null) JsonText += ",";
        }
    }
}
```
Ausgabe: 
```JSON
{
"9eccdf50-edc0-474a-bab6-2424c71a4f4e":
[,{
  "sibling": null,
  "isSibling": false,
  "data": 43,
  "timeStamp": 1581763089.4828377,
  "index": 0,
  "hash": "b3c903359afb3c480ccbb9e0f5b5652d0ba3c5837ed2f048af7f03fcac0a9d0817c83903b7be82f4da28e26409ac85c67a55d62a8d3c7daa4da36492f7cfe553",
  "prevHash": "",
  "createUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "ownerUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "isValid": true
}
,{
  "sibling": null,
  "isSibling": false,
  "data": 0,
  "timeStamp": 1581763089.503791,
  "index": 1,
  "hash": "50FAEE20B58386F456386E3883FD9480A28B56A47CAB52810FFDC270B4145572BD745E1A916101667619E9D07F73EAA74B9952ADF0884DCB698BAD10F85955F5",
  "prevHash": "b3c903359afb3c480ccbb9e0f5b5652d0ba3c5837ed2f048af7f03fcac0a9d0817c83903b7be82f4da28e26409ac85c67a55d62a8d3c7daa4da36492f7cfe553",
  "createUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "ownerUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "isValid": true
}
,{
  "sibling": null,
  "isSibling": false,
  "data": 1,
  "timeStamp": 1581763089.5279057,
  "index": 2,
  "hash": "DD00BB8731EE7D2ECD4915C9AC36480748ED1FFFEC262BB6EA3C0DBEB8D966EAC02766A9B918D8D329036B12B81A1C8E4A3BE460F440A4D1D4F27CC271CB1035",
  "prevHash": "50FAEE20B58386F456386E3883FD9480A28B56A47CAB52810FFDC270B4145572BD745E1A916101667619E9D07F73EAA74B9952ADF0884DCB698BAD10F85955F5",
  "createUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "ownerUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "isValid": true
}
,{
  "sibling": null,
  "isSibling": false,
  "data": 2,
  "timeStamp": 1581763089.5282612,
  "index": 3,
  "hash": "F1FF5C6EF2A2BB80A6949DA20904163458846982796E0C97AAF7EBB52CF870D99EFCC2A749410828D49ACAE10E5820D8AF719179A5D3D287654EC6206D7E1A2C",
  "prevHash": "DD00BB8731EE7D2ECD4915C9AC36480748ED1FFFEC262BB6EA3C0DBEB8D966EAC02766A9B918D8D329036B12B81A1C8E4A3BE460F440A4D1D4F27CC271CB1035",
  "createUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "ownerUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "isValid": true
}
,{
  "sibling": null,
  "isSibling": false,
  "data": 3,
  "timeStamp": 1581763089.52829,
  "index": 4,
  "hash": "2EA0337C2A53338202A7F58D1C7157C95E1D7BF09B82CDF7B4D4899D52605F8D683E650E714896F643AC45AF5133D86961D74BF11DDFF75224FDF1235B8F044A",
  "prevHash": "F1FF5C6EF2A2BB80A6949DA20904163458846982796E0C97AAF7EBB52CF870D99EFCC2A749410828D49ACAE10E5820D8AF719179A5D3D287654EC6206D7E1A2C",
  "createUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "ownerUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "isValid": true
}
,{
  "sibling": null,
  "isSibling": false,
  "data": 4,
  "timeStamp": 1581763089.5283067,
  "index": 5,
  "hash": "407F6B72981181253CF78332EDA7E9AC3CB9D3080D0760DA92BE07B99AB80EB4DCCAA210F6384A3CFB81845E63A8D05E724CED428FE0132D0A33EAB34BAE8444",
  "prevHash": "2EA0337C2A53338202A7F58D1C7157C95E1D7BF09B82CDF7B4D4899D52605F8D683E650E714896F643AC45AF5133D86961D74BF11DDFF75224FDF1235B8F044A",
  "createUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "ownerUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "isValid": true
}
,{
  "sibling": null,
  "isSibling": false,
  "data": 5,
  "timeStamp": 1581763089.5283227,
  "index": 6,
  "hash": "9A6091456D4545D7E4BCFA57F0E545F770B007ACCF41B0328E7D80D44CC60FD4808AD243449A07F1C56CBB2048A6BBC06C29FE97BCAD1639EE7548F699B89164",
  "prevHash": "407F6B72981181253CF78332EDA7E9AC3CB9D3080D0760DA92BE07B99AB80EB4DCCAA210F6384A3CFB81845E63A8D05E724CED428FE0132D0A33EAB34BAE8444",
  "createUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "ownerUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "isValid": true
}
,{
  "sibling": null,
  "isSibling": false,
  "data": 6,
  "timeStamp": 1581763089.5283384,
  "index": 7,
  "hash": "C947DC1248ED39ABFBBE28734D13ACD10761B9C56CB4A650D78BDF2B82D0CE6F8B36741BFE38B3C19BAFA5111B78760F60B04FEA3366B770227B6A62D6755A4A",
  "prevHash": "9A6091456D4545D7E4BCFA57F0E545F770B007ACCF41B0328E7D80D44CC60FD4808AD243449A07F1C56CBB2048A6BBC06C29FE97BCAD1639EE7548F699B89164",
  "createUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "ownerUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "isValid": true
}
,{
  "sibling": null,
  "isSibling": false,
  "data": 7,
  "timeStamp": 1581763089.5283737,
  "index": 8,
  "hash": "5D9E74D763608ABBB7B76AEAA2E36BCEBA7AFBB65E1F4EBCAC5158F469A7236F8DEB04FBFE8DC584C62002174161B335EA411B308A5C4F35CFB8A1418A9B66A2",
  "prevHash": "C947DC1248ED39ABFBBE28734D13ACD10761B9C56CB4A650D78BDF2B82D0CE6F8B36741BFE38B3C19BAFA5111B78760F60B04FEA3366B770227B6A62D6755A4A",
  "createUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "ownerUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "isValid": true
}
,{
  "sibling": null,
  "isSibling": false,
  "data": 8,
  "timeStamp": 1581763089.5283928,
  "index": 9,
  "hash": "9EC0172C46A6504962163F4D6D3626C2CAD44A2F7E35E83B2E39D533ED18091BF0F39156465A9B88C3FADB7DA01719F44F404C9B36E0539BCC09BA10054B111D",
  "prevHash": "5D9E74D763608ABBB7B76AEAA2E36BCEBA7AFBB65E1F4EBCAC5158F469A7236F8DEB04FBFE8DC584C62002174161B335EA411B308A5C4F35CFB8A1418A9B66A2",
  "createUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "ownerUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "isValid": true
}
,{
  "sibling": null,
  "isSibling": false,
  "data": 9,
  "timeStamp": 1581763089.5284092,
  "index": 10,
  "hash": "DA992FCC3A68C0E4F950215245CFAFB30D60DDBBD2EFF54E39D8AA605B7319943DB199E4125FA45C700F58461B6EF337DFC61767F124489B13B1D01D8800BAC9",
  "prevHash": "9EC0172C46A6504962163F4D6D3626C2CAD44A2F7E35E83B2E39D533ED18091BF0F39156465A9B88C3FADB7DA01719F44F404C9B36E0539BCC09BA10054B111D",
  "createUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "ownerUuid": "9eccdf50-edc0-474a-bab6-2424c71a4f4e",
  "isValid": true
}
]
}
```



