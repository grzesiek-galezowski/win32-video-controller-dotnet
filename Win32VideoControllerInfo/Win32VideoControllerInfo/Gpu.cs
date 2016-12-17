using System;
using System.Collections.Generic;
using System.Management;
using Win32VideoControllerInfo.Enums;
using Win32VideoControllerInfo.PropertyTypes;
using Win32VideoControllerInfo.SpecialTypes;

namespace Win32VideoControllerInfo
{
  public class Gpu : IGpu
  {
    public static Gpu LoadFrom(IGpuDataSource dataSource)
    {
      var gpu = new Gpu(dataSource);
      return gpu;
    }

    private readonly SortedDictionary<string, IGpuProperty> _properties;

    private Gpu(IGpuDataSource fromSource)
    {

      var sortedDictionary = new SortedDictionary<string, IGpuProperty>();
      AddTo(sortedDictionary, Name = GpuProperty.GetString("Name", fromSource));
      AddTo(sortedDictionary, DeviceId = GpuProperty.GetString("DeviceID", fromSource));
      AddTo(sortedDictionary, AdapterCompatibility = GpuProperty.GetString("AdapterCompatibility", fromSource));
      AddTo(sortedDictionary, AdapterDacType = GpuProperty.GetString("AdapterDACType", fromSource));
      AddTo(sortedDictionary, AdapterRam = GpuProperty.Get("AdapterRAM", Memory.FromBytes(fromSource.Value<uint>("AdapterRAM"))));
      AddTo(sortedDictionary, Availability = GpuProperty.Get("Availability", fromSource.NullableEnum<Availability>("Availability").Value));
      AddTo(sortedDictionary, CapabilityDescriptions = new GpuArrayProperty<string>("CapabilityDescriptions", fromSource.Array<string>("CapabilityDescriptions")));
      AddTo(sortedDictionary, ColorTableEntries = GpuProperty.Get("ColorTableEntries", fromSource.Nullable<ushort>("ColorTableEntries")));
      AddTo(sortedDictionary, ConfigManagerErrorCode = GpuProperty.Get("ConfigManagerErrorCode", fromSource.NullableEnum<ConfigManagerErrorCodes>("ConfigManagerErrorCode").Value));
      AddTo(sortedDictionary, ConfigManagerUserConfig = GpuProperty.Get("ConfigManagerUserConfig", fromSource.Value<bool>("ConfigManagerUserConfig")));
      AddTo(sortedDictionary, CreationClassName = GpuProperty.GetString("CreationClassName", fromSource));
      AddTo(sortedDictionary, CurrentBitsPerPixel = GpuProperty.Get("CurrentBitsPerPixel", fromSource.Nullable<ushort>("CurrentBitsPerPixel")));
      AddTo(sortedDictionary, CurrentHorizontalResolution = GpuProperty.Get("CurrentHorizontalResolution", fromSource.Nullable<ushort>("CurrentHorizontalResolution")));
      AddTo(sortedDictionary, CurrentNumberOfColors = GpuProperty.Get("CurrentNumberOfColors", fromSource.Nullable<ulong>("CurrentNumberOfColors")));
      AddTo(sortedDictionary, CurrentNumberOfColumns = GpuProperty.Get("CurrentNumberOfColumns", fromSource.Nullable<ushort>("CurrentNumberOfColumns")));
      AddTo(sortedDictionary, CurrentNumberOfRows = GpuProperty.Get("CurrentNumberOfRows", fromSource.Nullable<ushort>("CurrentNumberOfRows")));
      AddTo(sortedDictionary, CurrentRefreshRate = GpuProperty.Get("CurrentRefreshRate", fromSource.Nullable<ushort>("CurrentRefreshRate")));
      AddTo(sortedDictionary, CurrentScanMode = GpuProperty.Get("CurrentScanMode", fromSource.NullableEnum<CurrentScanModes>("CurrentScanMode")));
      AddTo(sortedDictionary, CurrentVerticalResolution = GpuProperty.Get("CurrentVerticalResolution", fromSource.Nullable<uint>("CurrentVerticalResolution")));
      AddTo(sortedDictionary, Caption = GpuProperty.GetString("Caption", fromSource));
      AddTo(sortedDictionary, Description = GpuProperty.GetString("Description", fromSource));
      AddTo(sortedDictionary, DeviceSpecificPens = GpuProperty.Get("DeviceSpecificPens", fromSource.Nullable<ushort>("DeviceSpecificPens")));
      AddTo(sortedDictionary, DitherType = GpuProperty.Get("DitherType", fromSource.NullableEnum<DitherTypes>("DitherType")));
      AddTo(sortedDictionary, IcmIntent = GpuProperty.Get("ICMIntent", fromSource.NullableEnum<IcmIntents>("ICMIntent")));
      AddTo(sortedDictionary, IcmMethod = GpuProperty.Get("ICMMethod", fromSource.NullableEnum<IcmMethods>("ICMMethod")));
      AddTo(sortedDictionary, LastErrorCode = GpuProperty.Get("LastErrorCode", fromSource.Nullable<ushort>("LastErrorCode")));
      AddTo(sortedDictionary, MaxMemorySupported = GpuProperty.Get("MaxMemorySupported", fromSource.Nullable<ushort>("MaxMemorySupported")));
      AddTo(sortedDictionary, MaxNumberControlled = GpuProperty.Get("MaxNumberControlled", fromSource.Nullable<ushort>("MaxNumberControlled")));
      AddTo(sortedDictionary, MaxRefreshRate = GpuProperty.Get("MaxRefreshRate", fromSource.Nullable<ushort>("MaxRefreshRate")));
      AddTo(sortedDictionary, MinRefreshRate = GpuProperty.Get("MinRefreshRate", fromSource.Nullable<ushort>("MinRefreshRate")));
      AddTo(sortedDictionary, NumberOfVideoPages = GpuProperty.Get("NumberOfVideoPages", fromSource.Nullable<ushort>("NumberOfVideoPages")));
      AddTo(sortedDictionary, ReservedSystemPaletteEntries = GpuProperty.Get("ReservedSystemPaletteEntries", fromSource.Nullable<ushort>("ReservedSystemPaletteEntries")));
      AddTo(sortedDictionary, SpecificationVersion = GpuProperty.Get("SpecificationVersion", fromSource.Nullable<ushort>("SpecificationVersion")));
      AddTo(sortedDictionary, SystemPaletteEntries = GpuProperty.Get("SystemPaletteEntries", fromSource.Nullable<ushort>("SystemPaletteEntries")));
      AddTo(sortedDictionary, PowerManagementCapabilities = new GpuArrayProperty<PowerManagementCapabilities>("PowerManagementCapabilities", fromSource.EnumArray<PowerManagementCapabilities>("PowerManagementCapabilities")));
      AddTo(sortedDictionary, Monochrome = GpuProperty.GetString("Monochrome", fromSource));
      AddTo(sortedDictionary, DriverVersion = GpuProperty.Get("DriverVersion", fromSource.Version("DriverVersion")));
      AddTo(sortedDictionary, ErrorDescription = GpuProperty.GetString("ErrorDescription", fromSource));
      AddTo(sortedDictionary, InfFilename = GpuProperty.GetString("InfFilename", fromSource));
      AddTo(sortedDictionary, InfSection = GpuProperty.GetString("InfSection", fromSource));
      AddTo(sortedDictionary, InstalledDisplayDrivers = GpuProperty.Get("InstalledDisplayDrivers", fromSource.Strings("InstalledDisplayDrivers")));
      AddTo(sortedDictionary, PnpDeviceId = GpuProperty.GetString("PNPDeviceID", fromSource));
      AddTo(sortedDictionary, Status = GpuProperty.GetString("Status", fromSource));
      AddTo(sortedDictionary, SystemCreationClassName = GpuProperty.GetString("SystemCreationClassName", fromSource));
      AddTo(sortedDictionary, SystemName = GpuProperty.GetString("SystemName", fromSource));
      AddTo(sortedDictionary, VideoModeDescription = GpuProperty.GetString("VideoModeDescription", fromSource));
      AddTo(sortedDictionary, VideoProcessor = GpuProperty.GetString("VideoProcessor", fromSource));
      AddTo(sortedDictionary, ErrorCleared = GpuProperty.GetNullable<bool>("ErrorCleared", fromSource));
      AddTo(sortedDictionary, PowerManagementSupported = GpuProperty.Get("PowerManagementSupported", fromSource.Nullable<bool>("PowerManagementSupported")));
      AddTo(sortedDictionary, DriverDate = GpuProperty.Get("DriverDate", fromSource.NullableDateTime("DriverDate").Value));
      AddTo(sortedDictionary, InstallDate = GpuProperty.Get("InstallDate", fromSource.NullableDateTime("InstallDate")));
      AddTo(sortedDictionary, TimeOfLastReset = GpuProperty.Get("TimeOfLastReset", fromSource.NullableDateTime("TimeOfLastReset")));
      AddTo(sortedDictionary, NumberOfColorPlanes = GpuProperty.GetNullable<ushort>("NumberOfColorPlanes", fromSource));
      AddTo(sortedDictionary, ProtocolSupported = GpuProperty.Get("ProtocolSupported", fromSource.NullableEnum<ProtocolsSupported>("ProtocolSupported")));
      AddTo(sortedDictionary, StatusInfo = GpuProperty.Get("StatusInfo", fromSource.NullableEnum<StatusInfos>("StatusInfo")));
      AddTo(sortedDictionary, VideoArchitecture = GpuProperty.Get("VideoArchitecture", fromSource.NullableEnum<VideoArchitectures>("VideoArchitecture").Value));
      AddTo(sortedDictionary, VideoMemoryType = GpuProperty.Get("VideoMemoryType", fromSource.NullableEnum<VideoMemoryTypes>("VideoMemoryType").Value));
      AddTo(sortedDictionary, VideoMode = GpuProperty.GetNullable<ushort>("VideoMode", fromSource));
      _properties = sortedDictionary;
    }

    public IEnumerable<PropertyDiff> CalculateDifferencesAgainst(IGpu otherGpu)
    {
      return otherGpu.CalculateDifferencesAgainst(_properties);
    }

    public IEnumerable<PropertyDiff> CalculateDifferencesAgainst(SortedDictionary<string, IGpuProperty> otherGpuProperties)
    {
      List<PropertyDiff> result = new List<PropertyDiff>();
      foreach (var key in otherGpuProperties.Keys)
      {
        var left = otherGpuProperties[key];
        var right = _properties[key];
        if (!left.Equals(right))
        {
          result.Add(new PropertyDiff(key, left, right));
        }
      }
      return result;
    }

    public IEnumerable<IGpuProperty> AllProperties()
    {
      return _properties.Values;
    }

    private void AddTo(SortedDictionary<string, IGpuProperty> sortedDictionary, IGpuProperty gpuProperty)
    {
      sortedDictionary.Add(gpuProperty.PropertyName, gpuProperty);
    }

    public GpuProperty<string> Name { get; }
    public GpuProperty<string> DeviceId { get; }
    public GpuProperty<string> AdapterCompatibility { get; }
    public GpuProperty<string> AdapterDacType { get; }
    public GpuProperty<Memory> AdapterRam { get; }
    public GpuProperty<Availability> Availability { get; }
    public GpuArrayProperty<string> CapabilityDescriptions { get; }
    public GpuProperty<ushort?> ColorTableEntries { get; }
    public GpuProperty<ConfigManagerErrorCodes> ConfigManagerErrorCode { get; }
    public GpuProperty<bool> ConfigManagerUserConfig { get; }
    public GpuProperty<string> CreationClassName { get; }
    public GpuProperty<ushort?> CurrentBitsPerPixel { get; }
    public GpuProperty<ushort?> CurrentHorizontalResolution { get; }
    public GpuProperty<ulong?> CurrentNumberOfColors { get; }
    public GpuProperty<ushort?> CurrentNumberOfColumns { get; }
    public GpuProperty<ushort?> CurrentNumberOfRows { get; }
    public GpuProperty<ushort?> CurrentRefreshRate { get; }
    public GpuProperty<CurrentScanModes?> CurrentScanMode { get; }
    public GpuProperty<uint?> CurrentVerticalResolution { get; }
    public GpuProperty<string> Caption { get; }
    public GpuProperty<string> Description { get; }
    public GpuProperty<ushort?> DeviceSpecificPens { get; }
    public GpuProperty<DitherTypes?> DitherType { get; }
    public GpuProperty<IcmIntents?> IcmIntent { get; }
    public GpuProperty<IcmMethods?> IcmMethod { get; }
    public GpuProperty<ushort?> LastErrorCode { get; }
    public GpuProperty<ushort?> MaxMemorySupported { get; }
    public GpuProperty<ushort?> MaxNumberControlled { get; }
    public GpuProperty<ushort?> MaxRefreshRate { get; }
    public GpuProperty<ushort?> MinRefreshRate { get; }
    public GpuProperty<ushort?> NumberOfVideoPages { get; }
    public GpuProperty<ushort?> ReservedSystemPaletteEntries { get; }
    public GpuProperty<ushort?> SpecificationVersion { get; }
    public GpuProperty<ushort?> SystemPaletteEntries { get; }
    public GpuArrayProperty<PowerManagementCapabilities> PowerManagementCapabilities { get; }
    public GpuProperty<string> Monochrome { get; }
    public GpuProperty<Version> DriverVersion { get; }
    public GpuProperty<string> ErrorDescription { get; }
    public GpuProperty<string> InfFilename { get; }
    public GpuProperty<string> InfSection { get; }
    public GpuProperty<Strings> InstalledDisplayDrivers { get; }
    public GpuProperty<string> PnpDeviceId { get; }
    public GpuProperty<string> Status { get; }
    public GpuProperty<string> SystemCreationClassName { get; }
    public GpuProperty<string> SystemName { get; }
    public GpuProperty<string> VideoModeDescription { get; }
    public GpuProperty<string> VideoProcessor { get; }
    public GpuProperty<bool?> ErrorCleared { get; }
    public GpuProperty<bool?> PowerManagementSupported { get; }
    public GpuProperty<DateTime> DriverDate { get; }
    public GpuProperty<DateTime?> InstallDate { get; }
    public GpuProperty<DateTime?> TimeOfLastReset { get; }
    public GpuProperty<ushort?> NumberOfColorPlanes { get; }
    public GpuProperty<ProtocolsSupported?> ProtocolSupported { get; }
    public GpuProperty<StatusInfos?> StatusInfo { get; }
    public GpuProperty<VideoArchitectures> VideoArchitecture { get; }
    public GpuProperty<VideoMemoryTypes> VideoMemoryType { get; }
    public GpuProperty<ushort?> VideoMode { get; }

    public static Gpu LoadFrom(ManagementBaseObject obj)
    {
      return Gpu.LoadFrom(GpuDataSource.From(obj));
    }

    public static Gpu LoadFrom(Dictionary<string, object> properties)
    {
      return Gpu.LoadFrom(GpuDataSource.From(properties));
    }
  }
}