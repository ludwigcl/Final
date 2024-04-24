using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;

namespace Nudgi
{
    public partial class TimerPage : ContentPage, INotifyPropertyChanged
    {
        public Command StartTimerCommand { get; private set; }
        public Command FinishOnTimeCommand { get; private set; }
        public Command SacrificeTimeCommand { get; private set; }

        private TimeSpan timer;
        public TimeSpan Timer
        {
            get { return timer; }
            set
            {
                if (timer != value)
                {
                    timer = value;
                    OnPropertyChanged("Timer");
                }
            }
        }

        private System.Timers.Timer countdownTimer;

        public TimerPage()
        {
            InitializeComponent();
            StartTimerCommand = new Command(StartTimer);
            FinishOnTimeCommand = new Command(FinishOnTime);
            SacrificeTimeCommand = new Command(SacrificeTime);
            Timer = new TimeSpan(0, 0, 10); // Set initial timer value
            BindingContext = this;
        }

        private void StartTimer()
        {
            countdownTimer = new System.Timers.Timer(1000); // Interval set to 1 second
            countdownTimer.Elapsed += (sender, e) => 
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Timer = Timer.Add(TimeSpan.FromSeconds(-1));

                    if (Timer.TotalSeconds <= 0)
                    {
                        StopTimerAndVibration();
                    }
                });
            };
            countdownTimer.Start(); 
            Vibration.Vibrate();
        }

        private void FinishOnTime()
        {
            StopTimerAndVibration();
            // Add your logic here for when the "I'll Finish on Time!" button is pressed
        }

        private void SacrificeTime()
        {
            StopTimerAndVibration();
            // Add your logic here for when the "Sacrifice Free Time (5 minutes)" button is pressed
        }

        private void StopTimerAndVibration()
        {
            countdownTimer.Stop();
            Vibration.Cancel();
            Navigation.PopModalAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}