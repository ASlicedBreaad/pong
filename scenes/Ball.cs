using Godot;
using System;

public partial class Ball : RigidBody2D
{
    Sprite2D bg;
    private float speed;
    private Vector2 velocity;
    private bool reset = false;

    private bool player1IsWinner = false;
    public override void _Ready() {
        base._Ready();
        bg = GetNode<Sprite2D>("../bg");
        speed = 500;
        Position = new Vector2(bg.Texture.GetWidth()/2, bg.Texture.GetHeight()/2);
    }

    public void resetPosition(bool player1IsWinner){
        this.Hide();
        LinearVelocity = new Vector2(0,0);
        Position = new Vector2(bg.Texture.GetWidth()/2, bg.Texture.GetHeight()/2);    
        this.Show();
        velocity = !player1IsWinner ? new Vector2(speed,-speed) : new Vector2(-speed,speed); 
        reset = false;
    }

    public void resetBall(bool player1IsWinner){
        reset = true;
        this.player1IsWinner = player1IsWinner;
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
                velocity = new Vector2((float)(bouncedVec.X*1.03),bouncedVec.Y);
        }
            
    }

    public override void _IntegrateForces(PhysicsDirectBodyState2D state){
        if(reset)
            resetPosition(player1IsWinner);
    }
}
