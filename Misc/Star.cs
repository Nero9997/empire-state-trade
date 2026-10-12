using Godot;
using System;

/*
this class is the second layer of my three layer system
to simulate a solar system


The Star class is responsible for monitoring and controlling
the orbit, speed orbit, and contents based on the radius of its orbit.


A star should have the following capabilities
- it must have its own mass to determine its star class -Check
- it must have a max amount of celestialbodys to prevent crowding
or some other error - Check
- and lastly it must way of creating and storing planets in its orbit. - Check
*/
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
	private string starClass;
	[Export]
	private PackedScene planet;
	


	private Node[] bodiesInOrbit;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		/*This for loop creates a random amount of planets in its orbit
		and then stores them in an array
		*/
		bodiesInOrbit = new CelestialBody[GD.RandRange(1,6)];
		for(int i = 0; i < bodiesInOrbit.Length; i++)
		{
			//each iteration of this loop will resuse the newBody variable to instantiate a new celestialbody child to the star.
			CelestialBody newBody = planet.Instantiate() as CelestialBody;
			bodiesInOrbit[i] = newBody;
			AddChild(bodiesInOrbit[i]);
			//newBody.GlobalPosition = GlobalPosition;
		}
		

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
