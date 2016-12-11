// ReSharper disable UnusedMember.Global
namespace Win32VideoControllerInfo.Enums
{
  public enum ConfigManagerErrorCodes
  {
    WorkingProperly = 0,
    NotConfiguredCorrectly = 1,
    CannotLoadDriver = 2,
    DriverCorruptedOrSystemLowOnResources = 3,
    DriverOrRegistryCorrupted = 4,
    NeedsResourceWindowsCannotManage = 5,
    BootConfigurationConflictsWithOtherDevices = 6,
    CannotFilter = 7,
    DriverLoaderMissing = 8,
    FirmwareReportingResourcesIncorrectly = 9,
    CannotStart = 10,
    Failed = 11,
    NotEnoughFreeResources = 12,
    CannotVerifyResources = 13,
    RestartRequired = 14,
    ReEnumerationProblem = 15,
    CannotIdentifyResources = 16,
    UnknownResourceTypeRequested = 17,
    DriversReinstallRequired = 18,
    VxDLoaderFailure = 19,
    RegistryCorrupted = 20,
    SystemFailureDeviceRemoved = 21,
    Disabled = 22,
    SystemFailureBadDriver = 23,
    NotPresentOrWorkingOrInstalled = 24,
    SetUpInProgress = 25,
    SetUpInProgress2 = 26,
    InvalidLogConfiguration = 27,
    DriversNotInstalled = 28,
    FirmwareRejectedResources = 29,
    IrqConflict = 30,
    UnableToLoadDrivers = 31,
  }
}