using Godot;

public partial class Player2 : Player
{
    public bool ai_on {get;set;}
    private Ball ball;
	// Called when the node enters the scene tree for the first time.
    public override void _Ready() {
		base._Ready();
        resetPosition();
        ai_on = false;
        ball = GetNode<Ball>("../../ball");
    }

    private Vector2 calculateAiMovement(){
        float upDown = 0f;

        if(ball.Position.Y - Position.Y > 0){
            upDown = 1f;
        }
        else if(ball.Position.Y - Position.Y < 0)
        {
            upDown = -1f;
        }else{
            upDown = 0f;
        }


        return new Vector2(0f,upDown*speed);
    }

	public override void _Process(double delta) {
        if(!ai_on){
            Velocity= calculateMovement();
        }else{
            Velocity = calculateAiMovement();
        }
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
