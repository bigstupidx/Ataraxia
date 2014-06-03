using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour 
{
	private void Start () 
	{
		LevelLoader.Instance.LoadPendingScene ();
	}

	private void OnGUI ()
	{
		GUI.Label(new Rect(10F,10F,100F,25F),"Loading");
	}
}
