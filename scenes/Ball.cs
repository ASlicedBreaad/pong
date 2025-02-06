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
        velocity = !player1IsWinner ? new Vector2(speed,0) : new Vector2(-speed,0); 
    }
    public override void _Process(double delta) {
        base._Process(delta);
    }
    public override void _PhysicsProcess(double delta) {
        base._PhysicsProcess(delta);
        KinematicCollision2D collisionInfo =  MoveAndCollide(new Vector2((float)(velocity.X*delta),(float)(velocity.Y*delta)));
        if(collisionInfo != null)
        {
            if(collisionInfo.GetCollider() is Player){
                GD.Print("Base Velocity: "+velocity + " "+ (collisionInfo.GetPosition().Y-GlobalPosition.Y*speed) + " "+ (collisionInfo.GetPosition().Y-GlobalPosition.Y));
                Vector2 bouncedVel = velocity.Bounce(collisionInfo.GetNormal());
                velocity.Y =GlobalPosition.Y*1.1f - collisionInfo.GetPosition().Y;
                velocity.X = bouncedVel.X;
                GD.Print("Bounced Velocity: "+ velocity);

            }else{
                velocity = velocity.Bounce(collisionInfo.GetNormal());
            }
        }
            
    }
}
