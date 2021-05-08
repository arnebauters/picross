using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;
using Utility;

namespace ViewModel
{
    public class PuzzleViewModel

    {
        public IPlayablePuzzle playablePuzzle;
        public GridViewModel GridViewModel { get; }
        public ISequence<IPlayablePuzzleConstraints> RowConstraints { get; set; }
        public ISequence<IPlayablePuzzleConstraints> ColumnConstraints { get; set; }
		private MainViewModel _main;
		//private readonly Chronometer _chrono;
		public ICommand Click { get; private set; }
		public ICommand Reset { get; private set; }

		public PuzzleViewModel(MainViewModel main)
        {
			_main = main;
			var puzzle = Puzzle.FromRowStrings(
				".x..x",
				"x...x",
	            "xx..x",
	            "x..xx",
	            "xxxxx"
			);
			
           	playablePuzzle = _main.PiCrossFacade.CreatePlayablePuzzle(puzzle);
            GridViewModel = new GridViewModel(playablePuzzle);
            RowConstraints = playablePuzzle.RowConstraints;
            ColumnConstraints = playablePuzzle.ColumnConstraints;
			this.Click = new BackCommand(_main);
			this.Reset = new ResetCommand(playablePuzzle);

			Solved.ValueChanged += Solved_ValueChanged;
			//_chrono = _main.chronometer;
			//StartCounter();
		}
		public PuzzleViewModel(MainViewModel main, IPlayablePuzzle puzzle)
		{
			_main = main;
			playablePuzzle = puzzle;
			GridViewModel = new GridViewModel(playablePuzzle);
			RowConstraints = playablePuzzle.RowConstraints;
			ColumnConstraints = playablePuzzle.ColumnConstraints;
			this.Click = new BackCommand(_main);
			this.Reset = new ResetCommand(playablePuzzle);

			Solved.ValueChanged += Solved_ValueChanged;
			//_chrono = _main.chronometer;
			//StartCounter();
		}

		public Cell<TimeSpan> PlayTime => _main.getTotalTime();
		//private void StartCounter()
		//{
		//	_chrono.Start();
		//}

		//private void StopCounter()
		//{
		//	_chrono.Tick();
		//	_chrono.Pause();
		//}
		private void Solved_ValueChanged()
		{
			if (Solved.Value)
			{
				//StopCounter();
				_main.FinishGame();
				//_main.CurrentScreen.Value = new HighScoreViewModel(_main);
			}
		}

		public Cell<bool> Solved
		{
			get
			{
				return playablePuzzle.IsSolved;
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
				_main.StartGame();
				//_main.CurrentScreen.Value = new StartViewModel(_main);
			}
		}
		private class ResetCommand : ICommand
		{
			private  IPlayablePuzzle _puzzle;

			public ResetCommand(IPlayablePuzzle puzzle)
			{
				_puzzle = puzzle;
			}

			public event EventHandler CanExecuteChanged;

			public bool CanExecute(object parameter)
			{
				return true;
			}

			public void Execute(object parameter)
			{
				foreach(var e in _puzzle.Grid.Items)
				{
					e.Contents.Value = Square.UNKNOWN;
				}
			}
		}

	}
    public class SquareConverter : IValueConverter
    {
		public SquareConverter() {

		}
		public object Filled { get; set; }

        public object Empty { get; set; }

        public object Unknown { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var square = (Square)value;
            if (square == Square.EMPTY)
            {
                return Empty;
            }
            else if (square == Square.FILLED)
            {
                return Filled;
            }
            else
            {
                return Unknown;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
