using System;
using System.Linq;
using System.Management;

namespace Win32VideoControllerInfo
{
  public interface IGpu //https://msdn.microsoft.com/en-us/library/aa394512(v=vs.85).aspx
  {
    GpuProperty<string> Name { get; }
    GpuProperty<string> DeviceId { get; }
    GpuProperty<string> AdapterCompatibility { get; }
    GpuProperty<string> AdapterDacType { get; }
    GpuProperty<Memory> AdapterRam { get; }
    GpuProperty<Availability> Availability { get; }
    GpuProperty<string[]> CapabilityDescriptions { get; }
    GpuProperty<ushort?> ColorTableEntries { get; }
    GpuProperty<ConfigManagerErrorCodes> ConfigManagerErrorCode { get; }
    GpuProperty<bool> ConfigManagerUserConfig { get; }
    GpuProperty<string> CreationClassName { get; }
    GpuProperty<ushort?> CurrentBitsPerPixel { get; }
    GpuProperty<ushort?> CurrentHorizontalResolution { get; }
    GpuProperty<ulong?> CurrentNumberOfColors { get; }
    GpuProperty<ushort?> CurrentNumberOfColumns { get; }
    GpuProperty<ushort?> CurrentNumberOfRows { get; }
    GpuProperty<ushort?> CurrentRefreshRate { get; }
    GpuProperty<CurrentScanModes?> CurrentScanMode { get; }
    GpuProperty<uint?> CurrentVerticalResolution { get; }
    GpuProperty<string> Caption { get; }
    GpuProperty<string> Description { get; }
    GpuProperty<ushort?> DeviceSpecificPens { get; }
    GpuProperty<DitherTypes?> DitherType { get; }
    GpuProperty<IcmIntents?> IcmIntent { get; }
    GpuProperty<IcmMethods?> IcmMethod { get; }
    GpuProperty<ushort?> LastErrorCode { get; }
    GpuProperty<ushort?> MaxMemorySupported { get; }
    GpuProperty<ushort?> MaxNumberControlled { get; }
    GpuProperty<ushort?> MaxRefreshRate { get; }
    GpuProperty<ushort?> MinRefreshRate { get; }
    GpuProperty<ushort?> NumberOfVideoPages { get; }
    GpuProperty<ushort?> ReservedSystemPaletteEntries { get; }
    GpuProperty<ushort?> SpecificationVersion { get; }
    GpuProperty<ushort?> SystemPaletteEntries { get; }
    GpuProperty<PowerManagementCapabilities[]> PowerManagementCapabilities { get; }
    GpuProperty<string> Monochrome { get; }
    GpuProperty<Version> DriverVersion { get; }
    GpuProperty<string> ErrorDescription { get; }
    GpuProperty<string> InfFilename { get; }
    GpuProperty<string> InfSection { get; }
    GpuProperty<Strings> InstalledDisplayDrivers { get; }
    GpuProperty<string> PnpDeviceId { get; }
    GpuProperty<string> Status { get; }
    GpuProperty<string> SystemCreationClassName { get; }
    GpuProperty<string> SystemName { get; }
    GpuProperty<string> VideoModeDescription { get; }
    GpuProperty<string> VideoProcessor { get; }
    GpuProperty<bool?> ErrorCleared { get; }
    GpuProperty<bool?> PowerManagementSupported { get; }
    GpuProperty<DateTime> DriverDate { get; }
    GpuProperty<DateTime?> InstallDate { get; }
    GpuProperty<DateTime?> TimeOfLastReset { get; }
    GpuProperty<ushort?> NumberOfColorPlanes { get; }
    GpuProperty<ProtocolsSupported?> ProtocolSupported { get; }
    GpuProperty<StatusInfos?> StatusInfo { get; }
    GpuProperty<VideoArchitectures> VideoArchitecture { get; }
    GpuProperty<VideoMemoryTypes> VideoMemoryType { get; }
    GpuProperty<ushort?> VideoMode { get; }
  }

  public class Gpu : IGpu
  {
    public Gpu(ManagementBaseObject values)
    {
      Values = values;
    }

    private ManagementBaseObject Values { get; }

    private DateTime? ExtractNullableDateTime(string propertyName)
    {
      var value = Values[propertyName];
      if (value == null)
      {
        return null;
      }
      else
      {
        return ManagementDateTimeConverter.ToDateTime(value.ToString());
      }

    }

    private T? ExtractNullable<T>(string propertyName) where T : struct
    {
      var value = Values[propertyName];
      if (value == null)
      {
        return null;
      }
      else
      {
        return (T?)Convert.ChangeType(value, typeof(T));
      }
    }

    private T? ExtractNullableEnum<T>(string propertyName) where T : struct
    {
      var value = Values[propertyName];
      if (value == null)
      {
        return null;
      }
      else
      {
        return (T?) Enum.Parse(typeof(T), value.ToString());
      }
    }

    private Strings ExtractStrings(string propertyName)
    {
      var value = Values[propertyName].ToString();
      return new Strings(value.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries));
    }

    private T[] ExtractEnumArray<T>(string propertyName)
    {
      if (Values[propertyName] == null)
      {
        return null;
      }
      var value = ((object[])Values[propertyName])
        .Select(o => Enum.Parse(typeof(T), o.ToString()))
        .Cast<T>()
        .ToArray();
      return value;
    }


    private T[] ExtractArray<T>(string propertyName)
    {
      if (Values[propertyName] == null)
      {
        return null;
      }
      var value = ((object[])Values[propertyName])
        .Select(o => ConvertType(o, typeof(T)))
        .Cast<T>()
        .ToArray();
      return value;
    }


    private T ExtractValue<T>(string propertyName)
    {
      var value = Values[propertyName];
      return (T)ConvertType(value, typeof(T));
    }

    private static object ConvertType(object value, Type type)
    {
      return Convert.ChangeType(value, type);
    }

    private GpuProperty<T> GetGpuProperty<T>(string propertyName, T value)
    {
      var gpuProperty = new GpuProperty<T>(propertyName, value);
      return gpuProperty;
    }

    public GpuProperty<string> Name
    {
      get { return GetGpuProperty("Name", ExtractValue<string>("Name")); }
    }

    public GpuProperty<string> DeviceId
    {
      get { return GetGpuProperty("DeviceID", ExtractValue<string>("DeviceID")); }
    }

    public GpuProperty<string> AdapterCompatibility
    {
      get { return GetGpuProperty("AdapterCompatibility", ExtractValue<string>("AdapterCompatibility")); }
    }

    public GpuProperty<string> AdapterDacType
    {
      get { return GetGpuProperty("AdapterDACType", ExtractValue<string>("AdapterDACType")); }
    }

    public GpuProperty<Memory> AdapterRam
    {
      get { return GetGpuProperty("AdapterRAM", Memory.FromBytes(ExtractValue<uint>("AdapterRAM"))); }
    }

    public GpuProperty<Availability> Availability
    {
      get { return GetGpuProperty("Availability", ExtractNullableEnum<Availability>("Availability").Value); }
    }

    public GpuProperty<string[]> CapabilityDescriptions
    {
      get { return GetGpuProperty("CapabilityDescriptions", ExtractArray<string>("CapabilityDescriptions")); }
    }

    public GpuProperty<ushort?> ColorTableEntries
    {
      get { return GetGpuProperty("ColorTableEntries", ExtractNullable<ushort>("ColorTableEntries")); }
    }


    public GpuProperty<ConfigManagerErrorCodes> ConfigManagerErrorCode
    {
      get
      {
        return GetGpuProperty("ConfigManagerErrorCode",
          ExtractNullableEnum<ConfigManagerErrorCodes>("ConfigManagerErrorCode").Value);
      }
    }

    public GpuProperty<bool> ConfigManagerUserConfig
    {
      get { return GetGpuProperty("ConfigManagerUserConfig", ExtractValue<bool>("ConfigManagerUserConfig")); }
    }

    public GpuProperty<string> CreationClassName
    {
      get { return GetGpuProperty("CreationClassName", ExtractValue<string>("CreationClassName")); }
    }

    public GpuProperty<ushort?> CurrentBitsPerPixel
    {
      get { return GetGpuProperty("CurrentBitsPerPixel", ExtractNullable<ushort>("CurrentBitsPerPixel")); }
    }

    public GpuProperty<ushort?> CurrentHorizontalResolution
    {
      get { return GetGpuProperty("CurrentHorizontalResolution", ExtractNullable<ushort>("CurrentHorizontalResolution")); }
    }

    public GpuProperty<ulong?> CurrentNumberOfColors
    {
      get { return GetGpuProperty("CurrentNumberOfColors", ExtractNullable<ulong>("CurrentNumberOfColors")); }
    }

    public GpuProperty<ushort?> CurrentNumberOfColumns
    {
      get { return GetGpuProperty("CurrentNumberOfColumns", ExtractNullable<ushort>("CurrentNumberOfColumns")); }
    }

    public GpuProperty<ushort?> CurrentNumberOfRows
    {
      get { return GetGpuProperty("CurrentNumberOfRows", ExtractNullable<ushort>("CurrentNumberOfRows")); }
    }

    public GpuProperty<ushort?> CurrentRefreshRate
    {
      get { return GetGpuProperty("CurrentRefreshRate", ExtractNullable<ushort>("CurrentRefreshRate")); }
    }

    public GpuProperty<CurrentScanModes?> CurrentScanMode
    {
      get { return GetGpuProperty("CurrentScanMode", ExtractNullableEnum<CurrentScanModes>("CurrentScanMode")); }
    }

    public GpuProperty<uint?> CurrentVerticalResolution
    {
      get { return GetGpuProperty("CurrentVerticalResolution", ExtractNullable<uint>("CurrentVerticalResolution")); }
    }

    public GpuProperty<string> Caption
    {
      get { return GetGpuProperty("Caption", ExtractValue<string>("Caption")); }
    }

    public GpuProperty<string> Description
    {
      get { return GetGpuProperty("Description", ExtractValue<string>("Description")); }
    }

    public GpuProperty<ushort?> DeviceSpecificPens
    {
      get { return GetGpuProperty("DeviceSpecificPens", ExtractNullable<ushort>("DeviceSpecificPens")); }
    }

    public GpuProperty<DitherTypes?> DitherType
    {
      get { return GetGpuProperty("DitherType", ExtractNullableEnum<DitherTypes>("DitherType")); }
    }

    public GpuProperty<IcmIntents?> IcmIntent
    {
      get { return GetGpuProperty("ICMIntent", ExtractNullableEnum<IcmIntents>("ICMIntent")); }
    }

    public GpuProperty<IcmMethods?> IcmMethod
    {
      get { return GetGpuProperty("ICMMethod", ExtractNullableEnum<IcmMethods>("ICMMethod")); }
    }

    public GpuProperty<ushort?> LastErrorCode
    {
      get { return GetGpuProperty("LastErrorCode", ExtractNullable<ushort>("LastErrorCode")); }
    }

    public GpuProperty<ushort?> MaxMemorySupported
    {
      get { return GetGpuProperty("MaxMemorySupported", ExtractNullable<ushort>("MaxMemorySupported")); }
    }

    public GpuProperty<ushort?> MaxNumberControlled
    {
      get { return GetGpuProperty("MaxNumberControlled", ExtractNullable<ushort>("MaxNumberControlled")); }
    }

    public GpuProperty<ushort?> MaxRefreshRate
    {
      get { return GetGpuProperty("MaxRefreshRate", ExtractNullable<ushort>("MaxRefreshRate")); }
    }

    public GpuProperty<ushort?> MinRefreshRate
    {
      get { return GetGpuProperty("MinRefreshRate", ExtractNullable<ushort>("MinRefreshRate")); }
    }

    public GpuProperty<ushort?> NumberOfVideoPages
    {
      get { return GetGpuProperty("NumberOfVideoPages", ExtractNullable<ushort>("NumberOfVideoPages")); }
    }

    public GpuProperty<ushort?> ReservedSystemPaletteEntries
    {
      get
      {
        return GetGpuProperty("ReservedSystemPaletteEntries", ExtractNullable<ushort>("ReservedSystemPaletteEntries"));
      }
    }

    public GpuProperty<ushort?> SpecificationVersion
    {
      get { return GetGpuProperty("SpecificationVersion", ExtractNullable<ushort>("SpecificationVersion")); }
    }

    public GpuProperty<ushort?> SystemPaletteEntries
    {
      get { return GetGpuProperty("SystemPaletteEntries", ExtractNullable<ushort>("SystemPaletteEntries")); }
    }

    public GpuProperty<PowerManagementCapabilities[]> PowerManagementCapabilities
    {
      get
      {
        return GetGpuProperty("PowerManagementCapabilities",
          ExtractEnumArray<PowerManagementCapabilities>("PowerManagementCapabilities"));
      }
    }

    public GpuProperty<string> Monochrome
    {
      get { return GetGpuProperty("Monochrome", ExtractValue<string>("Monochrome")); }
    }

    public GpuProperty<Version> DriverVersion
    {
      get { return GetGpuProperty("DriverVersion", ExtractVersion("DriverVersion")); }
    }

    private Version ExtractVersion(string propertyName)
    {
      return Version.Parse(Values[propertyName].ToString());
    }

    public GpuProperty<string> ErrorDescription
    {
      get { return GetGpuProperty("ErrorDescription", ExtractValue<string>("ErrorDescription")); }
    }

    public GpuProperty<string> InfFilename
    {
      get { return GetGpuProperty("InfFilename", ExtractValue<string>("InfFilename")); }
    }

    public GpuProperty<string> InfSection
    {
      get { return GetGpuProperty("InfSection", ExtractValue<string>("InfSection")); }
    }

    public GpuProperty<Strings> InstalledDisplayDrivers
    {
      get { return GetGpuProperty("InstalledDisplayDrivers", ExtractStrings("InstalledDisplayDrivers")); }
    }

    public GpuProperty<string> PnpDeviceId
    {
      get { return GetGpuProperty("PNPDeviceID", ExtractValue<string>("PNPDeviceID")); }
    }

    public GpuProperty<string> Status
    {
      get { return GetGpuProperty("Status", ExtractValue<string>("Status")); }
    }

    public GpuProperty<string> SystemCreationClassName
    {
      get { return GetGpuProperty("SystemCreationClassName", ExtractValue<string>("SystemCreationClassName")); }
    }

    public GpuProperty<string> SystemName
    {
      get { return GetGpuProperty("SystemName", ExtractValue<string>("SystemName")); }
    }

    public GpuProperty<string> VideoModeDescription
    {
      get { return GetGpuProperty("VideoModeDescription", ExtractValue<string>("VideoModeDescription")); }
    }

    public GpuProperty<string> VideoProcessor
    {
      get { return GetGpuProperty("VideoProcessor", ExtractValue<string>("VideoProcessor")); }
    }

    public GpuProperty<bool?> ErrorCleared
    {
      get { return GetGpuProperty("ErrorCleared", ExtractNullable<bool>("ErrorCleared")); }
    }

    public GpuProperty<bool?> PowerManagementSupported
    {
      get { return GetGpuProperty("PowerManagementSupported", ExtractNullable<bool>("PowerManagementSupported")); }
    }

    public GpuProperty<DateTime> DriverDate
    {
      get
      {
        // ReSharper disable once PossibleInvalidOperationException
        return GetGpuProperty("DriverDate", ExtractNullableDateTime("DriverDate").Value);
      }
    }

    public GpuProperty<DateTime?> InstallDate
    {
      get { return GetGpuProperty("InstallDate", ExtractNullableDateTime("InstallDate")); }
    }

    public GpuProperty<DateTime?> TimeOfLastReset
    {
      get { return GetGpuProperty("TimeOfLastReset", ExtractNullableDateTime("TimeOfLastReset")); }
    }

    public GpuProperty<ushort?> NumberOfColorPlanes
    {
      get { return GetGpuProperty("NumberOfColorPlanes", ExtractNullable<ushort>("NumberOfColorPlanes")); }
    }

    public GpuProperty<ProtocolsSupported?> ProtocolSupported
    {
      get { return GetGpuProperty("ProtocolSupported", ExtractNullableEnum<ProtocolsSupported>("ProtocolSupported")); }
    }

    public GpuProperty<StatusInfos?> StatusInfo
    {
      get { return GetGpuProperty("StatusInfo", ExtractNullableEnum<StatusInfos>("StatusInfo")); }
    }

    public GpuProperty<VideoArchitectures> VideoArchitecture
    {
      get
      {
        return GetGpuProperty("VideoArchitecture", ExtractNullableEnum<VideoArchitectures>("VideoArchitecture").Value);
      }
    }

    public GpuProperty<VideoMemoryTypes> VideoMemoryType
    {
      get { return GetGpuProperty("VideoMemoryType", ExtractNullableEnum<VideoMemoryTypes>("VideoMemoryType").Value); }
    }

    public GpuProperty<ushort?> VideoMode
    {
      get { return GetGpuProperty("VideoMode", ExtractNullable<ushort>("VideoMode")); }
    }
  }
}