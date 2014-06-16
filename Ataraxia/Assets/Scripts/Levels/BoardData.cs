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

	private void Awake ()
	{
		DontDestroyOnLoad (this.gameObject);
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