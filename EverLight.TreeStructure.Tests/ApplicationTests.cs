using System;
using System.Collections.Generic;
using System.Text;
using EverLight.TreeStructure.Core;
using Xunit;

namespace EverLight.TreeStructure.Tests
{
    public class ApplicationTests
    {
        private readonly Application _application;
        public ApplicationTests()
        {
            var logger = Factory<int>.CreateLogger();
            var predictTreeNode = Factory<int>.CreateTreeNode("root");
            _application = new Application(logger, predictTreeNode);
        }

        [Fact]
        public void PredictWhichContainerWillNotReceiveABall_Should_Set_PredictedContainerName()
        {
            // Arrange
            var depth = 4;

            // Act
            _application.PredictWhichContainerWillNotReceiveABall(depth);

            // Assert
            Assert.NotEmpty(_application.PredictedContainerName);
        }

        [Fact]
        public void RunBall_Should_Set_ActualContainerName()
        {
            // Arrange
            var depth = 4;

            // Act
            _application.RunBall(depth);

            // Assert
            Assert.NotEmpty(_application.ActualContainerName);
        }
    }
}
