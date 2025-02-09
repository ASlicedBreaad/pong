using Godot;
using System;

public partial class AiButton : Button
{
	private Level level;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		level = GetNode<Level>("/root/level");
		Text = "Ai: Off";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	
	public void buttonIsPressed(){
		Text =  level.switchAiState() ? "Ai: On" : "Ai: Off";
	}
}
