using Godot;
using System;
using System.Drawing;

public partial class Planet : CelestialBody
{
	//General Properties
	private string planetType {get; set;} //Check
	public string planetSize {get; set;} //Check
	private int population {get; set;} //Check
	private int buildingPlots {get; set;} //Check

	/*
	[Export]
	private Label planetStats;
	*/
	// celestial body oribit propoerties
	private float Radius = (float)GD.RandRange(100.0f, 500.0f);
	private float Speed = (float)GD.RandRange(0.1f, 1.0f);    // radians per second
	private float angle = (float)GD.RandRange(0.1f, 10.0f);
	/*
	[Export]
	cities
	*/
	//planetTypes
	private enum planetTypes
	{
		gasGiant,
		grassPlanet,
		desertPlanet,
		oceanPlanet,
		baronPlanet,
		continentalPlanet
	}
	private enum planetSizes
	{
		large,
		medium,
		small
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		population = GD.RandRange(1000, 4000);
		selectPlanetSizes();
		determinePlanetType();
		determineBuildingPlots();
		/*
		if(orbit != null)
		{
			Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Radius;
			GlobalPosition = orbit.returnGlobalPosition() + offset;	
		}
		*/

		GD.Print(planetType, planetSize, buildingPlots);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	//Planet creating process
	private string determinePlanetMakeup(planetTypes select)
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
	private string DPlanetSizes(planetSizes select)
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
	private void selectPlanetSizes()
	{
		planetSize = DPlanetSizes((planetSizes)GD.RandRange(0,2));
		
	}




	private void determinePlanetType()
	{
		if(planetSize.Equals("large"))
		{
			planetType = determinePlanetMakeup(planetTypes.gasGiant);
		}
		else if(planetSize.Equals("medium"))
		{
			planetType = determinePlanetMakeup((planetTypes)GD.RandRange(1,5));
		}
		else if(planetSize.Equals("small"))
		{
			planetType = determinePlanetMakeup((planetTypes)GD.RandRange(1,5));
		}
		else
		{
			planetType = determinePlanetMakeup(planetTypes.gasGiant);
		}
	}
	private void determineBuildingPlots()
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

	private void gravityCalc(Area2D area)
	{
		if(area.GetParent() is Star star)
		{
			orbit = star; 
		}
	}
		public void CheckPlanetDetails()
	{
		ViewController.Instance.currentPlanet = this;
		if(ViewController.Instance.currentPlanet.Equals(this))
		{
			GD.Print("Select");	
		}
		else
		{
			GD.Print("No select");
		}
		
	}
	public int returnPopulation()
	{
		return population;
	}
}
