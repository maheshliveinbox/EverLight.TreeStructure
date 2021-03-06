using EverLight.TreeStructure.Core;

namespace EverLight.TreeStructure.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int depth = 4;
            var logger = Factory<int>.CreateLogger();

            logger.StartApplication();

            logger.Log("Depth is : " + depth);

            // Predict
            var predictTreeNode = Factory<int>.CreateTreeNode("root");
            var predictApp = new Application(logger, predictTreeNode);
            predictApp.PredictWhichContainerWillNotReceiveABall(depth);
            logger.Log("Prediction is completed");
            logger.Log("System predicts this container will not receive any balls: " + predictApp.PredictedContainerName);

            // Run ball
            var actualTreeNode = Factory<int>.CreateTreeNode("root");
            var actualApp = new Application(logger, actualTreeNode);
            actualApp.RunBall(depth);
            logger.Log("Runball is completed");
            logger.Log("This container didn't receive any balls: " + actualApp.ActualContainerName);

            // Conclusion
            logger.Log("System prediction is : " +
                       (predictApp.PredictedContainerName.Equals(actualApp.ActualContainerName)
                           ? "correct!"
                           : "wrong!"));

            logger.EndApplication();
        }
    }
}
