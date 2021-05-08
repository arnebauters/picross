using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cells;
using DataStructures;
using PiCross;

namespace ViewModel
{
    public class CellViewModel
    {
		private IPlayablePuzzleSquare e;
		private IPlayablePuzzle puzzle;
		private int position_x;
		private int position_y;

		public CellViewModel(IPlayablePuzzleSquare e, int i, int v, IPlayablePuzzle puzzle)
		{
			this.e = e;
			this.position_y = i;
			this.position_x = v;
			this.puzzle = puzzle;
			this.Click = new ClickCommand(e, puzzle);
			this.Contents = e.Contents;
		}

		public ICommand Click { get; private set; }

		public Cell<Square> Contents { get; }

		public Vector2D Position { get; }


		private class ClickCommand : ICommand
		{
			private IPlayablePuzzleSquare _square;
			private IPlayablePuzzle _puzzle;

			public ClickCommand(IPlayablePuzzleSquare square, IPlayablePuzzle puzzle)
			{
				_square = square;
				_puzzle = puzzle;
			}

			public event EventHandler CanExecuteChanged;

			public bool CanExecute(object parameter)
			{
				if (!_puzzle.IsSolved.Value)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			public void Execute(object parameter)
			{
				if(_square.Contents.Value == Square.FILLED)
				{
					_square.Contents.Value = Square.EMPTY;
				}
				else
				{
					_square.Contents.Value = Square.FILLED;
				}
			}
		}
	}
}
