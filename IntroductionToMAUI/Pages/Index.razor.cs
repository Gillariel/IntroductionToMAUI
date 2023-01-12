using Microsoft.AspNetCore.Components;

namespace IntroductionToMAUI.Pages;

public partial class Index
{
    [Inject] IMap Map { get; set; }

    private Task OpenMap(NavigationMode mode = NavigationMode.Driving)
        => Map.OpenAsync(50.5773772, 4.6609821, new MapLaunchOptions { Name = "La niche", NavigationMode = mode });
}
