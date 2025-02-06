using Godot;
using System;
using System.Collections.Generic;

public partial class Ui : Control
{
	 List<Label> labels;


	public List<Label>getLabels(){
		return labels;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		labels = new List<Label>{GetNode<Label>("MarginBox/HBoxContainer/P1Score/scoreLabel"),GetNode<Label>("MarginBox/HBoxContainer/P2Score/scoreLabel")};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
