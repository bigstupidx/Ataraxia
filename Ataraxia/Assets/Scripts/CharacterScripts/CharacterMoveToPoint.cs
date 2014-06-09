using UnityEngine;
using System.Collections;

public class CharacterMoveToPoint : CharacterBehaviour
{
	[SerializeField]
	private Transform myTransform;
	[SerializeField]
	private float velocity = 20f;
	[SerializeField]
	private float proximity = 0.25f;
	private Vector3 target = Vector3.zero;
	private Vector3 direction;
	private CharacterController characterController;

	public bool HasArrivedToTargetPoint 
	{
		get
		{ 
			if( target == Vector3.zero )
				return true;
			return SqrtDist <= proximity; 
		}
	}

	private float SqrtDist
	{
		get { return (myTransform.position - target).sqrMagnitude; }
	}

	public void SetPosition ( Vector3 position )
	{
		this.myTransform.localPosition = position;
	}

	public void MoveTo(Transform target)
	{
		MoveTo(target.position);
	}

	public void MoveTo(Vector3 target)
	{
		this.target = target;
	}

	public override void Execute () 
	{
		if(target != Vector3.zero)
		{
			direction = GetDirection ();
			direction.Normalize ();
			MoveToTarget ();
		}
	}

	public override void SetCharacterController (CharacterController characterController)
	{
		this.characterController = characterController;
	}

	private void MoveToTarget ()
	{
		if (!HasArrivedToTargetPoint)
		{
			LookAt (direction);
			characterController.SimpleMove (direction * velocity);
		}
	}

	public void LookAt (Vector3 lookAtPosition)
	{
		myTransform.LookAt (GetTargetPosition (lookAtPosition));
		myTransform.eulerAngles = new Vector3 (0, myTransform.eulerAngles.y, 0);
	}

	private Vector3 GetTargetPosition (Vector3 lookAtPosition)
	{
		return myTransform.position + lookAtPosition * velocity * Time.deltaTime;
	}

	private Vector3 GetDirection ()
	{
		Vector3 newDirection = target - myTransform.position;
		return newDirection;
	}
}