using Godot;
using System;

public partial class Networking : Node
{
	public static bool IsHost;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public static void SetupServer(SceneTree tree)
	{
		IsHost = true;
		MultiplayerApi multiplayer = tree.GetMultiplayer();
		var peer = new ENetMultiplayerPeer();
		peer.CreateServer(25567, 2);
		multiplayer.MultiplayerPeer = peer;
	}

	public static void SetupClient(SceneTree tree)
	{
		IsHost = false;
		MultiplayerApi multiplayer = tree.GetMultiplayer();
		var peer = new ENetMultiplayerPeer();
		peer.CreateClient("localhost", 25567);
		multiplayer.MultiplayerPeer = peer;
	}
}
