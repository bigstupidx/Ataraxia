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
				) && !Application.isEditor;
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

	public static void IsTouchingThisObject (Transform myTransform , out bool isTouching)
	{
		if (Input.GetMouseButtonDown (0) && !IsDeviceMobile) 
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) 
			{
				isTouching = hit.transform == myTransform;
				return;
			}
		}
		else if (Input.touchCount > 0 && IsDeviceMobile) 
		{
			Touch touch = Input.GetTouch (0);
			Ray ray = Camera.main.ScreenPointToRay (touch.position);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) 
			{
				isTouching = hit.transform == myTransform;
				return;
			}
		}

		isTouching = false;
	}

	public static bool IsntTouchingScreen ()
	{
		if(IsDeviceMobile)
			return Input.touchCount == 0;
		return Input.GetMouseButtonUp (0); 
	}
}