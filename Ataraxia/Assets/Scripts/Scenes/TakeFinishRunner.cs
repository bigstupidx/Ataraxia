using UnityEngine;
using System.Collections;

public class TakeFinishRunner : TakeManagerBase
{
	private void Start ()
	{
		if(UserData.HasDialogTypeFinished(SceneDialogType.FinishJungle))
			base.StartScene ();
	}

	protected override void EndScene ()
	{
		UserData.SetDialogTypeFinished(sceneDialogType);
		CameraManager.Instance.SetDefault ();
		FinishActivity ();
		LevelLoader.Instance.LoadScene(LevelLoader.MENU2);
	}
}