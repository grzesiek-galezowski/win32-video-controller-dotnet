using System;
using System.Collections.Generic;
using Win32VideoControllerInfo.Enums;
using Win32VideoControllerInfo.PropertyTypes;
using Win32VideoControllerInfo.SpecialTypes;

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
    GpuArrayProperty<string> CapabilityDescriptions { get; }
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
    GpuArrayProperty<PowerManagementCapabilities> PowerManagementCapabilities { get; }
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
    List<PropertyDiff> CalculateDifferencesAgainst(IGpu otherGpu);
    List<PropertyDiff> CalculateDifferencesAgainst(SortedDictionary<string, IGpuProperty> otherGpuProperties);
  }
}