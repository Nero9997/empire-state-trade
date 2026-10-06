using Godot;
using System;

public partial class CelestialBody : Node2D
{
	// celesital body properties
	[Export]
	private int mass;
	public Star orbit;
	[Export]
	public string name;
	[Export]
	private Button viewButton;
	[Export]
	private Label planetStats;
	[Export] 
	private string bodyType;



	// celestial body oribit propoerties
	// the star
	[Export] 
	public float Radius = (float)GD.RandRange(100.0f, 500.0f);
	[Export] 
	public float Speed = (float)GD.RandRange(0.1f, 1.0f);    // radians per second
	float angle = 0f;


	private int gravitationalPull;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print(Radius);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{	
		angle += Speed * (float)delta;
		Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Radius;
		GlobalPosition = orbit.returnGlobalPosition() + offset;
	}
	public void gravityCalc(Area2D area)
	{
		if(area.GetParent() is Star star)
		{
			if(mass < star.returnmass())
			{
				orbit = star; 
			}
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
	
	public string returnorbit()
	{
		if(orbit != null)
		{
			return orbit.returnname();
		}
		else
		{
			return "No orbit";
		}
	}
	public void CheckPlanetDetails()
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
}
