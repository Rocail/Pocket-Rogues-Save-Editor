using CommunityToolkit.Maui.Alerts;

namespace Save_Editor;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnLoadButtonClicked(object sender, EventArgs e)
    {
        FileResult result = await SaveFilePicker.PickAsync();
        if (result != null)
        {
            var path = result.FullPath;
            var save = SaveFileModel.Load(path);
            if (save != null)
            {
                save.Save(path + ".backup");
                save.Save(path + ".json", false);
                await Shell.Current.GoToAsync($"{nameof(SaveEditorPage)}",
                    new Dictionary<string, object>
                    {
                    { nameof(SaveFileModel), save },
                        {"path", path }
                    });
            }
            else
            {
                await Toast.Make("Error", CommunityToolkit.Maui.Core.ToastDuration.Short, 14).Show();
            }
        }
    }
}
