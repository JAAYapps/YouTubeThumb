using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using YouTubeThumb.Services.FilePicker;

namespace YouTubeThumb.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as Fonts
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as Fonts
    
    [ObservableProperty] private string title = "Insert title";
    
    [ObservableProperty] private string channelName = "Insert Channel Name";

    [ObservableProperty] private string viewsAndTime = "20K views  2 hours ago"; 
    
    [ObservableProperty] private string views = "20K views"; 
    
    [ObservableProperty] private string time = "2 hours ago"; 
    
    [ObservableProperty] private string videoTime = "20:10"; 
    
    [ObservableProperty] private string imageName = "";

    [ObservableProperty] private Bitmap image;
    
    [ObservableProperty] private string profileImageName = "";
    
    [ObservableProperty] private Bitmap profileImage;

    partial void OnViewsChanged(string value)
    {
        ViewsAndTime = value + " • " + Time;
    }

    partial void OnTimeChanged(string value)
    {
        ViewsAndTime = Views + " • " + value;
    }
    
    [RelayCommand]
    private async Task OpenThumbnailImage()
    {
        ErrorMessages?.Clear();
        try
        {
            var filePicker = App.Current?.Services?.GetService<IFilePicker>();
            if (filePicker is null) throw new NullReferenceException("Missing File Service instance.");

            var file = await filePicker.OpenFileAsync();
            if (file is null) return;
            
            ImageName = file.Name;
            /*if ((await file.GetBasicPropertiesAsync()).Size <= 1024 * 1024 * 1)
            {
                
            }
            else
            {
                throw new Exception("File exceeded 1MB limit.");
            }*/
            await using var stream = await file.OpenReadAsync();
            Image = new Bitmap(stream);
        }
        catch (Exception e)
        {
            ErrorMessages?.Add(e.Message);
        }
    }
    
    [RelayCommand]
    private async Task OpenProfileImage()
    {
        ErrorMessages?.Clear();
        try
        {
            var filePicker = App.Current?.Services?.GetService<IFilePicker>();
            if (filePicker is null) throw new NullReferenceException("Missing File Service instance.");

            var file = await filePicker.OpenFileAsync();
            if (file is null) return;
            
            ProfileImageName = file.Name;
            /*if ((await file.GetBasicPropertiesAsync()).Size <= 1024 * 1024 * 1)
            {

            }
            else
            {
                throw new Exception("File exceeded 1MB limit.");
            }*/
            await using var stream = await file.OpenReadAsync();
            ProfileImage = new Bitmap(stream);
        }
        catch (Exception e)
        {
            ErrorMessages?.Add(e.Message);
        }
    }
}