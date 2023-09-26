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
		private Button next;
		[ExportGroup("Misc")]
		[Export]
		private CardDisplay cardDisplay;
		[Export]
		private StoryContainer storyContainer;
		[Export]
		private CurrentPlayerContainer currentPlayerContainer;
		[Export]
		private Control narratorMenu;

		[ExportGroup("Game logic")]
		[Export]
		private int narratorTime = 120, playerTime = 60;
		private int enlapsedTime;
		private GameState gameState;
		
		private int nextPlayer = 0;

		public override void _Ready()
		{
			gameState = GameState.None;
			next.ButtonUp += () => ChangeState();
			currentPlayerContainer.Timeout += () => ChangeState();
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
					currentPlayerContainer.UpdateBar((float)delta);
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
			ChangeState();

			List<Player> _players = Game.Instance.Players;
			for (int i = 0; i < _players.Count; i++)
			{
				cardDisplay.AddCard(_players[i]);
			}
			// set story
			storyContainer.SetStoryContainer(Game.Instance.Story);
			this.Visible = true;
		}

		private void NextPlayer()
		{
			currentPlayerContainer.SetCurrent(Game.Instance.Players[nextPlayer]);
			
			// circular buffer
			nextPlayer += 1;
			nextPlayer %= Game.Instance.Players.Count;
		}

		private void ChangeState()
		{
			switch (gameState)
			{
				case (GameState.None):
					NextPlayer();
					gameState = GameState.Player;
					break;
				case (GameState.Narrator):
					narratorMenu.Hide();
					currentPlayerContainer.Show();
					gameState = GameState.Player;
					NextPlayer();
					break;
				case (GameState.Player):
					currentPlayerContainer.Hide();
					narratorMenu.Show();
					gameState = GameState.Narrator;
					break;
			}
		}
	}
}
