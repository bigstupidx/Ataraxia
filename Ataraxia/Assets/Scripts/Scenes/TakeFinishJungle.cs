using UnityEngine;
using System.Collections;

public class TakeFinishJungle : TakeManagerBase
{
	[SerializeField]
	private Character character;

	private void Start ()
	{
		if(UserData.HasDialogTypeFinished(sceneDialogType))
			this.enabled = false;
	}

	public void Play ()
	{
		character.RestarToIdle ();
		base.StartScene ();
	}

	protected override void EndScene ()
	{
		UserData.SetDialogTypeFinished(sceneDialogType);
		CameraManager.Instance.SetDefault ();
		FinishActivity ();
		Board.Instance.LoadSpecialGame ();
	}
}