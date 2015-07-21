using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGadgets.CSharp6
{
	/// <summary>Examples of the use of the Null Conditional operators, ?. and ?[, for member and indexed properties, respectively.</summary>
	public class Operator_nullConditional : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>OLD WAY: Assignment of event handler to temporary variable. This works, and still works and is thread safe.</summary>
		protected virtual void OnPropertyChanged_Old(string propertyName)
		{
			var handler = this.PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>WRONG WAY: A race condition exists here. If PropertyChanged becomes null between the null check and the call to the delegate,
		/// and untrapped Null property exception would occur.</summary>
		protected virtual void OnPropertyChanged_Wrong(string propertyName)
		{
			if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		/// <summary>NEW WAY: The null-conditional operator use is thread-safe because the compiler evaluates the PropertyChanged event only once.
		/// A temporary variable is used, just as in the OLD WAY, but behind the scenes.</summary>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

			// Invoke must be called because ?(, null conditional invoking of a delegate is not supported.
			// PropertyChanged?(this, new PropertyChangedEventArgs(propertyName));
		}
		/// <summary>OLD WAY: Each member class needs to be checked for null before accessing additional members.</summary>
		public string GetName_OldWay(InterestingClass src)
		{
			if (src == null) return null;
			if (src.Member == null) return null;
			if (src.Member.FirstName == null || src.Member.LastName == null) return null;
			return src.Member.LastName;
		}
		/// <summary>NEW WAY: Each member is checked for null, and short-circuits and returns null if the member to the left of the ?. operator is null.</summary>
		public string GetName_NewWay(InterestingClass src)
		{
			return src?.Member?.LastName;
		}

		/// <summary>Indexed properties create additional issues when the possibility of null is involved.</summary>
		public string GetIndexedMember_OldWay(InterestingClass src)
		{
			if (src == null) return null;
			if (src.Collection == null) return null;
			if (src.Collection[0] == null) return null;
			return src.Collection[0].FirstName;
		}
		/// <summary>NEW WAY: Null Conditionals operate on Indexed properties.</summary>
		public string GetIndexedMember_NewWay(InterestingClass src)
		{
			// In this case, src is checked for null,
			// Then Collection property is checked,
			// Then the first member of the collection is checked
			// Finally returning the desired property
			return src?.Collection?[0]?.FirstName;
		}
		/// <summary>Linq function FirstOrDefault benefits from null conditional operator, as for reference types, first or default
		/// return null if no member is found.</summary>
		public string GetLinqMemberUsingNull()
		{
			InterestingClass ic = new InterestingClass();
			ic.Collection = new List<InterestingMemberClass>();
			ic.Collection.Add(new InterestingMemberClass() { FirstName = "Jack", LastName = "Skellington" });
			ic.Collection.Add(new InterestingMemberClass() { FirstName = "Sally", LastName = "Doll" });

			return ic.Collection.FirstOrDefault(m => m.FirstName == "Jack")?.FirstName;
		}
	}

	public class InterestingClass
	{
		public InterestingMemberClass Member { get; set; }

		public List<InterestingMemberClass> Collection
		{
			get { return this._Collection; }
			set { this._Collection = value; }
		}

		private List<InterestingMemberClass> _Collection;
	}
	public class InterestingMemberClass
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
