using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Level : Node
{
	private List<Player> players;
	private Ball ball;
	private List<int> playerScores;

	private PauseMenu pauseMenu;
	private bool player1IsWinner;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		players = GetNode<Players>("players").playersList;
		playerScores = new List<int>(players.Count);
		playerScores.AddRange(Enumerable.Repeat(0,players.Count));
		pauseMenu = GetNode<PauseMenu>("MenuContainer/PauseMenu");
		ball = GetNode<Ball>("ball");
		resetScores();
		pauseMenu.PauseMenuClicked();
		player1IsWinner = false;
	}
	private void resetScores(){
		playerScores = playerScores.Select(s => 0).ToList();
		getScores();
		updateScores(new List<int>{0,0});
		
	}

	public void pauseGame(bool state){
		Player2 player2 = (Player2) players[1];
		player2.pauseUnpauseTimerAi();
	}
	public List<int> getScores(){
		return playerScores;
	}

	public void startNewGame(){
		pauseMenu.PauseMenuClicked();
		resetScores();
		ball.resetBall(player1IsWinner);
		players.ForEach(p=>p.resetPosition());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _Input(InputEvent @event) {
		if(@event.IsActionPressed("Pause")){
			pauseMenu.PauseMenuClicked();
		}
	}

	public void updateScores(List<int> scores){
		List<Label> labels = GetNode<Ui>("UI").getLabels();
		labels[0].Text = scores[0].ToString();
		labels[1].Text = scores[1].ToString();
	}
	public void increaseScore(int playerId) {
		ball.resetBall(player1IsWinner);
		playerScores[playerId]++;
		player1IsWinner = playerId == 0;
		updateScores(playerScores);
		if(playerId == 0){
			((Player2) players[1]).makeSmarter();
		}
	}

	public bool switchAiState(){
		Player2 player2 = (Player2) players[1];
		
		return player2.pauseUnpauseTimerAi();
	}
}
