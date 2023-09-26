using Dungeonesque;
using Godot;
using System;

namespace Dungeonesque
{
	public partial class CurrentPlayerContainer : Control
	{
		[Signal] public delegate void TimeoutEventHandler();

		[Export]
		private Label name, ability, item;
		[Export]
		private ProgressBar bar;
		[Export]
		private AnimatedSprite2D dice;
		[Export]
		private Button diceButton;

		private Timer rollTime;
		private float rollMaxtTime = 0.05f;
		private int rollCount = 0;
		private bool rolling = false;

        public override void _Ready()
        {
			diceButton.ButtonUp += () => StartRoll();

			rollTime = new Timer();
			rollTime.Autostart = false;
			rollTime.OneShot = false;
			rollTime.WaitTime = rollMaxtTime;
			rollTime.Timeout += () => Roll();
			this.AddChild(rollTime);
		}

        public void SetCurrent(Player p)
		{
			name.Text = p.Nickname;
			ability.Text = p.Ability;
			item.Text = p.Item;

			dice.Frame = 0;
			ResetBar();
		}

		public void ResetBar()
		{
			bar.Value = 60;

			Label l = bar.GetChild<Label>(0);
			l.Text = bar.MaxValue + "s";
		}

		public void UpdateBar(float val)
		{
			bar.Value -= val;
			
			if (bar.Value <= 0)
			{
				EmitSignal("Timeout");
				return;
			}

			// update label
			Label l = bar.GetChild<Label>(0);
			l.Text = Mathf.Round(bar.Value).ToString() + "s";
		}

		public void StartRoll()
		{
			if (rolling) return;
			rollTime.Start();
		}

		public void Roll()
		{
			if (rollCount < 20)
			{
				rolling = true;
				Random random = new Random();
				rollCount++;
				dice.Frame = random.Next(0, 6);
			}
			else
			{
				rolling = false;
				rollCount = 0;
				rollTime.Stop();
				rollTime.WaitTime = rollMaxtTime;
			}
		}
	}
}
