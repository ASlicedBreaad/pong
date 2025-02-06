using Godot;
using System;

public partial class Player2 : Player
{
	// Called when the node enters the scene tree for the first time.
    public override void _Ready() {
		base._Ready();
        resetPosition();
    }

	public override void _Process(double delta) {
        Velocity= calculateMovement();
        MoveAndSlide();
	}

    protected override Vector2 getDirection()
    {
        return Input.GetVector("move_left_2nd_p","move_right_2nd_p","move_up_2nd_p","move_down_2nd_p");
    }

    public override void resetPosition()
    {
        Position = new Vector2(bg.Texture.GetWidth()-offsetBorder,bg.Texture.GetHeight()/2);
    }
}
