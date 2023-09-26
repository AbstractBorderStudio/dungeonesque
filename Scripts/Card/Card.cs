using Godot;

public partial class Card : Control
{
	private const string BASE_COLOR = "000000",
		HIGH_COLOR = "DEC621";

	[Export]
	private Label name, ability, item, hp, init;
	[Export]
	private StyleBoxFlat backgroundMat;

	public void Highlight(bool highlighted)
	{
		backgroundMat.SetupLocalToScene();
		
		if (highlighted) backgroundMat.BgColor = new Color(HIGH_COLOR);
		else backgroundMat.BgColor = new Color(BASE_COLOR);
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



//ShaderMaterial _mat = background.Material as ShaderMaterial;