using System;
using System.Collections.Generic;
using System.Text;
using EverLight.TreeStructure.Core.BusinessLogic;
using EverLight.TreeStructure.Core.Utility;

namespace EverLight.TreeStructure.Core
{
    public class Factory<T>
    {
        public static ILogger CreateLogger()
        {
            return new Logger();
        }

        public static ITreeNode<T> CreateTreeNode(string name)
        {
            return new TreeNode<T>(name);
        }
    }
}
