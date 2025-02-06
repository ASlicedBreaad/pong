using Godot;

public abstract partial class Player : CharacterBody2D{

    public Sprite2D bg;
    double speed;
    protected const int offsetBorder = 75;

    public override void _Ready() {
        base._Ready();
        bg =  GetNode<Sprite2D>("../../bg");
        speed = 700;
    } 

    protected abstract Vector2 getDirection();
    public abstract void resetPosition();
    protected Vector2 calculateMovement(){
        Vector2 movement = new Vector2(0,(float) (getDirection().Y *speed));
        return movement;
    }

    public override void _Process(double delta) {
        base._Process(delta);
    }
}