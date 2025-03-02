using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using YouTubeThumb.ViewModels;
using YouTubeThumb.Views;
using Microsoft.Extensions.DependencyInjection;
using YouTubeThumb.Services.FilePicker;

namespace YouTubeThumb;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
            MainWindowViewModel vm = new MainWindowViewModel();
            
            desktop.MainWindow = new ThumbnailControls
            {
                DataContext = vm
            };
            Thumbnail thumbnail = new Thumbnail
            {
                DataContext = vm
            };
            thumbnail.Show();
            
            var services = new ServiceCollection();

            services.AddSingleton<IFilePicker>(x => new FilePicker(desktop.MainWindow));

            Services = services.BuildServiceProvider();
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    public new static App? Current => Application.Current as App;

    /// <summary>
    /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
    /// </summary>
    public IServiceProvider? Services { get; private set; }
}