using UnityEngine;
using System.Collections;

public class CharacterMoveByTouch : ICharacterMoveInput 
{
	private Camera cameraToRay;
	private CharacterMoveToPoint characerController;
	
	public CharacterMoveByTouch (CharacterMoveToPoint character, Camera camera)
	{
		characerController = character;
		cameraToRay = camera;
	}
	
	public void Move ()
	{
		GetInputToMove ();
	}

	private void GetInputToMove ()
	{
		if(Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			Ray ray = cameraToRay.ScreenPointToRay (touch.position);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit))
				characerController.MoveTo (hit.point);
		}
	}
}
