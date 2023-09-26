using Godot;
using System;

namespace Dungeonesque
{
	public partial class StoryContainer : Control
	{
		[Export]
		private Label title, desc;
		[Export]
		private RichTextLabel obj;

		// Called when the node enters the scene tree for the first time.
		public void SetStoryContainer(Story s)
		{
			title.Text = s.Place;
			desc.Text = s.Description;
			obj.Text = "[center][wave freq=5.0]" + s.Objective;
		}

		public void ClearStoryContainer()
		{
			title.Text = "";
			desc.Text = "";
			obj.Text = "";
		}
	}
}
