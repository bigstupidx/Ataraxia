using UnityEngine;
using System.Collections;

public class CharacterDectector : MonoBehaviour 
{
	private Transform myTransform;
	public Character Character
	{
		get;
		private set;
	}

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
		Character = obj.GetComponent<Character> ();
		if(Character != null)
			CanWatering = true;
	}

	private void OnTriggerExit(Collider obj)
	{
		Character = obj.GetComponent<Character> ();
		if(Character != null)
			CanWatering = false;
	} 
}