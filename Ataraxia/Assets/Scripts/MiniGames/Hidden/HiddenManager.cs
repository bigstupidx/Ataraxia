using UnityEngine;
using System.Collections;

public class HiddenManager : MonoBehaviour 
{
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
	private bool canStartGame;

	private void Start ()
	{
		StartGame ();
		readyText.Hide (true);
	}

	public void StartGame ()
	{
		blackScreen.SetActive (true);
		time.StartTimer ();
		character.LookAt(cameraTransform.position);
		character.StartCounting ( time.TotalTime );
	}

	private void Update ()
	{
		if(time.IsTimeOver && !canStartGame )
		{
			canStartGame = true;
			readyText.Hide (false);
			Invoke( Helpers.NameOf ( HideBlackScreen ) , 1.5F);
		}
	}

	private void HideBlackScreen ()
	{
		character.RestartRotation ();
		readyText.Hide (true);
		blackScreen.SetActive ( false);
	}
}
