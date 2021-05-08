using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;
using PiCross;

namespace ViewModel
{
    public class ColumnViewModel
    {
        private ISequence<IPlayablePuzzleSquare> column;
        private int j;
        public ISequence<CellViewModel> cells { get; private set; }

        public ColumnViewModel(ISequence<IPlayablePuzzleSquare> column, int j, IPlayablePuzzle puzzle)
        {
			int x = 0;
			var bla = column.Select(e => new CellViewModel(e, j, x++, puzzle));
			cells = Sequence.FromEnumerable(bla);

			this.column = column;
            this.j = j;
        }
    }
}
