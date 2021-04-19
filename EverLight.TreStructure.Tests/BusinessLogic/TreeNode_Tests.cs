using System;
using System.Collections.Generic;
using System.Text;
using EverLight.TreeStructure.Core;
using EverLight.TreeStructure.Core.BusinessLogic;
using Xunit;

namespace EverLight.TreStructure.Tests.BusinessLogic
{
    public class TreeNode_Tests
    {
        [Fact]
        public void BuildTree_LeftNode_Is_Equal_To_RightNode()
        {
            // Arrange
            double expected = 5;

            // Act
            double actual = 4;

            // Assert

            Assert.Equal(expected, actual);
        }
    }
}
