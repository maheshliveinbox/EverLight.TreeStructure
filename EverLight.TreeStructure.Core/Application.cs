using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EverLight.TreeStructure.Core.BusinessLogic;
using EverLight.TreeStructure.Core.Utility;

namespace EverLight.TreeStructure.Core
{
    public class Application
    {
        private readonly ILogger _logger;
        private readonly ITreeNode<int> _treeNode;
        public Application(ILogger logger, ITreeNode<int> treeNode)
        {
            _logger = logger;
            _treeNode = treeNode;
        }

        public void RunBall(int depth)
        {
            var root = _treeNode;

            _treeNode.BuildTree(root, depth);

            var listOfReceivedBallsContainerName = new List<string>();

            for (var i = 1; i <= _treeNode.NumberOfBallsToRun; i++)
            {
                var currentContainerName = root.GetContainerName(root);
                listOfReceivedBallsContainerName.Add(currentContainerName);
                _treeNode.AssignNodeValue(root, currentContainerName, i);
                _logger.Log("Container Name: " + currentContainerName + ", Value: " + i);
            }

            var listOfLeafNodeNames = _treeNode.ListOfLeafNodeNames;

            foreach (var containerName in listOfReceivedBallsContainerName)
            {
                listOfLeafNodeNames.Remove(containerName);
            }

            _logger.Log("This container didn't receive any balls: " + listOfLeafNodeNames.First());
        }
    }
}
