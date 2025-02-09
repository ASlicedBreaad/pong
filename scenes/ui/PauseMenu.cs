using Godot;
using System;

public partial class PauseMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	
	public void PauseMenuClicked(){
		
		if(GetTree().Paused){
			GetTree().Paused = false;
			GetNode<Level>("/root/level").pauseGame(false);
			Hide();
		}else{
			GetTree().Paused = true;
			GetNode<Level>("/root/level").pauseGame(true);
			Show();
		}
	}
}
