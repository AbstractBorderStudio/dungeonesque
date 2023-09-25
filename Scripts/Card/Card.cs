using Godot;

public partial class Card : Control
{
	[Export]
	private Label name, ability, item, hp, init;

	public void SetCard(string _name,
		string _ability,
		string _item,
		string _hp,
		string _init)
	{
		name.Text = _name;
		ability.Text = _ability;
		item.Text = _item;
		hp.Text = _hp;
		init.Text = _init;
	}
}
