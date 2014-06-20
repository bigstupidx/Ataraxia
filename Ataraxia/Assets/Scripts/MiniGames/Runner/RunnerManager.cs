using UnityEngine;
using System.Collections;
using System;

public class RunnerManager : MonoBehaviour 
{
	[SerializeField]
	private Transform buttonLeft;
	[SerializeField]
	private Transform buttonRight;
	[SerializeField]
	private float minDistance;
	[SerializeField]
	private Character character;
	[SerializeField]
	private Path [] pathFinder;
	[SerializeField]
	private CharacterDectector [] detector;
	private int currentPathFinder = 0;
	private bool isInitialPoint = true;
	private CharacterDectector currentCharacterDetector;
	public Action OnFinishRun;

	private Path CurrentPath
	{
		get{return pathFinder[currentPathFinder];}
	}

	public void StartGame ()
	{
		if(isInitialPoint)
			character.MoveTo(CurrentPath.InitialPoint);
		foreach(CharacterDectector triggerObj in detector)
			triggerObj.OnTriggerDetection += OnGetAreaToMove;
	}

	private void Update ()
	{
		if(isInitialPoint)
		{
			float currentDistance = character.GetDistance (CurrentPath.InitialPoint);
			if(currentDistance < minDistance)
			{
				character.MoveTo(CurrentPath.EndPoint);
				isInitialPoint = false;
			}
		}

		if (character.Position.y < 3.0F)
			character.PositionTo(CurrentPath.InitialPoint + (Vector3.up * 3));

		GetButtonsToDraw ();
	}

	private void GetButtonsToDraw ()
	{
		if(CurrentPath.nextDirection == DirectionToRotate.Left)
		{
			buttonLeft.localScale = Vector3.one;
			if(this.currentCharacterDetector != null && CurrentPath.nextDirection == DirectionToRotate.Left)
				Move ();
		}
		else
			buttonLeft.localScale = Vector3.zero;

		if(CurrentPath.nextDirection == DirectionToRotate.Right)
		{
			buttonRight.localScale = Vector3.one;
			if(this.currentCharacterDetector != null && CurrentPath.nextDirection == DirectionToRotate.Right)
				Move ();
		}
		else
			buttonRight.localScale = Vector3.zero;
	}

	private void OnGetAreaToMove (CharacterDectector obj)
	{
		this.currentCharacterDetector = obj;
		if(this.currentCharacterDetector == this.detector[ this.detector.Length -1] && OnFinishRun != null)
			OnFinishRun ();
	}

	private void Move ()
	{
		this.currentCharacterDetector = null;
		currentPathFinder ++;
		isInitialPoint = true;
		character.MoveTo(CurrentPath.InitialPoint);
	}
}