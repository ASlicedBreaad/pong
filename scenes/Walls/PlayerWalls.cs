using Godot;

public abstract partial class PlayerWalls : Area2D {
    protected Level level;
    public override void _Ready() {
        base._Ready();
        level = GetNode<Level>("../../../level");
    }
    public override void _Process(double delta) {
        base._Process(delta);
    }
}