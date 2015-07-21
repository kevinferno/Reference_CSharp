using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeGadgets.CSharp6;

namespace CodeGadgets.CSharp.Tests
{
  [TestClass]
  public class _InterpolatedStrings
  {
    [TestMethod]
    public void InterpolatedStringTest()
    {
      var s = new InterpolatedStrings();
      var res = s.GetInfo_NewWay();
      Assert.AreEqual(@"Skellington, Jack 284    1042.97", res);
    }
  }
}
