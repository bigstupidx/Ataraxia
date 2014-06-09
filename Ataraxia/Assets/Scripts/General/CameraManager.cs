using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour 
{
	public Camera defaultCamera;
	public Camera uiDefaultCamera;
	private Camera previousCamera;
	public Camera CurrentCamera
	{
		get;
		private set;
	}

	public static CameraManager Instance
	{
		get;
		private set;
	}

	private List<Camera> Cameras
	{
		get
		{
			List<Camera> cameras = new List<Camera> ();
			foreach(Camera cameraObject in Camera.allCameras)
			{
				if(cameraObject != uiDefaultCamera)
					cameras.Add(cameraObject);
			}
			return cameras;
		}
	}

	private void Awake ()
	{
		if(Instance == null)
		{
			Instance =	this;
			DesactivateCurrentCamera ();
			CurrentCamera = defaultCamera;
			ActivateCurrentCamera ();
		}
	}

	private void ActivateCurrentCamera ()
	{
		CurrentCamera.enabled = true;
	}

	private void DesactivateCurrentCamera ()
	{
		foreach(Camera cameraObject in this.Cameras )
		{
			if(cameraObject != this.CurrentCamera)
				cameraObject.enabled = false;
		}
	}

	public void SetCamera3D(Camera camera)
	{
		previousCamera = CurrentCamera;
		CurrentCamera = camera;
		DesactivateCurrentCamera ();
		ActivateCurrentCamera ();
	}

	public void SetDefault ()
	{
		SetCamera3D(defaultCamera);
	}
}