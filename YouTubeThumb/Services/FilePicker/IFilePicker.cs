using System.Threading.Tasks;
using Avalonia.Platform.Storage;

namespace YouTubeThumb.Services.FilePicker;

public interface IFilePicker
{
    public Task<IStorageFile?> OpenFileAsync();
    public Task<IStorageFile?> SaveFileAsync();
}