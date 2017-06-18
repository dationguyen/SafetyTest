using Microsoft.VisualStudio.TestTools.UnitTesting;
using SafetyTest;
using SafetyTest.UserControls;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [UITestMethod]
        public void RedLightTest()
        {
            LightController controller = new LightController()
            {
                IsRunning = false
            };
            TrafficLightControl light = new TrafficLightControl();

            controller.TurnRed(light);
            Assert.AreEqual(LightStates.Red, light.State);
        }

        [UITestMethod]
        public void GreenLightTest()
        {
            LightController controller = new LightController()
            {
                IsRunning = false
            };
            TrafficLightControl light = new TrafficLightControl();

            controller.TurnGreen(light);
            Assert.AreEqual(LightStates.Green, light.State);
        }

        [UITestMethod]
        public void YellowLightTest()
        {
            LightController controller = new LightController()
            {
                IsRunning = false
            };
            TrafficLightControl light = new TrafficLightControl();

            controller.TurnYellow(light);
            Assert.AreEqual(LightStates.Yellow, light.State);
        }

        //[UITestMethod]
        //public void CountUpdateAfterTimeTest()
        //{
        //    //BitmapImage bm = new BitmapImage();
        //    var light = new TrafficLightControl() { State = LightStates.Green, Count = 10 };
        //    //simulate 2 step
        //    for (int i = 0; i < 2; i++)
        //    {
        //        light.UpdateLight();
        //    }
        //    //expected to keep green
        //    Assert.AreEqual(LightStates.Green, light.State);
        //    Assert.AreEqual(8, light.Count);
        //}

        //[UITestMethod]
        //public void LightChangeTest()
        //{
        //    //BitmapImage bm = new BitmapImage();
        //    var light = new TrafficLightControl() { State = LightStates.Red, Count = 1 };

        //    light.UpdateLight();

        //    //expected to turn green
        //    Assert.AreEqual(LightStates.Green, light.State);
        //}

        //[UITestMethod]
        //public void LightChangeAfterTimeTest()
        //{
        //    //BitmapImage bm = new BitmapImage();
        //    var greenCount = GlobalVariable.GreenDuration / GlobalVariable.TimerStep;
        //    var yellowCount = GlobalVariable.YellowDuration / GlobalVariable.TimerStep;

        //    var light = new TrafficLightControl() { State = LightStates.Green, Count = greenCount };

        //    //using loop to simulate the time change
        //    for (int i = 0; i < greenCount + yellowCount; i++)
        //    {
        //        light.UpdateLight();
        //    }

        //    //expected to turn red
        //    Assert.AreEqual(LightStates.Red, light.State);
        //}
    }
}
