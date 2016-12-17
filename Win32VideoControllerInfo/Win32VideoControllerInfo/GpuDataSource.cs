using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using Win32VideoControllerInfo.SpecialTypes;

namespace Win32VideoControllerInfo
{
  public class GpuDataSource : IGpuDataSource
  {
    private GpuDataSource(Dictionary<string, object> properties)
    {
      Values = properties;
    }

    private static Dictionary<string, object> TranslateToDictionary(ManagementBaseObject values)
    {
      Dictionary<string, object> values2 = new Dictionary<string, object>();

      foreach (var valuesProperty in values.Properties)
      {
        values2[valuesProperty.Name] = valuesProperty.Value;
      }
      return values2;
    }

    private Dictionary<string, object> Values { get; } = new Dictionary<string, object>();

    public DateTime? NullableDateTime(string propertyName)
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

    public T? Nullable<T>(string propertyName) where T : struct
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

    public T? NullableEnum<T>(string propertyName) where T : struct
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

    public Strings Strings(string propertyName)
    {
      var value = Values[propertyName].ToString();
      return new Strings(value.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries));
    }

    public T[] EnumArray<T>(string propertyName)
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

    public T[] Array<T>(string propertyName)
    {
      if (Values[propertyName] == null)
      {
        return null;
      }
      var value = ((object[])Values[propertyName])
        .Select<object, object>(o => ConvertType(o, typeof(T)))
        .Cast<T>()
        .ToArray();
      return value;
    }

    public T Value<T>(string propertyName)
    {
      var value = Values[propertyName];
      return (T)ConvertType(value, typeof(T));
    }

    private static object ConvertType(object value, Type type)
    {
      return Convert.ChangeType(value, type);
    }

    public Version Version(string propertyName)
    {
      return System.Version.Parse(Values[propertyName].ToString());
    }

    public static GpuDataSource From(ManagementBaseObject obj)
    {
      return From(TranslateToDictionary(obj));
    }

    public static GpuDataSource From(Dictionary<string, object> properties)
    {
      return new GpuDataSource(properties);
    }
  }
}