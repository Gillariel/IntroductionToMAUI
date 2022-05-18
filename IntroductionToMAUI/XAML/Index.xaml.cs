namespace IntroductionToMAUI.XAML;

public partial class Index : ContentPage
{
    public Index()
    {
        InitializeComponent();
    }

    private void LaunchBlazorBlank(object sender, EventArgs e)
        => Application.Current.OpenWindow(new Window(new WithBlazor()));

    private void LaunchBlazor(object sender, EventArgs e)
        => Application.Current.MainPage = new WithBlazor();
}