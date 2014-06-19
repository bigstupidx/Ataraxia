using UnityEngine;
using System.Collections;
#if UNITY_ANDROID || UNITY_IPHONE
public class InputDownDevices : MonoBehaviour 
{
	private void Update () 
	{
		RaycastHit hit = new RaycastHit();
		if (Input.touchCount > 0 && Input.GetTouch(0).phase.Equals(TouchPhase.Began)) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			if (Physics.Raycast(ray, out hit)) 
				hit.transform.gameObject.SendMessage("OnMouseDown");
		}
	}
}
#endif