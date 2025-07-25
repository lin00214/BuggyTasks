using Microsoft.Maui.Controls;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;

namespace BuggyTasks.Views;

public partial class LocationPage : ContentPage
{
    public LocationPage()
    {
        InitializeComponent();
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = GetLocation(); 
    }
    
    async Task GetLocation()
    {
        var location = await Geolocation.GetLastKnownLocationAsync(); 
        if (location != null)
        {
            Console.WriteLine($"Lat: {location.Latitude}, Long: {location.Longitude}");
        }
    }

    private async void OnBackButton(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}