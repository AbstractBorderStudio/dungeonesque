using Godot;

namespace Dungeonesque
{
	public partial class MainMenu : State
	{
		[Export]
		private AnimationPlayer menuAnim;

		[Export]
		private Button play, exit, credits, closeCredits;

		public override void _Ready()
		{
			play.ButtonUp += () => OnExitState(true); 
			exit.ButtonUp += () => OnExitState(false);
			credits.ButtonUp += () => menuAnim.Play("credits_in");
			closeCredits.ButtonUp += () => menuAnim.Play("credits_out");
		}

		public override void OnExitState(bool next)
		{
			// do stuff
			//menuAnim.Play("exit");
			if (next)
				this.Visible = false;
			EmitSignal("Transition", next);
		}

		public override void OnEnterState()
		{
			//menuAnim.Play("enter");
			this.Visible = true;
		}
	}
}


