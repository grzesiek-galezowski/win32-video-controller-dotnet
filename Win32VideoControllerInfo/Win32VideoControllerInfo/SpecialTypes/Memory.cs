using System;

namespace Win32VideoControllerInfo.SpecialTypes
{
  public class Memory : IEquatable<Memory>
  {
    public bool Equals(Memory other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return _bytes == other._bytes;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((Memory) obj);
    }

    public override int GetHashCode()
    {
      return (int) _bytes;
    }

    public static bool operator ==(Memory left, Memory right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(Memory left, Memory right)
    {
      return !Equals(left, right);
    }

    private readonly uint _bytes;

    public static Memory FromBytes(uint bytes)
    {
      return new Memory(bytes);
    }

    private Memory(uint bytes)
    {
      _bytes = bytes;
    }

    public decimal KB => _bytes/1024;
    public decimal MB => KB/1024;
    public decimal GB => MB/1024;

    public override string ToString()
    {
      return $"{_bytes}B, ~{KB}{nameof(KB)}, ~{MB}{nameof(MB)}, ~{GB}{nameof(GB)}";
    }
  }
}