using UnityEngine;
using System.Collections;

public class MarkArea : MonoBehaviour 
{
	[SerializeField]
	private string name;
	[SerializeField]
	private Color color;
	[SerializeField]
	private Transform parent;
	[SerializeField]
	private Vector3 area;

	private void OnDrawGizmos () 
	{
		Gizmos.color = color;
		Gizmos.DrawWireCube(parent.position, area);		
	}
}
