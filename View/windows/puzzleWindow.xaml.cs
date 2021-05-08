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
using System.Windows.Shapes;

namespace View.windows
{
	/// <summary>
	/// Interaction logic for puzzleWindow.xaml
	/// </summary>
	public partial class puzzleWindow : UserControl
	{

		public puzzleWindow()
		{
			InitializeComponent();
			
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (Media.Volume == 0)
			{
				Media.Volume = 100;
				
			}
			else
			{
				Media.Volume = 0;
			}
		}
	}
}
