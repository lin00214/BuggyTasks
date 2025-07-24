using Microsoft.Maui.Controls;

namespace BuggyTasks;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute("NewTaskPage", typeof(Views.NewTaskPage));
        Routing.RegisterRoute("TaskListPage", typeof(Views.TaskListPage));
        Routing.RegisterRoute("LocationPage", typeof(Views.LocationPage));
        Routing.RegisterRoute("DeviceInfoPage", typeof(Views.DeviceInfoPage));
    }
}