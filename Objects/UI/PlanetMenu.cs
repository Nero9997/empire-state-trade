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
	public planetUIScreen buildMenu;
	public planetUIScreen workMenu; 



	[Export]
	MarginContainer clearSpace;
	[Export]
	Button buildings;
	[Export]
	Button workForce;
	[Export]
	Button Stats;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		buildMenu = buildingMenu.Instantiate() as planetUIScreen;
		clearSpace.AddChild(buildMenu);
		buildMenu.Visible = false;

		workMenu = workForceMenu.Instantiate() as planetUIScreen;
		clearSpace.AddChild(workMenu);
		workMenu.Visible = false;


	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void buildingsPressed()
	{
		workMenu.Visible = false;
		buildMenu.Visible = true;
	}
	public void workForcePressed()
	{
		buildMenu.Visible = false;
		workMenu.Visible = true;
	}
}
