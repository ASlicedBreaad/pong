using Godot;
using System;

public partial class Ball : RigidBody2D
{
    Sprite2D bg;
    private float speed;
    private Vector2 velocity;
    public override void _Ready() {
        base._Ready();
        bg = GetNode<Sprite2D>("../bg");
        speed = 500;
        Position = new Vector2(bg.Texture.GetWidth()/2, bg.Texture.GetHeight()/2);
    }

    public void resetPosition(bool player1IsWinner){
        Position = new Vector2(bg.Texture.GetWidth()/2, bg.Texture.GetHeight()/2);    
        velocity = !player1IsWinner ? new Vector2(speed,-speed) : new Vector2(-speed,speed); 
    }
    public override void _Process(double delta) {
        base._Process(delta);
    }
    public override void _PhysicsProcess(double delta) {
        base._PhysicsProcess(delta);
        KinematicCollision2D collisionInfo =  MoveAndCollide(new Vector2((float)(velocity.X*delta),(float)(velocity.Y*delta)));
        if(collisionInfo != null)
        {
            Vector2 bouncedVec = velocity.Bounce(collisionInfo.GetNormal());
                velocity = new Vector2((float)(bouncedVec.X*1.1),bouncedVec.Y);
        }
            
    }
}
