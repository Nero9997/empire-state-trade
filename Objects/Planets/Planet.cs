using Godot;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

public partial class Planet : CelestialBody
{
	//General Properties
	
	private int buildingPlots {get; set;} //Check


	//Planet stas
	private string planetType {get; set;} //Check
	private string planetSize {get; set;} //Check

	//Planet Workforce
	private int population {get; set;} //Check
	private int workForce {get; set;} //Check
	private string[] specializations {get; set;}//
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
	private enum specialSelect
	{
		manufacture,
		construction,
		metallurgy
		
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		workForce = GD.RandRange(500,2000);
		population = GD.RandRange(1000, 4000);
		selectPlanetSizes();
		determinePlanetType();
		determineBuildingPlots();
		selectSpecial();
		/*
		if(orbit != null)
		{
			Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Radius;
			GlobalPosition = orbit.returnGlobalPosition() + offset;	
		}
		*/

		GD.Print(planetType, planetSize, buildingPlots, specializations);
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






	private string determineSpecializations(specialSelect select)
	{
		switch(select)
		{
			case specialSelect.manufacture:
				{
					return "manufacture";
				}
			case specialSelect.construction:
				{
					return "construction";
				}
			case specialSelect.metallurgy:
				{
					return "metallurgy";
				}
			default:
			{
				return "null";
			}
		}
	}
	private void selectSpecial()
	{
		//specialization1 = determineSpecializations((specialSelect)GD.RandRange(0,2));
		specializations = [determineSpecializations((specialSelect)GD.RandRange(0,2)),determineSpecializations((specialSelect)GD.RandRange(0,2))];
		while(specializations[0] == specializations[1])
		{
			specializations[1] = determineSpecializations((specialSelect)GD.RandRange(0,2));
		}
	}	
	




	private void determinePlanetType()
	{
		if(planetSize.Equals(planetSizes.large.ToString()))
        {
            planetType = determinePlanetMakeup(planetTypes.gasGiant);
        }
		else if(planetSize.Equals(planetSizes.medium.ToString()))
		{
			planetType = determinePlanetMakeup((planetTypes)GD.RandRange(1,5));
		}
		else if(planetSize.Equals(planetSizes.small.ToString()))
		{
			planetType = determinePlanetMakeup((planetTypes)GD.RandRange(1,5));
		}
	}
	private void determineBuildingPlots()
	{
		if(planetSize.Equals(planetSizes.large.ToString()))
		{
			buildingPlots = GD.RandRange(20,25);
		}
		else if(planetSize.Equals(planetSizes.medium.ToString()))
		{
			buildingPlots = GD.RandRange(14,16);
		}
		else if(planetSize.Equals(planetSizes.small.ToString()))
		{
			buildingPlots = GD.RandRange(6,8);
		}
	}

	/*
	
	
	deterimine population and workforce
	

	*/

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
	}

	//Return functions
	public int returnWorkForce()
	{
		return workForce;
	} 
	public int returnPopulation()
	{
		return population;
	}
	public string[] returnSpeicalizations()
	{
		return specializations;
	}

	public string returnPlanetType()
	{
		return planetType;
	}
	public string returnPlanetSize()
	{
		return planetSize;
	}
	public int returnBuildingPlots()
	{
		return buildingPlots;
	}
}
