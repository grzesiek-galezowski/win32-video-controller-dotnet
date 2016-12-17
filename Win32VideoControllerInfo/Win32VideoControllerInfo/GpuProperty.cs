using Win32VideoControllerInfo.PropertyTypes;

namespace Win32VideoControllerInfo
{
  internal static class GpuProperty
  {
    public static GpuProperty<T> Get<T>(string propertyName, T value)
    {
      var gpuProperty = new GpuProperty<T>(propertyName, value);
      return gpuProperty;
    }

    public static GpuProperty<string> GetString(string propertyName, IGpuDataSource dataSource)
    {
      return Get(propertyName, dataSource.Value<string>(propertyName));
    }

    public static GpuProperty<T?> GetNullable<T>(string propertyName, IGpuDataSource fromSource) where T : struct
    {
      return GpuProperty.Get(propertyName, fromSource.Nullable<T>(propertyName));
    }
  }
}