using Godot;
using System;
using System.Collections.Generic;

namespace Dungeonesque
{
	enum GameState
	{
		None,
		Narrator,
		Player
	}
	public partial class GameMenu : State
	{
		[ExportGroup("Buttons")]
		[Export]
		private Button rand;
		[ExportGroup("Misc")]
		[Export]
		private CardDisplay cardDisplay;
		[Export]
		private StoryContainer storyContainer;

		[ExportGroup("Game logic")]
		[Export]
		private int narratorTime = 120, playerTime = 60;
		private int enlapsedTime;
		private GameState gameState;

		public override void _Ready()
		{
			gameState = GameState.None;
			
			rand.ButtonUp += () => RandomizeHighlight()	;
		}

        public override void _Process(double delta)
        {
            switch (gameState)
			{
				case (GameState.None):
					// do nothig
					break;
				case (GameState.Narrator):
					break;
				case (GameState.Player):
					break;
			}
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
			// set story
			storyContainer.SetStoryContainer(Game.Instance.Story);
			this.Visible = true;
		}

		public void RandomizeHighlight()
		{
			Random random = new Random();
			cardDisplay.HighlightCard(random.Next(0, Game.Instance.Players.Count));
		}

		private void NextPlayer()
		{
			
		}
	}
}
