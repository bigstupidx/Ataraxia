using UnityEngine;
using System.Collections;

public class CharacterLookAtCamera : CharacterBehaviour
{
	private CharacterController characterController;
	private Transform myTransform ;
	private Transform cameraTransform;

	private void Start ()
	{
		myTransform = transform;
		cameraTransform = Camera.main.transform;
	}

	public override void Execute () 
	{
		if( Board.Instance != null && Board.Instance.GameState != GameState.MovingTurn)
		{ 
			Vector3 target = new Vector3(cameraTransform.position.x,myTransform.position.y,cameraTransform.position.z);
			myTransform.LookAt(target);
		}
	}
	
	public override void SetCharacterController (CharacterController characterController)
	{
		this.characterController = characterController;
	}
}