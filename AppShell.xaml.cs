namespace Save_Editor;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(SaveEditorPage), typeof(SaveEditorPage));
	}
}
