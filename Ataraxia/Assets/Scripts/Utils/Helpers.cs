using UnityEngine;
using System.Collections;

public class Helpers
{
	public static string NameOf(System.Action callback)
	{
		return callback.Method.Name;
	}

	public static bool IsDeviceMobile 
	{
		get
		{
			return (
				Application.platform == RuntimePlatform.Android || 
			   	Application.platform == RuntimePlatform.IPhonePlayer ||
			   	Application.platform == RuntimePlatform.WP8Player
			);
		}
	}

	public static bool IsTakeSceneActive ()
	{
		TakeManagerBase [] takeScenes = MonoBehaviour.FindObjectsOfType<TakeManagerBase> ();
		foreach(TakeManagerBase takeScene in takeScenes)
		{
			if(takeScene.IsTakeActive)
				return true;
		}
		return false;
	}
}