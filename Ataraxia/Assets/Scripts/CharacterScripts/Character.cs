using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
	public CharacterType characterType;
	[SerializeField]
	private CharacterController characterController;
	[SerializeField]
	private Transform myTransform;
	private CharacterBehaviour [] behaviours;

	private void Start ()
	{
		myTransform = transform;
		HandleCharacterController ();
	}

	private void HandleCharacterController ()
	{
		behaviours = GetComponentsInChildren<CharacterBehaviour> ();
		foreach (CharacterBehaviour behaviour in behaviours)
			behaviour.SetCharacterController (characterController);
	}

	public void PositionTo ( Vector3 position )
	{
		myTransform.localPosition = position;
	}

	public void MoveTo ( Transform position )
	{
		foreach(CharacterBehaviour behaviour in behaviours)
		{
			if(behaviour is CharacterMoveToPoint)
			{
				CharacterMoveToPoint behaviourMove = behaviour as CharacterMoveToPoint;
				behaviourMove.MoveTo(position);
			}
		}
	}

	private void Update ()
	{
		foreach(CharacterBehaviour behaviour in behaviours)
			behaviour.Execute ();
	}
}