using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour 
{
	private void Start ()
	{
		LevelLoader.Instance.LoadScene(LevelLoader.MENU);
	}
}