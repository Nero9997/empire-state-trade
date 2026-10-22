using Godot;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
	Label workMenuField2;
	Label workMenuField3;
	Label workMenuField4;
	private int Population; 
	private int workF;
	
	private string[] specializations;


	//Display stats
	private string planetType;
	private string planetSize;


	//Labels 

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
		if(ViewController.Instance.currentPlanet != null)
		{
			Population = ViewController.Instance.currentPlanet.returnPopulation();
			workMenuField1 = workMenu.FindChild("Population") as Label;
			workMenuField1.Text	= ($"Population: {Population}");

			workF = ViewController.Instance.currentPlanet.returnWorkForce();
			workMenuField2 = workMenu.FindChild("WorkForce") as Label;
			workMenuField2.Text = ($"WorkForce: {workF}");	

			specializations = ViewController.Instance.currentPlanet.returnSpeicalizations();
			workMenuField3 = workMenu.FindChild("specialization1") as Label;
			workMenuField3.Text = ($"specialization1: {specializations[0]}");

			workMenuField4 = workMenu.FindChild("specialization2") as Label;
			workMenuField4.Text = ($"specialization2: {specializations[1]}");
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
