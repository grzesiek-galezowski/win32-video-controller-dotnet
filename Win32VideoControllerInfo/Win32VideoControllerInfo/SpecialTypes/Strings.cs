using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Win32VideoControllerInfo.SpecialTypes
{
  public class Strings : IEnumerable<string>, IEquatable<Strings>
  {
    public bool Equals(Strings other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return _values.SequenceEqual(_values);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((Strings) obj);
    }

    public override int GetHashCode()
    {
      return (_values != null ? _values.GetHashCode() : 0);
    }

    public static bool operator ==(Strings left, Strings right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(Strings left, Strings right)
    {
      return !Equals(left, right);
    }

    private readonly string[] _values;

    public Strings(string[] values)
    {
      _values = values;
    }

    public IEnumerator<string> GetEnumerator()
    {
      return _values.ToList().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public override string ToString()
    {
      return string.Join(", ", _values);
    }
  }
}