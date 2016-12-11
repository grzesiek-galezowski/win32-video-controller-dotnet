using System;
using System.Linq;

namespace Win32VideoControllerInfo.PropertyTypes
{
  public class GpuArrayProperty<T> : IGpuProperty, IEquatable<GpuArrayProperty<T>>
  {
    public bool Equals(GpuArrayProperty<T> other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return Property
        .SequenceEqual(other.Property) && string.Equals(PropertyName, other.PropertyName);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((GpuArrayProperty<T>) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return ((Property != null ? Property.GetHashCode() : 0)*397) ^ (PropertyName != null ? PropertyName.GetHashCode() : 0);
      }
    }

    public static bool operator ==(GpuArrayProperty<T> left, GpuArrayProperty<T> right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(GpuArrayProperty<T> left, GpuArrayProperty<T> right)
    {
      return !Equals(left, right);
    }

    public GpuArrayProperty(string propertyName, T[] property)
    {
      PropertyName = propertyName;
      Property = property ?? new T[] {};
    }

    public T[] Property { get; }

    public string PropertyName { get; }
  }
}