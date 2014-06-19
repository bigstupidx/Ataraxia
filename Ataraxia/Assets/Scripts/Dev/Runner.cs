using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	private void OnGUI () 
	{
		if(GUI.Button( new Rect (0F,0F,120F,25F),"Ganar"))
		{
			MiniGameState miniGameState =  MiniGameState.Won ;
			BoardData.Instance.FinishMiniGame (miniGameState);
			BoardData.Instance.gameState = GameState.Dialog;
			LevelLoader.Instance.LoadScene(LevelLoader.LEVEL_1);
		}
	}
}
