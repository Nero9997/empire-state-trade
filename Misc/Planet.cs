using Godot;
using System;
using System.Drawing;

public partial class Planet : CelestialBody
{
	//General Properties
	public string planetType; //Check
	public string planetSize; //Check
	private int population;
	private int buildingPlots;
	[Export]
	private Label planetStats;
	// celestial body oribit propoerties
	[Export] 
	public float Radius = (float)GD.RandRange(100.0f, 500.0f);
	[Export] 
	public float Speed = (float)GD.RandRange(0.1f, 1.0f);    // radians per second
	float angle = 0f;
	/*
	[Export]
	cities
	*/
	//planetTypes
	public enum planetTypes
	{
		gasGiant,
		grassPlanet,
		desertPlanet,
		oceanPlanet,
		baronPlanet,
		continentalPlanet
	}
	public enum planetSizes
	{
		large,
		medium,
		small
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		selectPlanetSizes();
		determinePlanetType();
		determineBuildingPlots();

		GD.Print(planetType, planetSize, buildingPlots, planetStats);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(orbit != null)
		{
			angle += Speed * (float)delta;
			Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Radius;
			GlobalPosition = orbit.returnGlobalPosition() + offset;	
		}
	}
	//Planet creating process

	public string determinePlanetMakeup(planetTypes select)
	{
		switch (select)
		{
			case planetTypes.gasGiant:
				{
					return "gasGiant";
				}
			case planetTypes.grassPlanet:
				{
					return "grassPlanet";
				}
			case planetTypes.desertPlanet:
				{
					return "desertPlanet";
				}
			case planetTypes.oceanPlanet:
				{
					return "oceanPlanet";
				}
			case planetTypes.baronPlanet:
				{
					return "baronPlanet";
				}
			case planetTypes.continentalPlanet:
				{
					return "continentalPlanet";
				}
			default:
				{
					return "baronPlanet";
				}
		
		}
		
	}
	public string DPlanetSizes(planetSizes select)
	{
		switch(select)
		{
			case planetSizes.large:
				{
					return "large";		
				}
			case planetSizes.medium:
				{
					return "medium";
				}
			case planetSizes.small:
				{
					return "small";
				}
			default:
				{
					return "null";
				}
		}
	}
	public void selectPlanetSizes()
	{
		planetSize = DPlanetSizes((planetSizes)GD.RandRange(0,2));
		
	}




	public void determinePlanetType()
	{
		if(planetSize.Equals("large"))
		{
			planetType = determinePlanetMakeup(planetTypes.gasGiant);
		}
		else if(planetSize.Equals("medium"))
		{
			planetType = determinePlanetMakeup((planetTypes)GD.RandRange(1,5));
		}
		else if(planetType.Equals("small"))
		{
			planetType = determinePlanetMakeup((planetTypes)GD.RandRange(1,5));
		}
		else
		{
			planetType = determinePlanetMakeup(planetTypes.gasGiant);
		}
	}
	public void determineBuildingPlots()
	{
		if(planetSize.Equals("large"))
		{
			buildingPlots = GD.RandRange(20,25);
		}
		else if(planetSize.Equals("medium"))
		{
			buildingPlots = GD.RandRange(14,16);
		}
		else if(planetSize.Equals("small"))
		{
			buildingPlots = GD.RandRange(6,8);
		}
	}

	public void gravityCalc(Area2D area)
	{
		if(area.GetParent() is Star star)
		{
			orbit = star; 
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
