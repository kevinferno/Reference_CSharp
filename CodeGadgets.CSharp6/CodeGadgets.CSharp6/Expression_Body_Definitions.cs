using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGadgets.CSharp6
{
	public class Expression_Body_Definitions
	{
		/// <summary>Standard Function Body Definition</summary>
		public string GetStringToUpper_Normal(string src)
		{
			return src.ToUpper();
		}
		/// <summary>Expression shortcut for Function Body Definition. Keyword return is not used because of lambda expression syntax.</summary>
		public string GetStringToUpper_Short(string src) => src.ToUpper();
	}
}
