using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Win32Interop.WinHandles.Tests
{
  public class TopLevelWindowUtilsTests
  {
    [Test]
    public void ListAllWindows()
    {
      var allWindows = TopLevelWindowUtils.FindWindows(w => w.GetWindowText() != "");

      Console.WriteLine("All the windows that are currently present:");

      foreach (var windowHandle in allWindows)
      {
        Console.WriteLine(windowHandle.GetWindowText());
      }
    }

    [Test]
    public void ShowForeground()
    {
      var windowHandle = TopLevelWindowUtils.GetForegroundWindow();
      Console.WriteLine(windowHandle.GetWindowText());
    }
  }
}