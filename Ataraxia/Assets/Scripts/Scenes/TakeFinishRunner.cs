﻿using UnityEngine;
using System.Collections;

public class TakeFinishRunner : TakeManagerBase
{
	public Character character;
	public Transform endPoint;
	public Transform bochicaToPlace;
	public Transform bochica;

	public void Play ()
	{
		if(UserData.HasDialogTypeFinished(SceneDialogType.FinishJungle))
		{
			bochica.parent = bochicaToPlace;
			bochica.localPosition = Vector3.zero;
			character.PositionTo(endPoint.position);
			character.RestarToIdle ();
			base.StartScene ();
		}
	}

	protected override void EndScene ()
	{
		UserData.SetDialogTypeFinished(sceneDialogType);
		CameraManager.Instance.SetDefault ();
		FinishActivity ();
		LevelLoader.Instance.LoadScene(LevelLoader.MENU2);
	}
}