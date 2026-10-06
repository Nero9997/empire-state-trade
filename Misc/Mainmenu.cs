using Godot;
using System;

public partial class Mainmenu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void OnStartPressed()
	{
		GetTree().ChangeSceneToFile("res://Playarea/node_2d.tscn");
	}
	private void OnOptionsPressed()
	{

	}
	private void OnExitPressed()
	{
		GetTree().Quit();
	}
	private void OnCreditsPressed()
	{

	}
}
