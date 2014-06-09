using UnityEngine;
using System.Collections;

public class SimpleDialog : TakeScene
{
	public override void StartScene (System.Action endCallback, CameraManager cameraManager)
	{
		base.StartScene (endCallback, cameraManager);
		Invoke (Helpers.NameOf(StartDialog),0.5F);
	}
}