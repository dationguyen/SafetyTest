using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SafetyTest.UserControls
{
    [TemplateVisualState(Name = "Green", GroupName = "States")]
    [TemplateVisualState(Name = "Yellow", GroupName = "States")]
    [TemplateVisualState(Name = "Red", GroupName = "States")]
    public sealed partial class TrafficLightControl : UserControl
    {
        public TrafficLightControl()
        {
            this.InitializeComponent();
        }

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        public LightStates State
        {
            get { return (LightStates)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register
            (
                   "State",
                   typeof(LightStates),
                   typeof(TrafficLightControl),
                   new PropertyMetadata(LightStates.Green,
                   OnLightStateChanged)
            );
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register
            (
                   "Count",
                   typeof(int),
                   typeof(TrafficLightControl),
                   new PropertyMetadata("30",
                   OnCountStateChanged)
            );

        private void SetState()
        {
            switch (State)
            {
                case LightStates.Green:
                    VisualStateManager.GoToState(this, "Green", true);
                    break;
                case LightStates.Yellow:
                    VisualStateManager.GoToState(this, "Yellow", true);
                    break;
                case LightStates.Red:
                    VisualStateManager.GoToState(this, "Red", true);
                    break;
                default:
                    VisualStateManager.GoToState(this, "NotWorking", true);
                    break;
            }
        }

        private void SetCountdown()
        {
            txtCountDown.Text = Count.ToString();
        }

        private static void OnCountStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TrafficLightControl)d).SetCountdown();
        }
        private static void OnLightStateChanged(DependencyObject d,
                 DependencyPropertyChangedEventArgs e)
        {
            ((TrafficLightControl)d).SetState();
        }

        public void UpdateLight()
        {            
            Count--;
            if (Count <= 0)
            {
                switch (State)
                {
                    case LightStates.Green:
                        Count = GlobalVariable.YellowDuration / GlobalVariable.TimerStep;
                        State = LightStates.Yellow;
                        break;
                    case LightStates.Yellow:
                        Count = GlobalVariable.RedDuration / GlobalVariable.TimerStep;
                        State = LightStates.Red;
                        break;
                    case LightStates.Red:
                        Count = GlobalVariable.GreenDuration / GlobalVariable.TimerStep;
                        State = LightStates.Green;
                        break;
                    default:
                        break;
                }
            }       
        }
    }

}
