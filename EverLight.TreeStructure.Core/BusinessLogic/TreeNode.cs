using EverLight.TreeStructure.Core.Enums;
using System;
using System.Collections.Generic;

namespace EverLight.TreeStructure.Core.BusinessLogic
{
    public class TreeNode<T> : ITreeNode<T>
    {
        public T Data { get; set; }
        public ITreeNode<T> LeftNode { get; set; }
        public ITreeNode<T> RightNode { get; set; }
        public SwitchType Switch { get; set; }
        public string Name { get; set; }
        public int LeftChildCount { get; set; }
        public int RightChildCount { get; set; }
        public int NumberOfBallsToRun { get; set; }
        public List<string> ListOfLeafNodeNames { get; set; }
        public TreeNode(string name)
        {
            Switch = (new Random().Next(2) == 1 ? SwitchType.Left : SwitchType.Right);
            LeftChildCount = RightChildCount = 0;
            LeftNode = RightNode = null;
            Name = name;
        }
        public bool IsPerfectBinaryTree(int count)
        {
            count++;
            while (count % 2 == 0)
                count /= 2;
            return count == 1;
        }
        public void BuildTree(ITreeNode<T> root, int depth)
        {
            var nodeCount = 1;
            NumberOfBallsToRun = 1;
            ListOfLeafNodeNames = new List<string>();
            for (var i = 1; i <= depth; i++)
            {
                nodeCount *= 2;
                NumberOfBallsToRun = nodeCount - 1;
                for (var j = 1; j <= nodeCount; j++)
                {
                    var nodeName = i + "-" + j;
                    root = root.AddNode(root, nodeName);

                    if (i == depth)
                        ListOfLeafNodeNames.Add(nodeName);
                }
            }
        }
        public ITreeNode<T> AddNode(ITreeNode<T> root, string name)
        {
            if (root == null)
                return Factory<T>.CreateTreeNode(name);

            if (root.RightChildCount == root.LeftChildCount)
            {
                root.LeftNode = AddNode(root.LeftNode, name);
                root.LeftChildCount++;
            }
            else if (root.RightChildCount < root.LeftChildCount)
            {
                if (IsPerfectBinaryTree(root.LeftChildCount))
                {
                    root.RightNode = AddNode(root.RightNode, name);
                    root.RightChildCount++;
                }
                else
                {
                    root.LeftNode = AddNode(root.LeftNode, name);
                    root.LeftChildCount++;
                }
            }

            return root;
        }
        public string GetContainerName(ITreeNode<T> root)
        {
            string containerName;
            if (root.LeftNode == null && root.RightNode == null)
            {
                containerName = root.Name;
            }
            else
            {
                if (root.Switch == SwitchType.Left)
                {
                    root.Switch = SwitchType.Right;
                    containerName = GetContainerName(root.LeftNode);
                }
                else
                {
                    root.Switch = SwitchType.Left;
                    containerName = GetContainerName(root.RightNode);
                }
            }

            return containerName;
        }
        public void AssignNodeValue(ITreeNode<T> node, string nodeName, T data)
        {
            if (node == null) return;
            if (node.Name.Equals(nodeName))
            {
                node.Data = data;
                return;
            }
            AssignNodeValue(node.LeftNode, nodeName, data);
            AssignNodeValue(node.RightNode, nodeName, data);
        }
    }
}