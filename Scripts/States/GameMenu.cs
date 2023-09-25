using Godot;
using System;
using System.Collections.Generic;

namespace Dungeonesque
{
	public partial class GameMenu : State
	{
		[Export]
		private CardDisplay cardDisplay;
		[ExportGroup("Buttons")]
		[Export]
		private Button rand;

		public override void _Ready()
		{
			rand.ButtonUp += () => RandomizeHighlight()	;
		}

		public override void OnExitState(bool next)
		{
			EmitSignal("Transition", next);
			this.Visible = false;
		}

		public override void OnEnterState()
		{
			List<Player> _players = Game.Instance.Players;
			for (int i = 0; i < _players.Count; i++)
			{
				cardDisplay.AddCard(_players[i]);
			}
			this.Visible = true;
		}

		public void RandomizeHighlight()
		{
			Random random = new Random();
			cardDisplay.HighlightCard(random.Next(0, Game.Instance.Players.Count));
		}
	}
}
