using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestVideoApp
{
    public class MainPageViewModel
    {
        public ICommand RecordVideoCommand => new Command(async () => await RecordVideo());

        public Action<bool> RefreshTask { get; set; } = b => { };

        private async Task RecordVideo()
        {
            PermissionStatus cameraPermission = await Permissions.RequestAsync<Permissions.Camera>();
            PermissionStatus videoPermission = await Permissions.RequestAsync<Permissions.Microphone>();

            if (cameraPermission == PermissionStatus.Granted && videoPermission == PermissionStatus.Granted)
            {
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    FileResult content = await MediaPicker.Default.CaptureVideoAsync(new MediaPickerOptions() { Title = string.Empty }) ?? new(string.Empty);

                    if (content == null) return;
                    if (string.IsNullOrEmpty(content.FullPath)) return;

                    if (RefreshTask != null) RefreshTask.Invoke(true);
                }
            }
        }
    }
}
