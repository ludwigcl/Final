using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Nudgi
{
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }


    public class TaskViewModel : INotifyPropertyChanged
    {
        private string _taskName;
        private string _taskDescription;
        public Command AddTaskPageCommand { get; }
        public Command AddTaskCommand { get; }
        public ObservableCollection<Task> Tasks { get; } = new ObservableCollection<Task>();
        public TaskCompletionSource<string> TaskCompletion { get; } = new TaskCompletionSource<string>();
        
        
        public TaskViewModel()
        {
            AddTaskCommand = new Command(AddTask, () => IsAddTaskEnabled);
        }


        public string TaskName
        {
            get => _taskName;
            set
            {
                if (_taskName == value) return;
                _taskName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsAddTaskEnabled));
                AddTaskCommand?.ChangeCanExecute(); 
            }
        }

        public string TaskDescription
        {
            get => _taskDescription;
            set
            {
                if (_taskDescription == value) return;
                _taskDescription = value;
                OnPropertyChanged();
            }
        }

        public bool IsAddTaskEnabled => !string.IsNullOrEmpty(TaskName);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddTask()
        {
            var newTask = new Task { Name = TaskName, Description = TaskDescription };
            Tasks.Add(newTask);
            TaskCompletion.SetResult(TaskName);
            ClearFields();
        }

        private void ClearFields()
        {
            TaskName = string.Empty;
            TaskDescription = string.Empty;
        }
    }
}