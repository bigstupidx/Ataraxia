using UnityEngine;
using System.Collections;

public class TakeWelcomeStep : TakeScene
{
	[SerializeField]
	private Transform initPositionCharacter;
	[SerializeField]
	private float timeToStartMessage = 3F;

	public override void StartScene (System.Action endCallback, CameraManager cameraManager)
	{
		base.StartScene (endCallback, cameraManager);
		Character character = Menu.Instance.GetCharacterByType(CharacterType.Ataraxia);
		character.PositionTo (initPositionCharacter.position);
		Invoke (Helpers.NameOf(StartDialog),timeToStartMessage);

	}
}