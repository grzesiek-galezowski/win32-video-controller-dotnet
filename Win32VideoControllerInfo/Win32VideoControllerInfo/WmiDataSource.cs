using System;
using Win32VideoControllerInfo.SpecialTypes;

namespace Win32VideoControllerInfo
{
  public interface IGpuDataSource
  {
    DateTime? NullableDateTime(string propertyName);
    T? Nullable<T>(string propertyName) where T : struct;
    T? NullableEnum<T>(string propertyName) where T : struct;
    Strings Strings(string propertyName);
    T[] EnumArray<T>(string propertyName);
    T[] Array<T>(string propertyName);
    T Value<T>(string propertyName);
    Version Version(string propertyName);
  }
}