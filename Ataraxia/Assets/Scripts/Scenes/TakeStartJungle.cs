using UnityEngine;
using System.Collections;

public class TakeStartJungle : TakeManagerBase
{
	[SerializeField]
	private Transform bochica;
	[SerializeField]
	private Transform place;

	private void Start ()
	{
		if(UserData.HasDialogTypeFinished(sceneDialogType))
		{
			ManageBochicaPosition ();
			this.enabled = false;
		}
		else
			this.StartScene ();
	}

	private void OnApplicationQuit ()
	{
		UserData.ClearDialog(sceneDialogType);
	}

	protected override void EndScene ()
	{
		Board.Instance.StartGame ();
		UserData.SetDialogTypeFinished(sceneDialogType);
		FinishActivity ();
		ManageBochicaPosition ();
		CameraManager.Instance.SetDefault ();
	}

	private void ManageBochicaPosition ()
	{
		bochica.parent = place;
		bochica.localPosition = Vector3.zero;
	}
}