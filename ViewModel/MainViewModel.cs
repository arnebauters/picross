using Cells;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Utility;

namespace ViewModel
{
	public class MainViewModel
	{
		public PiCrossFacade PiCrossFacade { get; }
		public Cell<object> CurrentScreen{ get; set; }
		private Chronometer _chrono { get; }

		public MainViewModel() {
			_chrono = new Chronometer();
			var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(200) };
			timer.Tick += TimerTicked;
			timer.Start();
			this.PiCrossFacade = new PiCrossFacade();
			CurrentScreen =  Cell.Create<object>(new StartViewModel(this));



		}
		private void TimerTicked(object sender, EventArgs e)
		{
			_chrono.Tick();
		}

		public Cell<TimeSpan> getTotalTime()
		{
				return _chrono.TotalTime;
		}

		//public Chronometer chronometer
		//{
		//	get
		//	{
		//		return _chrono;
		//	}
		//}
		private void StartCounter()
		{
			_chrono.Start();
		}

		private void StopCounter()
		{
			_chrono.Tick();
			_chrono.Pause();
		}
		public void StartGame()
		{
			_chrono.Reset();
			this.CurrentScreen.Value = new StartViewModel(this);
		}

		public void SelectPuzzle_And_Play(IPlayablePuzzle puzzle)
		{
			StartCounter();
			this.CurrentScreen.Value = new PuzzleViewModel(this, puzzle);
		}

		public void SelectPuzzle_And_Play()
		{
			StartCounter();
			this.CurrentScreen.Value = new PuzzleViewModel(this);
		}

		public void FinishGame()
		{
			StopCounter();
			this.CurrentScreen.Value = new HighScoreViewModel(this);
		}
	}
}
