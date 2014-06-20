using UnityEngine;
using System.Collections;
using System;

public class RunnerManager : MonoBehaviour 
{
	[SerializeField]
	private float minDistance;
	[SerializeField]
	private CameraFollowerSmooth camera;
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
		{
			this.currentCharacterDetector = null;
			character.PositionTo(CurrentPath.InitialPoint + (Vector3.up * 3));
		}
	}

	private void OnGUI ()
	{
		if(GUI.Button( new Rect (0F,0F,120F,25F),"Move Left") && this.currentCharacterDetector != null && CurrentPath.nextDirection == DirectionToRotate.Left)
			Move ();

		if(GUI.Button( new Rect (0F,30F,120F,25F),"Move Right") && this.currentCharacterDetector != null && CurrentPath.nextDirection == DirectionToRotate.Right)
			Move ();
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