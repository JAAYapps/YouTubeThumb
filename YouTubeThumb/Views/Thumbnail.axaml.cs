using System;
using System.Threading;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Threading;

namespace YouTubeThumb.Views;

public partial class Thumbnail : Window
{
    public Thumbnail()
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
        var desktop = App.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime;
        
        new Thread(o =>
        {
            while (!(desktop != null && desktop.MainWindow != null && desktop.MainWindow.IsLoaded))
            {
                Thread.Sleep(1000);
                
            }
            Console.WriteLine(Position.X);
            Dispatcher.UIThread.Post(() =>
            {
                Position = new PixelPoint(desktop.MainWindow.Position.X - (int)Width - 100, desktop.MainWindow.Position.Y);
            }, DispatcherPriority.Background);
        }).Start();
    }
}