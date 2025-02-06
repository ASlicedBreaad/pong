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
            // if(collisionInfo.GetCollider() is Player){
            //     GD.Print("Base Velocity: "+velocity + " "+ (collisionInfo.GetPosition().Y-GlobalPosition.Y*speed) + " "+ (collisionInfo.GetPosition().Y-GlobalPosition.Y));
            //     Vector2 bouncedVel = velocity.Bounce(collisionInfo.GetNormal());
            //     velocity.Y =GlobalPosition.Y*1.1f + bouncedVel.X < 0 ? -collisionInfo.GetPosition().Y : collisionInfo.GetPosition().Y;
            //     velocity.X = -velocity.X;
            //     GD.Print("Normalized : " + velocity);
            //     velocity = new Vector2(velocity.X,(float)
            //     (velocity.Y/
            //     (Math.Sqrt(Math.Pow(velocity.X,2)+Math.Pow(velocity.Y,2)))
            //     *speed));
            //     GD.Print("Bounced Velocity: "+ velocity);

            // }else{
            Vector2 bouncedVec = velocity.Bounce(collisionInfo.GetNormal());
                velocity = new Vector2((float)(bouncedVec.X*1.1),bouncedVec.Y);
            // }
        }
            
    }
}
