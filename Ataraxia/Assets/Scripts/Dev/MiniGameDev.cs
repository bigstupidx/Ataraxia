using UnityEngine;
using System.Collections;

public class MiniGameDev : MonoBehaviour 
{
	private void OnGUI ()
	{
		if( GUI.Button (new Rect (10f,0f,120f,25f),"Win Mini Game" ))
			GotBackBoard( MiniGameState.Won);
		
		if( GUI.Button (new Rect (10f,35f,120f,25f),"Lost Mini Game" ))
			GotBackBoard( MiniGameState.Lost);
	}

	private void GotBackBoard (MiniGameState state)
	{
		BoardData boardData = FindObjectOfType<BoardData>();
		boardData.miniGameState = state;
		LevelLoader.Instance.LoadScene ("DevBoard");
		boardData.gameState = GameState.GiveRewards;
	}
}