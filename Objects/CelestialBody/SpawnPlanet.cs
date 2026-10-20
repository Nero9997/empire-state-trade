using Godot;
using System;

public partial class SpawnPlanet : Node
{
	[Export]
	private PackedScene planet;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Planet newBody = planet.Instantiate() as Planet;
		AddChild(newBody);
	}
}
