using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeGadgets.CSharp6;
using System.ComponentModel;

namespace CodeGadgets.CSharp.Tests.V6
{
  [TestClass]
  public class _Operator_nameof
  {
    [TestMethod]
    public void ValidateParameters()
    {
      Operator_nameof ono = new Operator_nameof();

      // Operator_nameof class throws ArgumentNullException using nameof on the parameter of the method.
      try { ono.ValidateParameters(null); }
      catch (ArgumentNullException ex) { Assert.AreEqual("src", ex.ParamName); }
    }

    [TestMethod]
    public void NotifyPropertyChanged()
    {
      Operator_nameof ono = new Operator_nameof();

      ono.Description = "Test Description 1";
      Assert.AreEqual(0, ono.PropertyChangedInvokeCount);

      ono.PropertyChanged += Ono_PropertyChanged;
      ono.Description = "Test Description 2";
      Assert.AreEqual(1, ono.PropertyChangedInvokeCount);

      ono.PropertyChanged -= Ono_PropertyChanged;
      ono.Description = "Test Description 3";
      Assert.AreEqual(1, ono.PropertyChangedInvokeCount);
    }

    private void Ono_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      var ono = sender as Operator_nameof;
      if (ono != null) ono.PropertyChangedInvokeCount++;
    }
  }
}
