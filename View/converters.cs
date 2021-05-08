using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View
{
	public class ConstraintsStatisfied : IValueConverter
	{
		public ConstraintsStatisfied()
		{

		}
		public object Solved { get; set; }

		public object False { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var constraint = (Boolean)value;
			if (constraint == true)
			{
				return Solved;
			}
			else
			{
				return False;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

