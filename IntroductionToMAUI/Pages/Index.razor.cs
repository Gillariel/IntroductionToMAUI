using Microsoft.AspNetCore.Components;

namespace IntroductionToMAUI.Pages;

public partial class Index
{
    [Inject] IMap Map { get; set; }

    private Task OpenMap(NavigationMode mode = NavigationMode.Driving)
        => Map.OpenAsync(50.8278618, 4.3533948, new MapLaunchOptions { Name = "Postivive Thinking Company", NavigationMode = mode });
}
