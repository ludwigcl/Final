using System;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Nudgi
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> Tasks { get; } = new ObservableCollection<string>();
        
        public MainPage()
        {
            InitializeComponent();
            AddTaskPageButton.Clicked += OnButtonClicked;
            AddTaskPageButton.Pressed += OnButtonPressed;
            AddTaskPageButton.Released += OnButtonReleased;
            TimerDemoButton.Clicked += OnButtonClicked;
            TimerDemoButton.Pressed += OnButtonPressed;
            TimerDemoButton.Released += OnButtonReleased;
        }

        private void OnButtonPressed(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.CommandParameter)
                {
                    case "AddTaskPageButton":
                        button.BackgroundColor = Color.FromArgb("#6FFEEE"); 
                        break;
                    case "TimerDemoButton":
                        button.BackgroundColor = Color.FromArgb("#FED7A7");
                        break;
                }
            }
        }

        private void OnButtonReleased(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.CommandParameter)
                {
                    case "AddTaskPageButton":
                        button.BackgroundColor = Color.FromArgb("#69DEF8"); // Change back to the original color
                        break;
                    case "TimerDemoButton":
                        button.BackgroundColor = Color.FromArgb("#FE934D");
                        break;
                }
            }
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.CommandParameter)
                {
                    case "AddTaskPageButton":
                    if (Tasks.Count < 3)
                    {
                        var addTaskPage = new AddTaskPage { BindingContext = App.TaskViewModel };
                        await Navigation.PushModalAsync(addTaskPage);
                    }
                    else
                    {
                        await DisplayAlert("Alert", "You can only have 3 tasks at a time", "OK");
                    }
                    break;
                    case "TimerDemoButton":
                        var timerPage = new TimerPage();
                        await Navigation.PushModalAsync(timerPage);
                        break;
                }
            }
        }
    }
}
