using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeGadgets.CSharp6
{
  public partial class DependencyPropertyExample : UserControl
  {
    public DependencyPropertyExample()
    {
      InitializeComponent();
    }

    /// <summary>Pre Version 6, DependencyProperty.Register used a literal string in the first parameter.</summary>
    public static readonly DependencyProperty Version5DependencyPropertyProperty =
       DependencyProperty.Register("Version5DependencyProperty", typeof(string), typeof(DependencyPropertyExample), new PropertyMetadata(0));
    /// <summary>In Version 6, DependencyProperty.Register can now use nameof to simplify renaming and refactoring.</summary>
    public static readonly DependencyProperty Version6DependencyPropertyProperty =
        DependencyProperty.Register(nameof(Version6DependencyProperty), typeof(string), typeof(DependencyPropertyExample), new PropertyMetadata(0));

    public string Version5DependencyProperty
    {
      get { return (string)GetValue(Version5DependencyPropertyProperty); }
      set { SetValue(Version5DependencyPropertyProperty, value); }
    }
    public string Version6DependencyProperty
    {
      get { return (string)GetValue(Version6DependencyPropertyProperty); }
      set { SetValue(Version6DependencyPropertyProperty, value); }
    }
  }
}
