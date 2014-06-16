using UnityEngine;
using System.Collections;

public class MeetTheOldMan: TakeScene
{
	[SerializeField]
	private Transform finalPosition;
	private CharacterMoveToPoint characterMove;
	private bool canShowTheMessage = true;
	private Transform characterTransform;
	private Transform oldMan;

	public override void StartScene (System.Action endCallback, CameraManager cameraManager)
	{
		base.StartScene (endCallback, cameraManager);
		HandleMainCharacter ();
		GetNonPlayableCharacter ();
	}

	private void GetNonPlayableCharacter ()
	{
		Character characterOldMan = Menu.Instance.GetCharacterByType (CharacterType.OldMen);
		oldMan = characterOldMan.transform;
	}

	private void HandleMainCharacter ()
	{
		Character character = Menu.Instance.GetCharacterByType (CharacterType.Ataraxia);
		characterTransform = character.transform;
		character.MoveTo (finalPosition.position);
		characterMove = character.GetComponent<CharacterMoveToPoint> ();
	}

	private void Update ()
	{
		if(characterMove != null && characterMove.HasArrivedToTargetPoint && canShowTheMessage)
		{
			canShowTheMessage = false;
			StartDialog ();
		}

		if(!this.canShowTheMessage)
			characterMove.LookAt (oldMan.position);
	}
}