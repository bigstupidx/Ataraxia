using UnityEngine;
using System.Collections;

public class CameraFollowerSmooth : MonoBehaviour 
{
	[SerializeField]
	private Transform target;
	[SerializeField]
	private float distance = 10.0F;
	[SerializeField]
	private float height = 5.0F;
	[SerializeField]
	private float heightDamping = 2.0F;
	[SerializeField]
	private float rotationDamping = 3.0F;
	private Transform myTransform;
	private bool canFollow = true;

	private void Start ()
	{
		myTransform = transform;
	}

	public void Play ()
	{
		canFollow = true;
	}

	public void Stop ()
	{
		canFollow = false;
	}

	private void LateUpdate () 
	{
		if(!canFollow)
			return;

		// Early out if we don't have a target
		if (!target)
			return;
		
		// Calculate the current rotation angles
		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;
		
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;
		
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		
		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		
		// Convert the angle into a rotation
		Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
		
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		myTransform.position = target.position;
		myTransform.position -= currentRotation * Vector3.forward * distance;
		
		// Set the height of the camera
		Vector3 currentPosition = myTransform.position;
		myTransform.position = new Vector3(currentPosition.x, currentHeight,currentPosition.z);
		
		// Always look at the target
		myTransform.LookAt (target);
	}
}