using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGadgets.CSharp6
{
	/// <summary>Interpolated strings allow for direct insertion of expressions into formatted strings.</summary>
  public class InterpolatedStrings
  {
    public string FirstName { get; set; } = @"Jack";
    public string LastName { get; set; } = "Skellington";
    public int Age { get; set; } = 284;
    public float Rank { get; set; } = 1042.9678F;


    public string GetInfo_NewWay()
    {
      return $"{LastName}, {FirstName} {Age:D3} {Rank,10:F2}";
    }

		public string GetInfo_OldWay()
		{
			return string.Format("@{0}, {1}, {2:D3}, {3,10:F2}", LastName, FirstName, Age, Rank);
		}
  }
}
