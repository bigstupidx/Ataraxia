using System;
using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider))]
public class HidingPlace : MonoBehaviour 
{
	[SerializeField]
	private Transform placeToSaveCharacter;
	private Transform character;
	public Action <HidingPlace> PressedPlace;

	public Transform Character
	{
		get{return character;}
	}

	public bool HasCharacterHidden
	{
		get { return placeToSaveCharacter.childCount > 0; }
	}

	public void HideCharacter ( Transform transform )
	{
		character = transform;
		transform.parent = placeToSaveCharacter;
		transform.localPosition = Vector3.zero;
	}

	private void OnMouseDown ()
	{
		if(PressedPlace != null)
			PressedPlace(this);
	}
}