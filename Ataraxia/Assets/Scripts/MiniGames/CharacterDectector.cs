using UnityEngine;
using System.Collections;
using System;

public class CharacterDectector : MonoBehaviour 
{
	public Action<CharacterDectector> OnTriggerDetection;
	private Transform myTransform;
	public Character Character
	{
		get;
		private set;
	}

	public bool CanAction
	{
		get;
		private set;
	}

	public Vector3 Position
	{
		get{return myTransform.position;}
	}

	private void Start ()
	{
		myTransform = transform;
	}

	private void OnTriggerEnter (Collider obj)
	{
		Character = obj.GetComponent<Character> ();
		if(Character != null)
			CanAction = true;

		if(OnTriggerDetection != null)
			OnTriggerDetection(this);
	}

	private void OnTriggerExit(Collider obj)
	{
		Character = obj.GetComponent<Character> ();
		if(Character != null)
			CanAction = false;

		if(OnTriggerDetection != null)
			OnTriggerDetection = null;
	} 
}