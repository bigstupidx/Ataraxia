using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DevScene : MonoBehaviour 
{
	private void OnGUI ()
	{
		if(GUI.Button(new Rect(0F,200F,100F,25F),"StartGame"))
			Board.Instance.StartGame ();
	}

}