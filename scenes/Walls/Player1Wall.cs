using Godot;
using System;

public partial class Player1Wall : PlayerWalls
{
	public void OnPlayer1WallEntered(Node2D body){
		if(body is Ball){
			GD.Print("Ball!");
			level.increaseScore(1);
		}
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
	}
}
