using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HiddenManager : MonoBehaviour 
{
	[SerializeField]
	private string goalText;
	[SerializeField]
	private string failText;
	[SerializeField]
	private int maxChances;
	[SerializeField]
	private GameObject blackScreen;
	[SerializeField]
	private Character character;
	[SerializeField]
	private Timer time;
	[SerializeField]
	private Transform cameraTransform;
	[SerializeField]
	private AtaraxiaText readyText;
	[SerializeField]
	private List<Transform> charactersToHide;
	private HidingPlace [] places;
	private int numGoals = 0;
	private Dictionary<Transform,Vector3> initialPoisitions = new Dictionary<Transform, Vector3>();
	private bool canStartGame;

	public Action Finish;

	public bool HasWon 
	{
		get;
		private set;
	}

	private void Start ()
	{
		places = FindObjectsOfType<HidingPlace> ();
		HideText ();
	}

	public void StartGame ()
	{
		blackScreen.SetActive (true);
		time.StartTimer ();
		character.LookAt(cameraTransform.position);
		character.StartCounting ( time.TotalTime );
		HideCharacters ();
		foreach(HidingPlace place in places)
			place.PressedPlace = TryToFind;
	}

	private void HideCharacters ()
	{
		foreach(Transform character in charactersToHide)
		{
			HidingPlace placeToHide = GetRandomHidingPlace ();
			initialPoisitions.Add(character,character.position);
			placeToHide.HideCharacter(character);
		}
	}

	private void TryToFind (HidingPlace place)
	{
		if(place.HasCharacterHidden && place.Character != null)
		{
			ShowCharacter (place);
			numGoals++;
			ShowMessage (goalText);
		}
		else
		{
			ShowMessage (failText);
			maxChances--;
		}
	}

	private void ShowMessage (string text)
	{
		readyText.Text = text;
		readyText.Hide(false);
		Invoke(Helpers.NameOf(HideText),1.5F);
	}

	private void HideText ()
	{
		readyText.Hide(true);
	}

	private void ShowCharacter (HidingPlace place)
	{
		Transform character =  place.Character;
		character.parent = null;
		character.position = initialPoisitions[character];
	}

	private HidingPlace GetRandomHidingPlace () 
	{
		int index = UnityEngine.Random.Range(0,places.Length);
		HidingPlace place = places[index];
		if(place.HasCharacterHidden)
			place = GetRandomHidingPlace ();
		return place;
	}

	private void Update ()
	{
		CheckHasLost ();
		CheckHasWon ();
		CheckIfCanStartGame ();
	}

	private void CheckIfCanStartGame ()
	{
		if (time.IsTimeOver && !canStartGame) 
		{
			canStartGame = true;
			readyText.Hide (false);
			Invoke (Helpers.NameOf (HideBlackScreen), 1.5F);
		}
	}

	private void CheckHasLost ()
	{
		if (maxChances == 0 && Finish != null) 
		{
			HasWon = false;
			Finish ();
			Finish = null;
		}
	}

	private void CheckHasWon ()
	{
		if (numGoals == charactersToHide.Count && Finish != null) 
		{
			HasWon = true;
			Finish ();
			Finish = null;
		}
	}

	private void HideBlackScreen ()
	{
		character.RestartRotation ();
		readyText.Hide (true);
		blackScreen.SetActive ( false);
	}
}