using Godot;
using System;
using System.Collections.Generic;

public partial  class Players : Node2D
{
	private Player player1 {get; set;} = null;
	private Player player2 {get; set;} = null;

	public List<Player> playersList {get{
		return new List<Player>{player1,player2};
	}} 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Position = new Vector2(0,0);
		player1 = GetNode<Player>("player1");
		player2 = GetNode<Player>("player2");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
