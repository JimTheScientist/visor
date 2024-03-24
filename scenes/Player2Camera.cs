using Godot;
using System;

public partial class Player2Camera : Camera2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (Networking.IsHost == false)
		{
			GD.Print("Not Host");
			Enabled = true;
		}
		else
		{
			Enabled = false;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	
}
