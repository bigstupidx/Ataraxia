using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DevScene : MonoBehaviour 
{
	[SerializeField]
	private CharacterMoveToPoint character;
	[SerializeField]
	private List<Box> boxes;
	private int currentBox = -1;

	private void OnGUI ()
	{
		if(GUI.Button(new Rect(0F,0F,100F,25F),"Next Box"))
			GoToNextBox ();

		if(GUI.Button(new Rect(0F,40F,100F,25F),"Prev Box"))
			GoToPrevBox ();
	}

	private void Update ()
	{
		if(Helpers.IsDeviceMobile)
			MoveWithTouch ();
		else
			MoveWithMouse ();
	}

	private void MoveWithTouch ()
	{
		if(Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			Ray ray = Camera.main.ScreenPointToRay (touch.position);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit))
				character.MoveTo (hit.point);
		}

	}

	private void MoveWithMouse ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit))
				character.MoveTo (hit.point);
		}
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