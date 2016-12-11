using System;
using System.Collections.Generic;

namespace Win32VideoControllerInfo.PropertyTypes
{
  public class GpuProperty<T> : IEquatable<GpuProperty<T>>, IGpuProperty
  {
    public GpuProperty(string propertyName, T property)
    {
      PropertyName = propertyName;
      Property = property;
    }

    public string PropertyName { get; }
    public T Property { get; }


    public bool Equals(GpuProperty<T> other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return string.Equals(PropertyName, other.PropertyName) 
        && EqualityComparer<T>.Default.Equals(Property, other.Property);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((GpuProperty<T>) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return ((PropertyName != null ? PropertyName.GetHashCode() : 0)*397) ^ EqualityComparer<T>.Default.GetHashCode(Property);
      }
    }

    public static bool operator ==(GpuProperty<T> left, GpuProperty<T> right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(GpuProperty<T> left, GpuProperty<T> right)
    {
      return !Equals(left, right);
    }

    public override string ToString()
    {
      return Property?.ToString() ?? string.Empty;
    }
  }
}