using UnityEngine;
using System.Collections;

public class CharacterMoveByMouse : ICharacterMoveInput
{
	private Camera cameraToRay;
	private CharacterMoveToPoint characerController;

	public CharacterMoveByMouse (CharacterMoveToPoint character, Camera camera)
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
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = cameraToRay.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit))
				characerController.MoveTo (hit.point);
		}
	}
}
