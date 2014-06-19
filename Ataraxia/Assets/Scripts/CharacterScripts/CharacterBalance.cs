using UnityEngine;
using System.Collections;

public enum SideToBalance
{
	Left = 0,
	Right = 1
}
public class CharacterBalance : MonoBehaviour 
{
	[SerializeField]
	private float rateToRotate;
	[SerializeField]
	private Transform endPoint;
	[SerializeField]
	private Transform myTransform;
	[SerializeField]
	private CharacterController character;
	private SideToBalance side;
	private AnimationManager animationManager;

	private void Start ()
	{
		Animation animation = GetComponentInChildren<Animation> ();
		animationManager = new AnimationManager (animation);
		GetSide ();
	}

	private void Update ()
	{
		float distance = Vector3.Distance(myTransform.position , endPoint.position);
		if(distance > 4F)
		{
			myTransform.Rotate (Vector3.forward,-rateToRotate);
			Vector3 newDirection = endPoint.position - myTransform.position;
			newDirection.Normalize ();
			character.Move( newDirection  * 0.4F);
		}
	}

	private void GetSide ()
	{
		int sideIndex = Random.Range (0, 1);
		if (sideIndex == 0)
			side = SideToBalance.Left;
		else
			side = SideToBalance.Right;
	}
}
