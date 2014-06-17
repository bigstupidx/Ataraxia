using UnityEngine;
using System.Collections;

public class CharacterDectector : MonoBehaviour 
{
	private Transform myTransform;
	public bool CanWatering
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
		Character character = obj.GetComponent<Character> ();
		if(character != null)
			CanWatering = true;
	}

	private void OnTriggerExit(Collider obj)
	{
		Character character = obj.GetComponent<Character> ();
		if(character != null)
			CanWatering = false;
	} 
}