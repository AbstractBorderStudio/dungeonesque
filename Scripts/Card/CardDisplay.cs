using Godot;
using System;

namespace Dungeonesque
{
	public partial class CardDisplay : Control
	{
		[Export]
		private PackedScene cardPf;
		[Export]
		private VBoxContainer container;

		public void AddCard(Player player)
		{
			Card card = cardPf.Instantiate<Card>();
			card.SetCard(player.Nickname,
				player.Ability,
				player.Item,
				player.Hp.ToString(),
				player.Initiative.ToString());
			container.AddChild(card);
		}

		public void ClearDisplay()
		{
			foreach (Node n in container.GetChildren())
				n.Free();
		}
	}
}
