using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class MiniGamesManager
{
	public MiniGameData specialLevel;
	public List<MiniGameData> miniGames;
	private int miniGamesView = 0;

	public int MiniGamesViewed
	{
		get {return miniGamesView;}
	}

	public int CurrentGameIndex
	{
		get;
		private set;
	}

	public MiniGameData CurrentMiniGame
	{
		get; 
		private set; 
	}

	public void EndMiniGame ()
	{
		CurrentMiniGame.state = MiniGameState.NotPlayed;
		CurrentMiniGame = null;
	}

	public void GetRewards (Character character , Action callback)
	{
		if(CurrentMiniGame.state == MiniGameState.Lost)
		{
			callback ();
			character.StartLose ();
		}
		else if(CurrentMiniGame.state == MiniGameState.Won)
		{
			callback ();
			character.StartCelebration ();
		}
	}

	public string GetMiniGame () 
	{
		if( miniGamesView < this.miniGames.Count )
			return GetNextMiniGame ();
		else
			return GetRandomMiniGame ();
	}

	public void SetMiniGameByIndex (int indexMiniGame, MiniGameState miniGameState,int miniGamesViewed)
	{
		this.miniGamesView = miniGamesViewed;
		CurrentMiniGame = this.miniGames [indexMiniGame];
		CurrentMiniGame.state = miniGameState;
	}

	private string GetNextMiniGame ()
	{
		string miniGameName = this.miniGames [miniGamesView].miniGameName;
		CurrentMiniGame = this.miniGames [miniGamesView];
		CurrentGameIndex = miniGamesView;
		miniGamesView++;
		return miniGameName;
	}

	private string GetRandomMiniGame ()
	{
		int index = UnityEngine.Random.Range ( 0,this.miniGames.Count-1 );
		CurrentMiniGame = this.miniGames [index];
		CurrentGameIndex = index;
		return CurrentMiniGame.miniGameName;
	}
}