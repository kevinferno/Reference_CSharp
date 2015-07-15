using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGadgets.CSharp6
{
  public class InterpolatedStrings
  {
    public string FirstName { get; set; } = @"Jack";
    public string LastName { get; set; } = "Skellington";
    public int Age { get; set; } = 284;
    public float Rank { get; set; } = 1042.9678F;


    public string GetInfo()
    {
      return $"{LastName}, {FirstName} {Age:D3} {Rank,10:F2}";
    }
  }
}
