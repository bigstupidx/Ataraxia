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

	public bool IsWaitingToCatch 
	{
		get{ return animationManager.IsPlaying(AnimationManager.FISHING); }
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

	public void StartCelebrationLoop ()
	{
		Animation anim = animationManager.Play( AnimationManager.CELEBRATION);
	}

	public void StartRunning ()
	{
		Animation anim = animationManager.Play( AnimationManager.RUN);
	}

	public void Catch ()
	{
		Animation anim = animationManager.Play( AnimationManager.CATCH);
		Invoke(Helpers.NameOf(RestartToIdleFishing), anim[AnimationManager.CATCH].length);
	}

	public void HitDice ()
	{
		Animation anim = animationManager.Play( AnimationManager.JUMP_DICE);
		Invoke(Helpers.NameOf(RestartToIdleFishing), anim[AnimationManager.JUMP_DICE].length);
	}

	private void RestartToIdleFishing ()
	{
		animationManager.Play( AnimationManager.FISHING);
	}

	public void StartCelebration ()
	{
		Animation anim = animationManager.Play( AnimationManager.CELEBRATION);
		if(anim != null && anim[AnimationManager.CELEBRATION] != null)
			Invoke(Helpers.NameOf(RestarToIdle), anim[AnimationManager.CELEBRATION].length);
	}

	public void StartLose ()
	{
		Animation anim = animationManager.Play( AnimationManager.LOSE);
		Invoke(Helpers.NameOf(RestarToIdle), anim[AnimationManager.LOSE].length);
	}

	public void Watering ()
	{
		animationManager.Play(AnimationManager.WATERING);
	}

	public void StartCounting (float time)
	{
		animationManager.Play( AnimationManager.COUNT);
		Invoke(Helpers.NameOf(RestarToIdle),time);
	}

	public void RestarToIdle ()
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

	public void Stop ()
	{
		character.MoveTo ( Vector3.zero);
		RestarToIdle ();
	}

	private void Update ()
	{
		if(characerMoveByInput != null)
			characerMoveByInput.Move ();

		foreach(CharacterBehaviour behaviour in behaviours)
			behaviour.Execute ();
	}
}