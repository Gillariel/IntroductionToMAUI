using IntroductionToMAUI.XAML;

namespace IntroductionToMAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new MainPage();
        MainPage = new ShellExample();
    }
}
