using Microsoft.Maui.Controls;

namespace Nudgi
{
    public partial class AddTaskPage : ContentPage
    {
        Button AddTaskButton;
        public TaskCompletionSource<string> TaskCompletion { get; } = new TaskCompletionSource<string>();
        
        public AddTaskPage()
        {
            InitializeComponent();
            AddTaskButton = this.FindByName<Button>("AddTaskButton");
            
        }

        private void OnAddTaskButtonPressed(object sender, EventArgs e)
        {
            AddTaskButton.BackgroundColor = Color.FromArgb("#EF5B30"); // Change to the color you want when pressed
        }

        private void OnAddTaskButtonReleased(object sender, EventArgs e)
        {
            AddTaskButton.BackgroundColor = Color.FromArgb("#FE934D"); // Change back to the original color
        }

        private async void OnAddTaskButtonClicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as TaskViewModel;
            viewModel?.AddTask();
            await Navigation.PopModalAsync();
        }

        private async void OnBackgroundTapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }

    public class TaskItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
    }
}