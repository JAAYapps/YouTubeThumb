using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace YouTubeThumb.Views;

public partial class ThumbnailControls : Window
{
    public ThumbnailControls()
    {
        InitializeComponent();
    }

    private void TopLevel_OnClosed(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }

    private void TopLevel_OnOpened(object? sender, EventArgs e)
    {
        
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        
    }
}