using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SafetyTest
{
    /// <summary>
    /// solution page that display the traffic lights changing every 5 mimutes.
    /// this Solution using the DispatcherTimer to control the light
    /// this solution didn't apply MVVM pattern due to the requirement. 
    /// </summary>
    public sealed partial class TrafficLight : Page
    {
        //controller for lights
        LightController controller = new LightController();

        //timer for the watch
        DispatcherTimer watchTimer;

        //stopwatch
        Stopwatch stopwatch = new Stopwatch();

        public TrafficLight()
        {
            this.InitializeComponent();

            watchTimer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1)
            };

        }

        private void WatchTimer_Tick(object sender, object e)
        {
            if (stopwatch.Elapsed.Minutes == 10)
            {
                BtnStop_Click(sender, new RoutedEventArgs());
            }
            txtTime.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss", null);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //assign the tick method
            watchTimer.Tick += WatchTimer_Tick;
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //release tick method
            watchTimer.Tick -= WatchTimer_Tick;
            base.OnNavigatedFrom(e);
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            controller.IsRunning = true;

            stopwatch.Start();
            watchTimer.Start();

            controller.TurnRed(lightEW);
            controller.TurnGreen(lightNS);
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            //timer.Stop();
            controller.IsRunning = false;
            controller = new LightController();

            stopwatch.Reset();
            stopwatch.Stop();

            watchTimer.Stop();
        }
    }
}
