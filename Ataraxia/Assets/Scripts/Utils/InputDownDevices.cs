using UnityEngine;
using System.Collections;
#if UNITY_ANDROID || UNITY_IPHONE
public class InputDownDevices : MonoBehaviour 
{
	private void Update () 
	{
		RaycastHit hit = new RaycastHit();
		for (int i = 0; i < Input.touchCount; ++i) 
		{
			if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)) 
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
				if (Physics.Raycast(ray, out hit)) 
					hit.transform.gameObject.SendMessage("OnMouseDown");
			}
		}
	}
}
#endif