using UnityEngine;
using System.Collections;

public class CharacterMoveToPoint : MonoBehaviour 
{
	[SerializeField]
	private CharacterController characterController;
	[SerializeField]
	private Transform myTransform;
	[SerializeField]
	private float velocity = 20f;
	[SerializeField]
	private float proximity = 0.25f;
	private Transform target;
	private Vector3 direction;

	private float SqrtDist
	{
		get { return (myTransform.position - target.position).sqrMagnitude; }
	}

	public void MoveTo(Transform target)
	{
		this.target = target;
	}

	private void Update () 
	{
		if(target != null)
		{
			direction = GetDirection ();
			direction.Normalize ();
			MoveToTarget ();
		}
	}

	private void MoveToTarget ()
	{
		if (SqrtDist > proximity) 
		{
			myTransform.LookAt (GetTargetPosition ());
			myTransform.eulerAngles = new Vector3 (0, myTransform.eulerAngles.y, 0);
			characterController.SimpleMove (direction * velocity);
		}
	}

	private Vector3 GetTargetPosition ()
	{
		return myTransform.position + direction * velocity * Time.deltaTime;
	}

	private Vector3 GetDirection ()
	{
		Vector3 newDirection = target.position - myTransform.position;
		return newDirection;
	}
}