using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;
using PiCross;

namespace ViewModel
{
    public class RowViewModel
    {
        private ISequence<IPlayablePuzzleSquare> row;
        private int i;
        public ISequence<CellViewModel> cells { get; private set; }

        public RowViewModel(ISequence<IPlayablePuzzleSquare> row, int i, IPlayablePuzzle puzzle)
        {
			int x = 0;
			var bla = row.Select(e => new CellViewModel(e,i,x++,puzzle));
			cells = Sequence.FromEnumerable(bla);

            this.row = row;
			this.i = i;
		}
    }
}
