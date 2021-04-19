using EverLight.TreeStructure.Core;
using System;

namespace EverLight.TreeStructure.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int depth = 4;
            var treeNode = Factory<int>.CreateTreeNode("root");
            var logger = Factory<int>.CreateLogger();
            var app = new Application(logger, treeNode);
            app.RunBall(depth);
            Console.ReadLine();
        }
    }
}
