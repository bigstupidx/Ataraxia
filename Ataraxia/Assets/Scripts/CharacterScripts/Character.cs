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
	[SerializeField]
	private CharacterLookAtCamera lookAtController;
	private CharacterBehaviour [] behaviours;
	private ICharacterMoveInput characerMoveByInput;
	private AnimationManager animationManager;
	private Quaternion initialRotation;

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
		initialRotation = Quaternion.identity;
		GetAnimationManager ();
		myTransform = transform;
		HandleCharacterController ();
		GetControlInputToMove ();
	}

	private void GetAnimationManager ()
	{
		Animation animation = GetComponentInChildren<Animation> ();
		animationManager = new AnimationManager (animation);
	}

	public void StartCelebration ()
	{
		Animation anim = animationManager.Play( AnimationManager.CELEBRATION);
		Invoke(Helpers.NameOf(RestarToIdle), anim[AnimationManager.CELEBRATION].length);
	}

	public void StartLose ()
	{
		Animation anim = animationManager.Play( AnimationManager.LOSE);
		Invoke(Helpers.NameOf(RestarToIdle), anim[AnimationManager.LOSE].length);
	}

	public void StartCounting (float time)
	{
		animationManager.Play( AnimationManager.COUNT);
		Invoke(Helpers.NameOf(RestarToIdle),time);
	}

	private void RestarToIdle ()
	{
		animationManager.Play(AnimationManager.IDLE);
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

	public void LookAt (Vector3 target)
	{
		lookAtController.LookAt(target);
	}

	public void RestartRotation ()
	{
		myTransform.rotation = initialRotation;
	}

	private void Update ()
	{
		if(characerMoveByInput != null)
			characerMoveByInput.Move ();

		foreach(CharacterBehaviour behaviour in behaviours)
			behaviour.Execute ();
	}
}