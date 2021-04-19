using System;
using System.Collections.Generic;
using System.Text;
using EverLight.TreeStructure.Core.Enums;

namespace EverLight.TreeStructure.Core.BusinessLogic
{
    public interface ITreeNode<T>
    {
        T Data { get; set; }
        ITreeNode<T> LeftNode { get; set; }
        ITreeNode<T> RightNode { get; set; }
        SwitchType Switch { get; set; }
        string Name { get; set; }
        int LeftChildCount { get; set; }
        int RightChildCount { get; set; }
        int NumberOfBallsToRun { get; set; }
        List<string> ListOfLeafNodeNames { get; set; }
        void BuildTree(ITreeNode<T> root, int depth);
        ITreeNode<T> AddNode(ITreeNode<T> root, string name);
        string GetLeafNodeContainerName(ITreeNode<T> root);
        void AssignNodeValue(ITreeNode<T> node, string nodeName, T data);
    }
}
