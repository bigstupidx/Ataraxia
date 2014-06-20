using UnityEngine;
using System.Collections;

public class TakeCrystal : TakeManagerBase
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
		UserData.SetDialogTypeFinished(sceneDialogType);
		CameraManager.Instance.SetDefault ();
		FinishActivity ();
		LevelLoader.Instance.LoadScene ( LevelLoader.CONGRATULATIONS);
	}
}