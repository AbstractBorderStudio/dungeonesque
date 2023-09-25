using Godot;
using System;

namespace Dungeonesque
{
	public partial class GameMenu : State
	{
		[Export]
		private CardDisplay cardDisplay;
		[ExportGroup("Buttons")]
		[Export]
		private Button quit;

		public override void _Ready()
		{
			//quit.ButtonUp += () => OnExitState(false);
		}

		public override void OnExitState(bool next)
		{
			EmitSignal("Transition", next);
			this.Visible = false;
		}

		public override void OnEnterState()
		{
			foreach (Player p in Game.Instance.Players)
				cardDisplay.AddCard(p);
			this.Visible = true;
		}
	}
}
