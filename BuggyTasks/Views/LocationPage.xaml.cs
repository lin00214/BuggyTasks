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
        _ = GetLocationAsync();
    }

    private async void OnGetLocationButton(object sender, EventArgs e)
    {
        await GetLocationAsync();
    }

    private async Task GetLocationAsync()
    {
        try
        {
            StatusLabel.Text = "Getting location...";
            
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            if (status != PermissionStatus.Granted)
            {
                StatusLabel.Text = "Location permission denied";
                return;
            }

            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location != null)
            {
                StatusLabel.Text = "Location found!";
                LatitudeLabel.Text = $"Latitude: {location.Latitude:F6}";
                LongitudeLabel.Text = $"Longitude: {location.Longitude:F6}";
                Console.WriteLine($"Lat: {location.Latitude}, Long: {location.Longitude}");
            }
            else
            {
                StatusLabel.Text = "No location available";
                LatitudeLabel.Text = "Latitude: -";
                LongitudeLabel.Text = "Longitude: -";
            }
        }
        catch (FeatureNotSupportedException)
        {
            StatusLabel.Text = "Location not supported on this device";
        }
        catch (PermissionException)
        {
            StatusLabel.Text = "Location permission denied";
        }
        catch (Exception ex)
        {
            StatusLabel.Text = $"Error: {ex.Message}";
        }
    }

    private async void OnBackButton(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}