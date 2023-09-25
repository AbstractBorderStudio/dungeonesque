using Godot;

public partial class Card : Control
{
	const string BASE_COLOR = "000000";
	const string HIGH_COLOR = "DEC621";

	[Export]
	private Label name, ability, item, hp, init;
	[Export]
	private StyleBoxFlat background;

	public void Highlight(bool highlighted)
	{
		if (highlighted) background.BgColor = new Color(HIGH_COLOR);
		else background.BgColor = new Color(BASE_COLOR);
	}

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
