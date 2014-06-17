using UnityEngine;
using System.Collections;

public abstract class CharacterBehaviour : MonoBehaviour
{
	protected AnimationManager animationManager;
	protected virtual void Start ()
	{
		Animation animation = GetComponentInChildren<Animation> ();
		animationManager = new AnimationManager(animation);
	}

	public abstract void Execute ();
	public abstract void SetCharacterController (CharacterController characterController);
}
