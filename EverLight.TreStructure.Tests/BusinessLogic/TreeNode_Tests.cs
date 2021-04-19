using System;
using System.Collections.Generic;
using System.Text;
using EverLight.TreeStructure.Core;
using EverLight.TreeStructure.Core.BusinessLogic;

namespace EverLight.TreStructure.Tests.BusinessLogic
{
    public class TreeNode_Tests
    {
        private readonly ITreeNode<int> _treeNode;
        public TreeNode_Tests()
        {
            _treeNode = Factory<int>.CreateTreeNode("root");
        }
    }
}
