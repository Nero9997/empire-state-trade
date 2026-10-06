using Godot;
using System;

public partial class Star : CelestialBody
{
	// celesital body properties
	[Export]
	private int mass;
	[Export]
	private string name;
	[Export]
	private Button viewButton;
	[Export]
	private Label planetStats;
	[Export] 
	private string bodyType;
	private int gravitationalPull;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void CheckStarDetails()
	{
		if(planetStats.Visible == false)
		{
			planetStats.Visible  = true;
		}
		else
		{
			planetStats.Visible = false;
		}
	}
	public int returnmass()
	{
		return mass;
	}
	public string returnname()
	{
		return name;
	}
	public Vector2 returnGlobalPosition()
	{
		return GlobalPosition;
	} 
}
