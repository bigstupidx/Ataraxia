using UnityEngine;
using System.Collections;

public class TakeStartJungle : TakeManagerBase
{
	private void Start ()
	{
		if(UserData.HasDialogTypeFinished(sceneDialogType))
			this.enabled = false;
		else
			this.StartScene ();
	}

	protected override void EndScene ()
	{
		Board.Instance.StartGame ();
		UserData.SetDialogTypeFinished(sceneDialogType);
		FinishActivity ();
	}
}