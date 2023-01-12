using IntroductionToMAUI.Interfaces;
using IntroductionToMAUI.Platforms;
//using IntroductionToMAUI.Platforms;

namespace IntroductionToMAUI;

public static class DependencyInjectionsExtensions 
{
    public static void RegisterPlatformSpecificComponents(this IServiceCollection services)
    {
#if WINDOWS
        services.AddTransient<IFolderPicker, WinFolderPicker>();
#elif MACCATALYST
        services.AddTransient<IFolderPicker, MacFolderPicker>();
#elif ANDROID        
        services.AddTransient<IFolderPicker, AndroidFolderPicker>();
#endif
    }
}
