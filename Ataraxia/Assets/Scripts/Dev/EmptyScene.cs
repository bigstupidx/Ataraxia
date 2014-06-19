using UnityEngine;
using System.Collections;

public class EmptyScene : MonoBehaviour {
	private void OnGUI () 
	{
		if(GUI.Button( new Rect (0F,0F,120F,25F),"Ganar"))
		{
			MiniGameState miniGameState =  MiniGameState.Won ;
			BoardData.Instance.FinishMiniGame (miniGameState);
			LevelLoader.Instance.LoadScene(LevelLoader.LEVEL_1);
		}
	}
}
