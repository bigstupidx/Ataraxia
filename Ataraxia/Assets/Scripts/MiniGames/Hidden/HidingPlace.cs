using System;
using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider))]
public class HidingPlace : MonoBehaviour 
{
	[SerializeField]
	private Transform placeToSaveCharacter;
	public Action <HidingPlace> PressedPlace;

	public bool HasCharacterHidden
	{
		get;
		private set;
	}

	public void HideCharacter ( Transform transform )
	{
		HasCharacterHidden = true;
		transform.parent = placeToSaveCharacter;
		transform.localPosition = Vector3.zero;
	}

	private void OnMouseDown ()
	{
		if(PressedPlace != null)
			PressedPlace(this);
	}
}