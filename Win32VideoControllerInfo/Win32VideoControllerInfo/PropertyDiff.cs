namespace Win32VideoControllerInfo
{
  public interface IPropertyDiff
  {
    string Name { get; }
    IGpuProperty Left { get; }
    IGpuProperty Right { get; }
  }

  public class PropertyDiff : IPropertyDiff
  {
    public string Name { get; private set; }
    public IGpuProperty Left { get; private set; }
    public IGpuProperty Right { get; private set; }

    public PropertyDiff(string name, IGpuProperty left, IGpuProperty right)
    {
      Name = name;
      Left = left;
      Right = right;
    }
  }
}