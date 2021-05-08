using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
	public class StartViewModel
	{
		private MainViewModel mainViewModel;
		public IEnumerable<IPuzzleLibraryEntry> Puzzles { get; }
		public ICommand Select { get; }
		public ICommand Click { get; private set; }

		public StartViewModel(MainViewModel mainViewModel)
		{
			this.mainViewModel = mainViewModel;
			var data = mainViewModel.PiCrossFacade.CreateDummyGameData();
			Puzzles = data.PuzzleLibrary.Entries;
			this.Click = new PlayCommand(mainViewModel);
			this.Select = new PuzzleCommand(mainViewModel);
		}
	
		private class PlayCommand : ICommand
		{
			private MainViewModel _main;

			public PlayCommand(MainViewModel main)
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
				//_main.CurrentScreen.Value = new PuzzleViewModel(_main);
				_main.SelectPuzzle_And_Play();
			}
		}
		private class PuzzleCommand : ICommand
		{
			private MainViewModel _main;

			public PuzzleCommand(MainViewModel main)
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
				var puzzle = parameter as Puzzle;
				var playablePuzzle = _main.PiCrossFacade.CreatePlayablePuzzle(puzzle);
				//_main.CurrentScreen.Value = new PuzzleViewModel(_main, playablePuzzle);
				_main.SelectPuzzle_And_Play(playablePuzzle);
			}
		}
	}

}
