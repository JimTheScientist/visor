using Godot;
using System;

public partial class Camera2D : Godot.Camera2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (Networking.IsHost)
		{
			GD.Print("Am Host");
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
