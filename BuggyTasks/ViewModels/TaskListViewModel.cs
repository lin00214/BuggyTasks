using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BuggyTasks.Models;

namespace BuggyTasks.ViewModels;

public class TaskListViewModel : INotifyPropertyChanged
{
    public ObservableCollection<TaskItem> Tasks { get; set; }

    public TaskListViewModel()
    {
        Tasks = new ObservableCollection<TaskItem>
        {
            new TaskItem { Title = "Test Task 1" },
            new TaskItem { Title = "Test Task 2" }
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}