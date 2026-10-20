using Godot;
using System;

public partial class ViewController : Node
{
	public static ViewController Instance {get; private set;}
	public Planet currentPlanet;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
