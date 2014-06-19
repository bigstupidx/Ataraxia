using UnityEngine;
using System.Collections;

public class TakeStartJungle : TakeManagerBase
{
	private void Start ()
	{
		this.StartScene ();
	}

	protected override void EndScene ()
	{
		Board.Instance.StartGame ();
		UserData.SetDialogTypeFinished(sceneDialogType);
		FinishActivity ();
	}
}