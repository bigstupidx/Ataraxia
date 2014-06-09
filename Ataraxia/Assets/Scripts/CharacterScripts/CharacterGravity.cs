using UnityEngine;
using System.Collections;

public class CharacterGravity : CharacterBehaviour
{
	[SerializeField]
	private float gravity = 20.0F;
	private CharacterController characterController;
	private Vector3 moveDirection = Vector3.zero;


	public override void SetCharacterController (CharacterController characterController)
	{
		this.characterController = characterController;
	}

	public override void Execute () 
	{
		if (!characterController.isGrounded)
		{
	   		moveDirection.y -= gravity * Time.deltaTime;
	   		characterController.Move(moveDirection * Time.deltaTime);
		}
	}
}
