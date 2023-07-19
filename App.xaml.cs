namespace Save_Editor;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        const int newWidth = 450;
        const int newHeight = 1050;

        window.Width = newWidth;
        window.Height = newHeight;

        return window;
    }
}
