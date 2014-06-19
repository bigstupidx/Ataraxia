using UnityEngine;
using System.Collections;

public class CharacterLookAtCamera : CharacterBehaviour
{
	private CharacterController characterController;
	private Transform myTransform ;
	private Transform cameraTransform;

	protected override void Start ()
	{
		base.Start ();
		myTransform = transform;
		if(Camera.main != null)
			cameraTransform = Camera.main.transform;
	}

	public override void Execute () 
	{
		if( Board.Instance != null && Board.Instance.GameState != GameState.MovingTurn && Board.Instance.GameState != GameState.Dialog)
		{ 
			Vector3 target = new Vector3(cameraTransform.position.x,myTransform.position.y,cameraTransform.position.z);
			LookAt (target);
		}
	}

	public void LookAt (Vector3 target)
	{
		myTransform.LookAt(target);
	}
	
	public override void SetCharacterController (CharacterController characterController)
	{
		this.characterController = characterController;
	}
}