using System.Diagnostics;

namespace CoffeeShop;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        System.Diagnostics.Debug.WriteLine("Pat: New App Shell");
        MainPage = new AppShell();
    }
    

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);
        window.MaximumWidth = 1024;
        return window;
    }


}
