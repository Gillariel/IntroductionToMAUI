using MudBlazor;

namespace BlazorClassLibrary.Components;

public partial class StorageStatus
{
    static readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };

    protected DriveInfo[] Drives { get; set; } = new DriveInfo[0];

    protected override void OnInitialized()
    {
        try
        {
            Drives = DriveInfo.GetDrives();
        }
        catch (UnauthorizedAccessException u)
        {
            // The caller does not have the required permission.
        }
        catch (IOException u)
        {
            // For example, a disk error or a drive was not ready
        }
        base.OnInitialized();
    }

    private float GetProgress(DriveInfo drive)
        => (float)drive.TotalFreeSpace / (float)drive.TotalSize;

    private string GetIcon(DriveInfo drive)
        => drive.DriveType switch
        {
            DriveType.CDRom => Icons.Material.Filled.Album,
            DriveType.Network => Icons.Material.Filled.Router,
            DriveType.Removable => Icons.Material.Filled.Eject,
            DriveType.Fixed => Icons.Material.Filled.Computer,
            _ => Icons.Material.Filled.Help
        };

    private static string ReadableBytes(Int64 bytes)
    {
        int counter = 0;
        decimal number = (decimal)bytes;
        while (Math.Round(number / 1024) >= 1)
        {
            number = number / 1024;
            counter++;
        }
        return string.Format("{0:n1}{1}", number, suffixes[counter]);
    }

}
