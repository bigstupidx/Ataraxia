using UnityEngine;
using System.Collections;

public abstract class CharacterBehaviour : MonoBehaviour
{
	public abstract void Execute ();
	public abstract void SetCharacterController (CharacterController characterController);
}
