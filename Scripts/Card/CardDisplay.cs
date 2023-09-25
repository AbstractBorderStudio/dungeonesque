using Godot;
using System;
using System.Diagnostics.Contracts;

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

		public void HighlightCard(int index)
		{
			foreach (Card c in container.GetChildren())
				c.Highlight(false);
			
			Card _hCard = container.GetChild(index) as Card;
			_hCard.Highlight(true);
		}

		public void ClearDisplay()
		{
			foreach (Node n in container.GetChildren())
				n.Free();
		}
	}
}
