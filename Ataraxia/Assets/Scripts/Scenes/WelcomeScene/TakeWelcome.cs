using UnityEngine;
using System.Collections;

public class TakeWelcome : TakeManagerBase
{
	private Portal portal;
	private void Start ()
	{
		if(UserData.HasDialogTypeFinished(sceneDialogType))
			this.enabled = false;
		else
			this.StartScene ();
	}

	protected override void StartScene ()
	{
		base.StartScene ();
		portal = FindObjectOfType<Portal> ();
		portal.IsEnabled = false;
	}

	protected override void EndScene ()
	{
		portal.IsEnabled = true;
		UserData.SetDialogTypeFinished(sceneDialogType);
		CameraManager.Instance.SetDefault ();
	}
}
