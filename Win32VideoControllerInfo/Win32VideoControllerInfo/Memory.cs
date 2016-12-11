namespace Win32VideoControllerInfo
{
  public class Memory
  {
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