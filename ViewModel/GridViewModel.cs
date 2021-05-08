using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;
using PiCross;

namespace ViewModel
{
    public class GridViewModel : IGrid<CellViewModel>
    {
        public IGrid<IPlayablePuzzleSquare> playGrid { get; }
        public IEnumerable<RowViewModel> Rows { get; private set; }
        public IEnumerable<ColumnViewModel> Columns { get; private set; }

        public Size Size
        {
            get
            {
                return playGrid.Size;
            }
        }

        public IEnumerable<Vector2D> AllPositions
        {
            get
            {
                return playGrid.AllPositions;
            }
        }

        public IEnumerable<int> RowIndices
        {
            get
            {
                return playGrid.RowIndices;
            }
        }

        public IEnumerable<int> ColumnIndices
        {
            get
            {
                return playGrid.ColumnIndices;
            }
        }

        public IEnumerable<CellViewModel> Items
        {
            get
			{
				foreach (var r in Rows) {
					foreach(var el in r.cells)
					{
						yield return el;
					}
				}
			}
        }

		IEnumerable<ISequence<CellViewModel>> IGrid<CellViewModel>.Rows
		{
			get
			{
				foreach(var r in Rows)
				{
					yield return r.cells;
				}
			}
		}

		IEnumerable<ISequence<CellViewModel>> IGrid<CellViewModel>.Columns
		{
			get
			{
				foreach(var c in Columns)
				{
					yield return c.cells;
				}
			}
		}

		public CellViewModel this[Vector2D position]
		{
			get
			{
				var row = position.Y;
				var column = position.X;

				return Rows.ElementAt(row).cells.ElementAt(column);
			}
		}

		public GridViewModel(IPlayablePuzzle puzzle)
        {
            playGrid = puzzle.Grid;

            var list = new List<RowViewModel>();
            int i = 0;
            foreach (var row in playGrid.Rows)
            {
                list.Add(new RowViewModel(row, i, puzzle));
                i++;
            }
            Rows = list;

            var list2 = new List<ColumnViewModel>();
            int j = 0;
            foreach (var column in playGrid.Columns)
            {
                list2.Add(new ColumnViewModel(column, j, puzzle));
                j++;
            }
            Columns = list2;
        }

        public bool IsValidPosition(Vector2D position)
        {
			return playGrid.IsValidPosition(position);
        }

        public ISequence<CellViewModel> Row(int index)
        {
			return Rows.ElementAt(index).cells;
        }

        public ISequence<CellViewModel> Column(int index)
        {
			return Columns.ElementAt(index).cells;
		}
    }
}
