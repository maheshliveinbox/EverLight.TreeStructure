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
        public string PredictedContainerName { get; set; }
        public string ActualContainerName { get; set; }

        private readonly ILogger _logger;
        private readonly ITreeNode<int> _treeNode;
        public Application(ILogger logger, ITreeNode<int> treeNode)
        {
            _logger = logger;
            _treeNode = treeNode;
        }

        public void PredictWhichContainerWillNotReceiveABall(int depth)
        {
            var root = _treeNode;

            _treeNode.BuildTree(root, depth);

            var listOfReceivedBallsContainerNames = new List<string>();

            // Predict which container not receive a ball
            for (var i = 1; i <= _treeNode.NumberOfBallsToRun; i++)
            {
                var leafNodeContainerName = root.GetLeafNodeContainerName(root);

                listOfReceivedBallsContainerNames.Add(leafNodeContainerName);
            }
            var listOfLeafNodeNames = _treeNode.ListOfLeafNodeNames;

            PredictedContainerName = listOfLeafNodeNames.Except(listOfReceivedBallsContainerNames).FirstOrDefault();

            _logger.Log("System predicts this container will not receive any balls: " + PredictedContainerName);
        }

        public void RunBall(int depth)
        {
            var root = _treeNode;

            _treeNode.BuildTree(root, depth);

            var listOfLeafNodeNames = _treeNode.ListOfLeafNodeNames;
            var listOfReceivedBallsContainerNames = new List<string>();

            for (var i = 1; i <= _treeNode.NumberOfBallsToRun; i++)
            {
                var leafNodeContainerName = root.GetLeafNodeContainerName(root);

                listOfReceivedBallsContainerNames.Add(leafNodeContainerName);

                _treeNode.AssignNodeValue(root, leafNodeContainerName, i);

                _logger.Log("Container Name: " + leafNodeContainerName + ", Value: " + i);
            }

            ActualContainerName = listOfLeafNodeNames.Except(listOfReceivedBallsContainerNames).FirstOrDefault();

            _logger.Log("This container didn't receive any balls: " + ActualContainerName);
        }
    }
}
