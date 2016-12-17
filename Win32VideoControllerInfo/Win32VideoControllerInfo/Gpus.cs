using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace Win32VideoControllerInfo
{
  public class Gpus : IEnumerable<IGpu>
  {
    private readonly List<IGpu> _gpus;

    private Gpus(List<IGpu> gpus)
    {
      _gpus = gpus;
    }

    public static Gpus Load()
    {
      var gpus = new List<IGpu>();
      var managementObjectCollection = new ManagementObjectSearcher("select * from Win32_VideoController").Get();
      foreach (var obj in managementObjectCollection)
      {
        gpus.Add(Gpu.LoadFrom(obj));
      }

      return new Gpus(gpus);
    }

    public IEnumerator<IGpu> GetEnumerator()
    {
      return _gpus.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}