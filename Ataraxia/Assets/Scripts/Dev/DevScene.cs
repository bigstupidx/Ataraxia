using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DevScene : MonoBehaviour 
{
	[SerializeField]
	private CharacterMoveToPoint character;
	[SerializeField]
	private List<Square> boxes;
	private int currentBox = -1;

	private void OnGUI ()
	{
		if(GUI.Button(new Rect(0F,0F,100F,25F),"Next Box"))
			GoToNextBox ();

		if(GUI.Button(new Rect(0F,40F,100F,25F),"Prev Box"))
			GoToPrevBox ();
	}

	private void GoToNextBox ()
	{
		if(currentBox == -1)
			currentBox = 0;
		else if(currentBox < boxes.Count - 1)
			currentBox++;

		character.MoveTo(boxes[currentBox].transform);
	}

	private void GoToPrevBox ()
	{
		if(currentBox != -1 && currentBox > 0)
			currentBox--;

		character.MoveTo(boxes[currentBox].transform);
	}
}