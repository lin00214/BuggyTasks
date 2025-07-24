using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace BuggyTasks.ViewModels;

public class NewTaskViewModel : INotifyPropertyChanged
{
    private string _newTaskTitle = string.Empty;

    public string NewTaskTitle
    {
        get => _newTaskTitle;
        set
        {
            if (_newTaskTitle != value)
            {
                _newTaskTitle = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand AddTaskCommand { get; }

    public NewTaskViewModel()
    {
        AddTaskCommand = new Command(async () => await AddTaskAsync());
    }

    private async Task AddTaskAsync()
    {
        if (string.IsNullOrWhiteSpace(NewTaskTitle))
            return;
        
        Console.WriteLine($"Added task: {NewTaskTitle}");
        
        NewTaskTitle = string.Empty;

        await Shell.Current.GoToAsync("..");
    }

    public event PropertyChangedEventHandler? PropertyChanged; 

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}