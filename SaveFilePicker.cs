using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Save_Editor
{
    public class SaveFilePicker
    {
        public static FilePickerFileType saveFileType
        {
            get
            {
                return new FilePickerFileType(
                    new Dictionary<DevicePlatform, IEnumerable<string>>
                    {
                    { DevicePlatform.WinUI, new[] { ".prs" } },
                    });
            }
        }

        public static async Task<FileResult> PickAsync()
        {
            PickOptions options = new()
            {
                PickerTitle = "Please select your save file",
                FileTypes = saveFileType,
            };
            return await FilePicker.PickAsync(options);

        }
    }
}
