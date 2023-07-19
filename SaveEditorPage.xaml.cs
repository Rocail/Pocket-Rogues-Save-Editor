
using CommunityToolkit.Maui.Alerts;

namespace Save_Editor;

public partial class SaveEditorPage : ContentPage, IQueryAttributable
{
    SaveFileModel oldSave;
    SaveFileModel save;
    string path;
    public SaveEditorPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        save = query[nameof(SaveFileModel)] as SaveFileModel;
        oldSave = save.DeepCopy();
        InitFields();
        path = query["path"] as string;
    }

    private void Gold_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!(int.TryParse(e.NewTextValue, out save.gold)))
        {
            save.gems = oldSave.gold;
        }
    }

    private void Gems_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!(int.TryParse(e.NewTextValue, out save.gems)))
        {
            save.gems = oldSave.gems;
        }
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        save.Save(path);
        SaveButton.Text = "Saved !";
        await Task.Delay(2000);
        SaveButton.Text = "Save";
        Reload(SaveFileModel.Load(path));
    }

    private async void LoadButton_Clicked(object sender, EventArgs e)
    {
        FileResult result = await SaveFilePicker.PickAsync();
        if (result != null)
        {
            var path = result.FullPath;
            var save = SaveFileModel.Load(path);
            if (save != null)
            {
                LoadButton.Text = $"Loaded !";
                save.Save(path + ".backup");
                Reload(save);

                await Task.Delay(2000);
                LoadButton.Text = "Load";
            }
            else
            {
                await Toast.Make("Error", CommunityToolkit.Maui.Core.ToastDuration.Short, 14).Show();
            }
        }
    }

    private void Reload(SaveFileModel save)
    {   
        if (save != null)
        {
            this.save = save;
            oldSave = save.DeepCopy();
            InitFields();
        }
        else
        {
            Toast.Make("Error reloading the save, close and reopen the app if you want to edit again");
        }
    }

    private void handleSkillPoint(Job job, string value)
    {
        if (!(int.TryParse(value, out int sp)))
        {
            save.SetJobSP(job, oldSave.GetJobSP(Job.Archer));
        }
        else
        {
            save.SetJobSP(job, sp);
        }
    }

    private void WarriorSkillPoints_TextChanged(object sender, TextChangedEventArgs e)
    {
        handleSkillPoint(Job.Warrior, e.NewTextValue);
    }

    private void ArcherSkillPoints_TextChanged(object sender, TextChangedEventArgs e)
    {
        handleSkillPoint(Job.Archer, e.NewTextValue);
    }

    private void WizardSkillPoints_TextChanged(object sender, TextChangedEventArgs e)
    {
        handleSkillPoint(Job.Wizard, e.NewTextValue);
    }

    private void HunterSkillPoints_TextChanged(object sender, TextChangedEventArgs e)
    {
        handleSkillPoint(Job.Hunter, e.NewTextValue);
    }

    private void BerserkSkillPoints_TextChanged(object sender, TextChangedEventArgs e)
    {
        handleSkillPoint(Job.Berserk, e.NewTextValue);
    }

    private void NecromancerSkillPoints_TextChanged(object sender, TextChangedEventArgs e)
    {
        handleSkillPoint(Job.Necromancer, e.NewTextValue);
    }
    private void InitFields()
    {
        Gold.Text = save.gold.ToString();
        Gems.Text = save.gems.ToString();
        int i = 0;
        new List<Entry> {
            WarriorSkillPoints,
            ArcherSkillPoints,
            WizardSkillPoints,
            HunterSkillPoints,
            BerserkSkillPoints,
            NecromancerSkillPoints,
        }.ForEach(entry =>
        {
            entry.Text = save.GetJobSP((Job) i++).ToString();
        });
    }
}