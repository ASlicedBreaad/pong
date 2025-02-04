using Godot;
using System;

public partial class Players : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Node2D childNode = (Node2D) GetChild(0);
		Node2D childNode2 = (Node2D) GetChild(1);
		childNode.Position= new Vector2(0,0);
		childNode2.Position = new Vector2(0,0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		Position = new Vector2(0,0);
	}
}
