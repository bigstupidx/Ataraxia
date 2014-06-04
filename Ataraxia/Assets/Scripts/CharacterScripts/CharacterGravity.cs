using UnityEngine;
using System.Collections;

public class CharacterGravity : MonoBehaviour 
{
	[SerializeField]
	private float gravity = 20.0F;
	[SerializeField]
	private CharacterController characterController;
	private Vector3 moveDirection = Vector3.zero;
	
	private void Update () 
	{
		if (!characterController.isGrounded)
		{
	   		moveDirection.y -= gravity * Time.deltaTime;
	   		characterController.Move(moveDirection * Time.deltaTime);
		}
	}
}
