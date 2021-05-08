using Cells;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
	public class HighScoreViewModel
	{
		private MainViewModel _main;


		public HighScoreViewModel(MainViewModel main)
		{
			_main = main;
			this.Click = new BackCommand(_main);
		
		}
		public ICommand Click { get; private set; }

		public Cell <TimeSpan> TotalTime
		{
			get
			{
				return _main.getTotalTime();
			}
		}

		private class BackCommand : ICommand
		{
			private MainViewModel _main;

			public BackCommand(MainViewModel main)
			{
				_main = main;
			}

			public event EventHandler CanExecuteChanged;

			public bool CanExecute(object parameter)
			{
				return true;
			}

			public void Execute(object parameter)
			{
				//_main.chronometer.Reset();
				//_main.CurrentScreen.Value = new StartViewModel(_main);
				_main.StartGame();
			}
		}
	}
}
