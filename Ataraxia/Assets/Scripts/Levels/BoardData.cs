using UnityEngine;
using System.Collections;

public class BoardData : MonoBehaviour 
{
	public int currentSquare = -1;
	public Vector3 currentCharacterPosition;
	public GameState gameState;
	public MiniGameState miniGameState;
	public int minigamesViewed;
	public int indexMiniGame;

	public static BoardData Instance
	{
		get;
		private set;
	}

	private void Awake ()
	{
		if(Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
		else
			Unload ();
	}

	public void FinishMiniGame ( MiniGameState state )
	{
		this.miniGameState = state;
		gameState = GameState.GiveRewards;
	}

	public void SetMiniGamesData (int miniGamesViewed, int currentGameIndex)
	{
		this.minigamesViewed = miniGamesViewed;
		this.indexMiniGame = currentGameIndex;
	}

	public void SetData (int currentIndexSquare, GameState gameState, Vector3 position)
	{
		this.currentSquare = currentIndexSquare;
		this.gameState = gameState;
		this.currentCharacterPosition = position;
	}

	public void Unload ()
	{
		Destroy (this.gameObject);
	}
}