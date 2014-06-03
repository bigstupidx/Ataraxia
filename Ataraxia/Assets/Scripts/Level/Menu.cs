using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	private void OnGUI ()
	{
		if(GUI.Button(new Rect(0F,0F,120F,25F), "Load Level 1"))
			LevelLoader.Instance.LoadScene(LevelLoader.LEVEL_1);
	}
}