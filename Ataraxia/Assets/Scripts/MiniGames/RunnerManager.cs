using UnityEngine;
using System.Collections;

public class RunnerManager : MonoBehaviour 
{
	[SerializeField]
	private Character character;
	[SerializeField]
	private Transform [] pathFinder;
	private int currentPathFinder = 0;

	private void Start () 
	{
		StartGame ();
	}

	private void StartGame ()
	{
		character.MoveTo (pathFinder[currentPathFinder].position);
	}

	private void OnGUI ()
	{
		if(GUI.Button( new Rect (0F,30F,120F,25F),"Left"))
			Debug.Log ("MoveLeft");

		if(GUI.Button( new Rect (130F,30F,120F,25F),"Right"))
			Debug.Log ("MoveRight");
	}
}