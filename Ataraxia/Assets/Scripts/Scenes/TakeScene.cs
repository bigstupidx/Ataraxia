using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class TakeScene : MonoBehaviour
{
	[SerializeField]
	private Camera camera;
	[SerializeField]
	protected DialogDescriptor dialog;
	private Action End;
	private CameraManager cameraManager;
	protected bool isOver;

	protected virtual void Awake()
	{
		isOver = false;
		gameObject.SetActive(false);
	}

	public virtual void StartScene (Action endCallback, CameraManager cameraManager)
	{
		isOver = false;
		End = endCallback;
		this.cameraManager = cameraManager;
		if(camera != null)
			this.cameraManager.SetCamera3D(camera);
		else
			this.cameraManager.SetDefault ();
	}
	
	protected virtual void EndTake()
	{
		if(isOver)
			return;

		isOver = true;
		End ();
		gameObject.SetActive(false);
	}

	
	protected virtual void StartDialog ()
	{
		if(LevelLoader.Instance.IsMainRoomScene)
			Menu.Instance.dialogMessage.Show(dialog,EndTake);
		else
			UIGame.Instance.UIDialogMessage.Show(dialog,EndTake);
	}
}