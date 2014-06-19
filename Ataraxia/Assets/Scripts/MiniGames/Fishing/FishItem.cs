using UnityEngine;
using System.Collections;

public class FishItem : MonoBehaviour 
{
	[SerializeField]
	private Transform myTransform;
	[SerializeField]
	private float speed;
	[SerializeField]
	private Vector3 initialPosition;

	private void Start ()
	{
		initialPosition = myTransform.localPosition;
	}

	public void RestartPosition ()
	{
		myTransform.localPosition = initialPosition;
	}

	private void Update () 
	{
		myTransform.Translate(Vector3.left * Time.deltaTime * speed);
	}
}