using Godot;
using System;

public partial class Button : Godot.Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public override void _Pressed()
	{
		base._Pressed();
		GD.Print("Host");
		Networking.IsHost = true;
		PackedScene scene = GD.Load<PackedScene>("res://scenes/PlayArea.tscn");
		Node2D sceneNode = scene.Instantiate<Node2D>();
		GetTree().Root.AddChild(sceneNode);
		Networking.SetupServer(sceneNode.GetTree());
		GetTree().Root.RemoveChild(this.Owner);
	}
}
