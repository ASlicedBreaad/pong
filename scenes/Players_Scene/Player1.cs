using Godot;
using System;

public partial class Player1 : Player
{

    public override void _Ready() {
        base._Ready();
        resetPosition();
    }

    public override void _Process(double delta) {
        Velocity = calculateMovement();
        MoveAndSlide();
    }

    protected override Vector2 getDirection()
    {
        return Input.GetVector("move_left","move_right","move_up","move_down");
    }

    public override void resetPosition()
    {
        Position = new Vector2(offsetBorder,bg.Texture.GetHeight()/2);
    }
}
