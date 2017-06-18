using SafetyTest.UserControls;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SafetyTest
{
    /// <summary>
    /// Control the traffic light
    /// </summary>
    public class LightController
    {
        public readonly TimeSpan redDuration = new TimeSpan(0, 0, 30);
        public readonly TimeSpan greenDuration = new TimeSpan(0, 0, 25);
        public readonly TimeSpan yellowDuration = new TimeSpan(0, 0, 5);

        //this trigger to stop the loop
        private bool isRunning;
        public bool IsRunning { get => isRunning; set => isRunning = value; }

        public async void TurnRed(TrafficLightControl light)
        {
            light.State = LightStates.Red;

            var sw = new Stopwatch();
            sw.Start();
            await Task.Delay(redDuration);

            if (isRunning)
            {
                TurnGreen(light);
            }
            Debug.WriteLine(sw.Elapsed.ToString(@"hh\:mm\:ss", null));
        }

        public async void TurnYellow(TrafficLightControl light)
        {
            light.State = LightStates.Yellow;
            var sw = new Stopwatch();
            sw.Start();
            await Task.Delay(yellowDuration);

            if (isRunning)
            {
                TurnRed(light);
            }
            Debug.WriteLine(sw.Elapsed.ToString(@"hh\:mm\:ss", null));
        }

        public async void TurnGreen(TrafficLightControl light)
        {
            light.State = LightStates.Green;

            var sw = new Stopwatch();
            sw.Start();

            await Task.Delay(greenDuration);
            if (isRunning)
            {
                TurnYellow(light);
            }
            else
            {
                Debug.WriteLine("stoped");
            }
            Debug.WriteLine(sw.Elapsed.ToString(@"hh\:mm\:ss", null));
        }
    }
}
