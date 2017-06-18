using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SafetyTest
{
    /// <summary>
    /// solution page that display the traffic lights changing every 30 second.
    /// this Solution using the DispatcherTimer to control the light
    /// this solution didn't apply MVVM pattern due to the requirement. 
    /// </summary>
    public sealed partial class TrafficLight : Page
    {
        DateTime startTime = new DateTime();

        //create timer
        //timer for light control
        DispatcherTimer timer;
        //timer for the watch
        DispatcherTimer watchTimer;

        //stopwatch
        Stopwatch stopwatch = new Stopwatch();

        public TrafficLight()
        {
            this.InitializeComponent();

            timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(GlobalVariable.TimerStep)
            };

            watchTimer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            watchTimer.Tick += WatchTimer_Tick;

            //set the normal state and count for the traffic lights
            lightEW.State = LightStates.Green;
            lightEW.Count = GlobalVariable.GreenDuration / GlobalVariable.TimerStep;

            lightNS.State = LightStates.Red;
            lightNS.Count = GlobalVariable.RedDuration / GlobalVariable.TimerStep;


        }

        private void WatchTimer_Tick(object sender, object e)
        {
            txtTime.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss", null);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //assign the tick method
            timer.Tick += Timer_Tick;
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //release tick method
            timer.Tick -= Timer_Tick;
            base.OnNavigatedFrom(e);
        }

        private void Timer_Tick(object sender, object e)
        {
            //update light status
            lightEW.UpdateLight();
            lightNS.UpdateLight();
        }



        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            startTime = DateTime.Now;
            timer.Start();

            stopwatch.Start();
            watchTimer.Start();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            
            stopwatch.Stop();
            watchTimer.Stop();
        }
    }
}
