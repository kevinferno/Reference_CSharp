using System;
using System.ComponentModel;
using System.Windows;

namespace CodeGadgets.CSharp6
{
  /// <summary>Functional examples of new features in C# Version 6.</summary>
  public class Operator_nameof : INotifyPropertyChanged
  {
    /// <summary>Use of nameof Operator in throw of ArgumentNullException</summary>
    /// <param name="src"></param>
    public void ValidateParameters(string src)
    {
      if (src == null) throw new ArgumentNullException(nameof(src));
    }

    /// <summary>Count of hooked Invokes for PropertyChanged event</summary>
    public int PropertyChangedInvokeCount { get; set; }

    /// <summary>Use of nameof Operator in PropertyChanged call</summary>
    public string Description
    {
      get { return this._Description; }
      set
      {
        if (this._Description == value) return;
        this._Description = value;
        this.OnPropertyChanged(nameof(Description));
      }
    }



    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    private string _Description;
    public Operator_nameof_member MemberClass { get; set; }
  }

  public class Operator_nameof_member
  {
    public string Info { get; set; }
  }
}
