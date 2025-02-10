using System;
using System.Reflection;
using Godot;

public partial class Player2 : Player
{
    public bool ai_on { get; set; }

    private Timer aiTimer;
    private Vector2 aiMovement;
    private Ball ball;
    private bool basicAi;
    private float upDown = 0f;
    private Random rand = new Random();
    private float delta = 0;
    private int stepAi = 30;

    private int maxStepAi = 100;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        base._Ready();
        resetPosition();
        ai_on = false;
        basicAi = false;
        ball = GetNode<Ball>("../../ball");
        if (!basicAi)
        {
            initTimerAi();
            GetNode<Level>("/root/level").CallDeferred("add_child", aiTimer);
        }
    }

    private void initTimerAi()
    {
        aiTimer = new Timer();
        aiTimer.WaitTime = 0.8;
        aiTimer.Timeout += changeDelta;
    }

    public bool pauseUnpauseTimerAi()
    {
        switch (ai_on)
        {
            case false:
                ai_on = true;
                if (!basicAi)
                    aiTimer.Start();
                return true;
            case true:
                ai_on = false;
                if (!basicAi)
                    aiTimer.Stop();
                return false;

        }
    }

    private void changeDelta()
    {
        int range1 = 0, range2 = maxStepAi;
        int randValue = rand.Next(range1, range2);
        delta = randValue -= randValue % stepAi;
    }
    private void calculateAiMovement()
    {

        float subPos = ball.Position.Y - Position.Y;
        if (subPos > 0)
        {
            upDown = 1f;
        }
        if (subPos < 0)
        {
            upDown = -1f;
        }

        if (subPos < 0)
        {
            subPos *= -1;
        }

        if (subPos <= delta)
        {
            upDown = 0f;
        }



        aiMovement = new Vector2(0f, upDown * speed);
    }

    public override void _Process(double delta)
    {
        if (!ai_on)
        {
            Velocity = calculateMovement();
        }
        else
        {
            calculateAiMovement();
            Velocity = aiMovement;
        }
        MoveAndSlide();
    }

    protected override Vector2 getDirection()
    {
        return Input.GetVector("move_left_2nd_p", "move_right_2nd_p", "move_up_2nd_p", "move_down_2nd_p");
    }

    public void startStopTimerAi(bool state)
    {
        if (ai_on)
        {
            if (!state)
                aiTimer.Start();
            else
                aiTimer.Stop();

        }
    }

    public void makeSmarter()
    {
        if (delta - (stepAi * 2) > 0)
            delta -= stepAi * 2;
    }
    public override void resetPosition()
    {
        Position = new Vector2(bg.Texture.GetWidth() - offsetBorder, bg.Texture.GetHeight() / 2);
    }
}
