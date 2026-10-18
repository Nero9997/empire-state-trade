using Godot;
using System;
using System.ComponentModel;
using System.Xml;

public partial class PlanetMenu : Control
{
	[Export]
	PackedScene buildingMenu;
	public BuildingScreen buildMenu;



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
		buildMenu = buildingMenu.Instantiate() as BuildingScreen;
		clearSpace.AddChild(buildMenu);
		buildMenu.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void buildingsPressed()
	{
		buildMenu.Visible = true;
	}
}
