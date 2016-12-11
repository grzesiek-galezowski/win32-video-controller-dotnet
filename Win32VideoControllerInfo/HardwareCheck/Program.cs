using System;
using System.Threading;
using System.Windows.Forms;
using Win32VideoControllerInfo;

namespace HardwareCheck
{
  public class Program
  {
    public static void Main()
    {
      foreach (var gpu in Gpus.Load())
      {
        Console.WriteLine(Text(gpu.Name));
        Console.WriteLine(Text(gpu.DeviceId));
        Console.WriteLine(Text(gpu.AdapterCompatibility));
        Console.WriteLine(Text(gpu.AdapterDacType));
        Console.WriteLine(Text(gpu.AdapterRam));
        Console.WriteLine(Text(gpu.Availability));
        Console.WriteLine(Text(gpu.CapabilityDescriptions));
        Console.WriteLine(Text(gpu.ColorTableEntries));
        Console.WriteLine(Text(gpu.ConfigManagerErrorCode));
        Console.WriteLine(Text(gpu.ConfigManagerUserConfig));
        Console.WriteLine(Text(gpu.CreationClassName));
        Console.WriteLine(Text(gpu.CurrentBitsPerPixel));
        Console.WriteLine(Text(gpu.CurrentHorizontalResolution));
        Console.WriteLine(Text(gpu.CurrentNumberOfColors));
        Console.WriteLine(Text(gpu.CurrentNumberOfColumns));
        Console.WriteLine(Text(gpu.CurrentNumberOfRows));
        Console.WriteLine(Text(gpu.CurrentRefreshRate));
        Console.WriteLine(Text(gpu.CurrentScanMode));
        Console.WriteLine(Text(gpu.CurrentVerticalResolution));
        Console.WriteLine(Text(gpu.Caption));
        Console.WriteLine(Text(gpu.Description));
        Console.WriteLine(Text(gpu.DeviceSpecificPens));
        Console.WriteLine(Text(gpu.DitherType));
        Console.WriteLine(Text(gpu.IcmIntent));
        Console.WriteLine(Text(gpu.IcmMethod));
        Console.WriteLine(Text(gpu.LastErrorCode));
        Console.WriteLine(Text(gpu.MaxMemorySupported));
        Console.WriteLine(Text(gpu.MaxNumberControlled));
        Console.WriteLine(Text(gpu.MaxRefreshRate));
        Console.WriteLine(Text(gpu.MinRefreshRate));
        Console.WriteLine(Text(gpu.NumberOfVideoPages));
        Console.WriteLine(Text(gpu.ReservedSystemPaletteEntries));
        Console.WriteLine(Text(gpu.SpecificationVersion));
        Console.WriteLine(Text(gpu.SystemPaletteEntries));
        Console.WriteLine(Text(gpu.PowerManagementCapabilities));
        Console.WriteLine(Text(gpu.Monochrome));
        Console.WriteLine(Text(gpu.DriverVersion));
        Console.WriteLine(Text(gpu.ErrorDescription));
        Console.WriteLine(Text(gpu.InfFilename));
        Console.WriteLine(Text(gpu.InfSection));
        Console.WriteLine(Text(gpu.InstalledDisplayDrivers));
        Console.WriteLine(Text(gpu.PnpDeviceId));
        Console.WriteLine(Text(gpu.Status));
        Console.WriteLine(Text(gpu.SystemCreationClassName));
        Console.WriteLine(Text(gpu.SystemName));
        Console.WriteLine(Text(gpu.VideoModeDescription));
        Console.WriteLine(Text(gpu.VideoProcessor));
        Console.WriteLine(Text(gpu.ErrorCleared));
        Console.WriteLine(Text(gpu.PowerManagementSupported));
        Console.WriteLine(Text(gpu.DriverDate));
        Console.WriteLine(Text(gpu.InstallDate));
        Console.WriteLine(Text(gpu.TimeOfLastReset));
        Console.WriteLine(Text(gpu.NumberOfColorPlanes));
        Console.WriteLine(Text(gpu.ProtocolSupported));
        Console.WriteLine(Text(gpu.StatusInfo));
        Console.WriteLine(Text(gpu.VideoArchitecture));
        Console.WriteLine(Text(gpu.VideoMemoryType));
        Console.WriteLine(Text(gpu.VideoMode));
      }
      /*
  uint16   AcceleratorCapabilities[];
  v  string   AdapterCompatibility;
  v  string   AdapterDACType;
  v  uint32   AdapterRAM;
  v  uint16   Availability;
  v  string   CapabilityDescriptions[];
  v  string   Caption;
  v  uint32   ColorTableEntries;
  v  uint32   ConfigManagerErrorCode;
  v  boolean  ConfigManagerUserConfig;
  v  string   CreationClassName;
  v  uint32   CurrentBitsPerPixel;
  v  uint32   CurrentHorizontalResolution;
  v  uint64   CurrentNumberOfColors;
  v  uint32   CurrentNumberOfColumns;
  v  uint32   CurrentNumberOfRows;
  v  uint32   CurrentRefreshRate;
  v  uint16   CurrentScanMode;
  v  uint32   CurrentVerticalResolution;
  v  string   Description;
  v  string   DeviceID;
  v  uint32   DeviceSpecificPens;
  v  uint32   DitherType;
  v  uint32   ICMIntent;
  v  uint32   ICMMethod;
  v  uint32   LastErrorCode;
  v  uint32   MaxMemorySupported;
  v  uint32   MaxNumberControlled;
  v  uint32   MaxRefreshRate;
  v  uint32   MinRefreshRate;
  v  uint32   NumberOfVideoPages;
  v  uint32   ReservedSystemPaletteEntries;
  v  uint32   SpecificationVersion;
  v  uint32   SystemPaletteEntries;

  v  string   DriverVersion;
  v  string   ErrorDescription;
  v  string   InfFilename;
  v  string   InfSection;
  v  string   InstalledDisplayDrivers;
  v  string   Name;
  v  string   PNPDeviceID;
  v  string   Status;
  v  string   SystemCreationClassName;
  v  string   SystemName;
  v  string   VideoModeDescription;
  v  string   VideoProcessor;
    
  v  boolean  ErrorCleared;
  v  boolean  Monochrome;
  v  boolean  PowerManagementSupported;

  v  datetime DriverDate;
  v  datetime InstallDate;
  v  datetime TimeOfLastReset;

  v  uint16   NumberOfColorPlanes;
  v  uint16   ProtocolSupported;
  v  uint16   StatusInfo;
  v  uint16   VideoArchitectures;
  v  uint16   VideoMemoryType;
  v  uint16   VideoMode;

    uint16   PowerManagementCapabilities[];

        */
      


      ShowSplash("BEGIN");
      Thread.Sleep(10000);

    }

    private static void ConsoleWriteLine(string property)
    {
      
    }


    private static string Text<T>(GpuProperty<T> gpuProperty)
    {
      return gpuProperty.PropertyName + "  -  " + gpuProperty.Property;
    }

    private static void ShowSplash(string message)
    {
      
      ShowDialog(message, "");
    }

    public static void ShowDialog(string text, string caption)
    {
      Form prompt = new MyForm(text, caption);
      //Task.Delay(2000).ContinueWith(t => prompt.Close());
      prompt.ShowDialog();
    }
  }
}
