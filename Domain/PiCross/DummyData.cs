using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiCross;

namespace PiCross
{
    internal class DummyData
    {
        public static InMemoryDatabase Create()
        {
            var data = new DummyData();

            return new InMemoryDatabase( data.Puzzles, data.Players );
        }

        public DummyData()
        {
            this.Puzzles = CreateDummyLibrary();
            this.Players = CreateDummyPlayerDatabase();
        }

        public InMemoryDatabase.PuzzleLibrary Puzzles { get; }

        public InMemoryDatabase.PlayerDatabase Players { get; }

        private static InMemoryDatabase.PlayerDatabase CreateDummyPlayerDatabase()
        {
            var db = InMemoryDatabase.PlayerDatabase.CreateEmpty();

            var woumpousse = db.CreateNewProfile( "Woumpousse" );
            var pimousse = db.CreateNewProfile( "Pimousse" );

            return db;
        }

        private static Puzzle Puzzle1
        {
            get
            {
                return Puzzle.FromRowStrings(
                    "..x..",
                    ".x.x.",
                    "x.x.x",
                    ".x.x.",
                    "x.x.x"
                    );
            }
        }

        private static Puzzle Puzzle2
        {
            get
            {
                return Puzzle.FromRowStrings(
                    "x...x",
                    ".x.x.",
                    "..x..",
                    ".x.x.",
                    "x...x"
                    );
            }
        }

        private static Puzzle Puzzle3
        {
            get
            {
                return Puzzle.FromRowStrings(
                    ".x..x",
                    "..xx.",
                    "..x..",
                    "x...x",
                    ".xxx."
                    );
            }
        }

        private static Puzzle Puzzle4
        {
            get
            {
                return Puzzle.FromRowStrings(
                    "..x..",
                    ".xxx.",
                    "xxxxx",
                    ".xxx.",
                    "..x.."
                    );
            }
        }

        private static Puzzle Puzzle5
        {
            get
            {
                return Puzzle.FromRowStrings(
                    ".x.",
                    "x.x",
                    ".x."
                    );
            }
        }

        private static Puzzle Puzzle6
        {
            get
            {
                return Puzzle.FromRowStrings(
                    "x..x",
					".xx.",
					".xx.",
					"x..x"
                    );
            }
        }


		private static InMemoryDatabase.PuzzleLibrary CreateDummyLibrary()
        {
            var library = InMemoryDatabase.PuzzleLibrary.CreateEmpty();

            var author1 = "Woumpousse";
			var author2 = "Arne";
			var author3 = "Pimousse";

			library.Create( Puzzle1, author1 );
            library.Create( Puzzle2, author2 );
            library.Create( Puzzle3, author2 );
            library.Create( Puzzle4, author3 );
            library.Create( Puzzle5, author1 );
            library.Create( Puzzle6, author2 );

			return library;
        }
    }
}
