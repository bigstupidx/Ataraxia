using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
	public bool isEnableControlToMove = false;
	public CharacterType characterType;
	[SerializeField]
	private CharacterController characterController;
	[SerializeField]
	private Transform myTransform;
	[SerializeField]
	private CharacterMoveToPoint character;
	private CharacterBehaviour [] behaviours;
	private ICharacterMoveInput characerMoveByInput;

	public Vector3 Position
	{
		get { return myTransform.position; }
	}

	public bool HasGetArrive
	{
		get{ return character.HasArrivedToTargetPoint;}
	}

	private void Start ()
	{
		myTransform = transform;
		HandleCharacterController ();
		GetControlInputToMove ();
	}

	public float GetDistance (Square square)
	{
		return Vector3.Distance (Position,square.Position);
	}

	private void GetControlInputToMove ()
	{
		if(isEnableControlToMove)
			characerMoveByInput = GetInputToMove (character);
	}

	private ICharacterMoveInput GetInputToMove (CharacterMoveToPoint character)
	{
		if(Helpers.IsDeviceMobile)
			return new CharacterMoveByTouch (character,Camera.main);
		else
			return new CharacterMoveByMouse (character,Camera.main);
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

	public void MoveTo ( Vector3 position )
	{
		character.MoveTo(position);
	}

	private void Update ()
	{
		if(characerMoveByInput != null)
			characerMoveByInput.Move ();

		foreach(CharacterBehaviour behaviour in behaviours)
			behaviour.Execute ();
	}
}