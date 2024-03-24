using Godot;
using System;

public partial class Player1Body : CharacterBody2D
{
	public const float Speed = 300.0f;
	private Vector2 inputDirection;
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		if (Networking.IsHost)
		{
			inputDirection = Input.GetVector("left", "right", "up", "down");
			Rpc(nameof(SetPlayerVelocity), inputDirection);
			Rpc(nameof(SetPlayerPosition), Position);
		}
		
		velocity.X = inputDirection.X * Speed;
		velocity.Y = inputDirection.Y * Speed;
		Velocity = velocity;
		switch (inputDirection)
		{
			case { X: > 0, Y: 0 }:
				Rotation = 0;
				break;
			case { X: < 0, Y: 0 }:
				Rotation = (float) Math.PI;
				break;
			case { X: < 0, Y: > 0 }:
				Rotation = (float)(Math.PI * 3)/4;
				break;
			case { X: < 0, Y: < 0 }:
				Rotation = (float)(Math.PI * 5)/4;
				break;
			case { X: 0, Y: < 0 }:
				Rotation = (float)(Math.PI * 3)/2;
				break;
			case { X: > 0, Y: > 0 }:
				Rotation = (float) Math.PI / 4;
				break;
			case { X: 0, Y: > 0 }:
				Rotation = (float) Math.PI / 2;
				break;
			case { X: > 0, Y: < 0 }:
				Rotation = (float)(Math.PI * 7) / 4;
				break;
		}
		MoveAndSlide();
	}
	[Rpc(MultiplayerApi.RpcMode.AnyPeer)]
	public void SetPlayerVelocity(Vector2 inputDirection)
	{
		this.inputDirection = inputDirection;
	}
	
	[Rpc(MultiplayerApi.RpcMode.AnyPeer)]
	public void SetPlayerPosition(Vector2 position)
	{
		this.Position = position;
	}
}
