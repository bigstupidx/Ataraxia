using UnityEngine;
using System.Collections;

public class DiceTest : MonoBehaviour 
{
	[SerializeField]
	private bool canRotate = false;
	[SerializeField]
	private Transform myTransform;
	[SerializeField]
	private float delayToChangeRotation  = 0.5F;
	[SerializeField]
	private float velocity = 10F;
	private float timeToChangeDirection;
	private Vector3 directionPoint = Vector3.one;

	private void Start ()
	{
		GetNewDirectionPoint ();
	}

	private void Update () 
	{
		if (canRotate) 
			Rotate ();
	}

	private void Rotate ()
	{
		Vector3 direction = GetAxisDirection ();
		myTransform.Rotate (velocity * direction.x, velocity * direction.y, velocity * direction.z);
	}

	private Vector3 GetAxisDirection ()
	{
		if(Time.realtimeSinceStartup > timeToChangeDirection)
			GetNewDirectionPoint ();
		return directionPoint;
	}

	private void GetNewDirectionPoint ()
	{
		directionPoint = new Vector3 (GetValueToDirectionPoint (), GetValueToDirectionPoint (), GetValueToDirectionPoint ());
		timeToChangeDirection = Time.realtimeSinceStartup + delayToChangeRotation;
	}

	private float GetValueToDirectionPoint ()
	{
		float number = Random.value;
		if(number > 0.5F) return 1.0F;
		return -1.0F;
	}

	private void OnGUI ()
	{
		if(GUI.Button(new Rect(0F,0F,150F,25F),"Throw Dice"))
			canRotate = true;

		if(GUI.Button(new Rect(0F,50F,150F,25F),"Stop Dice"))
			canRotate = false;
	}
}