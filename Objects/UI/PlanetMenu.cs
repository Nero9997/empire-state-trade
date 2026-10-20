using Godot;
using System;
using System.ComponentModel;
using System.Xml;

public partial class PlanetMenu : Control
{
	[Export]
	PackedScene buildingMenu;
	[Export]
	PackedScene workForceMenu;
	[Export]
	PackedScene statsMenu;


	private planetUIScreen buildMenu;
	private planetUIScreen workMenu; 
	private planetUIScreen statMenu;


	[Export]
	MarginContainer clearSpace;
	[Export]
	Button buildings;
	[Export]
	Button workForce;
	[Export]
	Button Stats;




	//Display properties
	Label workMenuField1;
	private int Population; 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		buildMenu = buildingMenu.Instantiate() as planetUIScreen;
		clearSpace.AddChild(buildMenu);
		buildMenu.Visible = false;

		workMenu = workForceMenu.Instantiate() as planetUIScreen;
		clearSpace.AddChild(workMenu);
		workMenu.Visible = false;

		statMenu = statsMenu.Instantiate() as planetUIScreen;
		clearSpace.AddChild(statMenu);
		statMenu.Visible = false;
	}
	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		workMenuField1 = workMenu.FindChild("Population") as Label;
		workMenuField1.Text	= ($"{Population}");
		if(ViewController.Instance.currentPlanet != null)
		{
			Population = ViewController.Instance.currentPlanet.returnPopulation();
		}

	}
	public void buildingsPressed()
	{
		statMenu.Visible = false;
		workMenu.Visible = false;
		buildMenu.Visible = true;
	}
	public void workForcePressed()
	{
		statMenu.Visible = false;
		buildMenu.Visible = false;
		workMenu.Visible = true;
	}
	public void statsPressed()
	{
		statMenu.Visible = true;
		buildMenu.Visible = false;
		workMenu.Visible = false;
	}
}
