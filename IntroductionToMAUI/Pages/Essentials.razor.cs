namespace IntroductionToMAUI.Pages;

public partial class Essentials
{
    #region Constants

    private static readonly PreferenceKeys[] preferenceKeys 
        = (PreferenceKeys[])Enum.GetValues(typeof(PreferenceKeys));

    #endregion

    #region Properties

    private string SMS { get; set; }
    private PreferenceKeys TempPrefKey { get; set; }
    private string TempPrefValue { get; set; }

    #endregion

    #region LifeCycle

    #endregion

    #region  Send SMS

    private static Task OpenSms()
        => Sms.ComposeAsync(new SmsMessage
        {
            Body = "Hello PTC from MAUI Blazor!",
            Recipients = new() { "+32478628927", "+32460954818" }
        });

    #endregion

    #region  Flashlight

    private static Task TurnOnFlashLight()
        => Flashlight.TurnOnAsync();

    private static Task TurnOffFlashLight()
        => Flashlight.TurnOffAsync();

    #endregion

    #region  Battery

    private static string GetBattery()
        => $"[{Battery.State}] {(Battery.ChargeLevel * 100):N}%";

    #endregion

    #region Share

    private static async Task ShareClipboard()
        => await Share.RequestAsync(
            await (Clipboard.HasText 
                ? Clipboard.GetTextAsync() 
                : Task.FromResult<string?>("Random clipboard")
            )
        );

    #endregion

    #region Preferences

    public void SavePreference()
    {
        Preferences.Set(TempPrefKey.ToString(), TempPrefValue);
        StateHasChanged();
    }

    public static string GetPreference(string key)
    {
        var v = Preferences.Get(key, string.Empty);
        return v;
    }

    public static bool HasPreference(string key)
       => Preferences.ContainsKey(key);

    public void ClearPreferences()
    {
        Preferences.Clear();
        StateHasChanged();
    }

    #endregion
}

public enum PreferenceKeys
{
    Email = 1,
    Phone = 2,
    CreditCard = 3,
}
