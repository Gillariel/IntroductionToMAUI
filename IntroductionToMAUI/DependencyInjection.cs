using IntroductionToMAUI.Interfaces;

namespace IntroductionToMAUI;

public static class DependencyInjectionsExtensions 
{
    private static void RegisterPlatformSpecificComponents(IServiceCollection services)
    {
#if WINDOWS
        services.AddTransient<IFolderPicker, FolderPicker>();
#elif MACCATALYST
        services.AddTransient<IFolderPicker, FolderPicker>();
#endif
    }
}
