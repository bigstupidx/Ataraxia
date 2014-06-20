using UnityEngine;
using System.Collections;

public class TakeFinishJungle : TakeManagerBase
{
	[SerializeField]
	private Character character;
	[SerializeField]
	private Transform endPoint;
	[SerializeField]
	private Transform bochicaPosition;
	[SerializeField]
	private Transform bochica;

	private void Start ()
	{
		if(UserData.HasDialogTypeFinished(sceneDialogType))
			this.enabled = false;
	}

	public void Play ()
	{
		bochica.parent = bochicaPosition;
		bochica.localPosition = Vector3.zero;
		character.PositionTo(endPoint.position);
		character.RestarToIdle ();
		base.StartScene ();
	}

	private void OnApplicationQuit ()
	{
		UserData.ClearDialog(sceneDialogType);
	}

	protected override void EndScene ()
	{
		UserData.SetDialogTypeFinished(sceneDialogType);
		CameraManager.Instance.SetDefault ();
		FinishActivity ();
		Board.Instance.LoadSpecialGame ();
	}
}