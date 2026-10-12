using Godot;
using System;

public partial class CelestialBody : Node2D
{
	// celesital body properties
	public Star orbit;
	[Export]
	public string name;
	[Export]
	private Button viewButton;
	[Export]
	private Label planetStats;
	



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	// move all general functions to the celestialbodies class for orgainization.
	public string returnname()
	{
		return name;
	}
	

}
