using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;

namespace BuggyTasks.Views;

public partial class DeviceInfoPage : ContentPage
{
    public DeviceInfoPage()
    {
        InitializeComponent();
        LoadDeviceInfo();
    }

    private void LoadDeviceInfo()
    {
        try
        {
            var model = DeviceInfo.Model;
            var platform = DeviceInfo.Platform.ToString();
            var version = DeviceInfo.VersionString;
            var manufacturer = DeviceInfo.Manufacturer;

            ModelLabel.Text = $"Model: {model}";
            PlatformLabel.Text = $"Platform: {platform}";
            VersionLabel.Text = $"Version: {version}";
            ManufacturerLabel.Text = $"Manufacturer: {manufacturer}";
        }
        catch (Exception ex)
        {
            ModelLabel.Text = $"Error: {ex.Message}";
            PlatformLabel.Text = "";
            VersionLabel.Text = "";
            ManufacturerLabel.Text = "";
        }
    }

    private async void OnBackButton(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}