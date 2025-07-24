using Microsoft.Maui.Controls;

namespace BuggyTasks.Views;

public partial class NewTaskPage : ContentPage
{
    public NewTaskPage()
    {
        InitializeComponent();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}