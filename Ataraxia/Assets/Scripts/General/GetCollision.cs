using UnityEngine;
using System.Collections;

public class GetCollision : MonoBehaviour 
{
	public FishItem CurrentItemCollisioning;

	private void OnTriggerEnter(Collider obj)
	{
		CurrentItemCollisioning = obj.GetComponent<FishItem> ();
	}

	private void OnTriggerExit(Collider obj)
	{
		CurrentItemCollisioning = null;
	}

	public void Catched ()
	{
		CurrentItemCollisioning.RestartPosition ();
		CurrentItemCollisioning = null;
	}
}
