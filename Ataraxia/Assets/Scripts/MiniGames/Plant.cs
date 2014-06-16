using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour 
{
	[SerializeField]
	private MeshTransform meshTransform;
	[SerializeField]
	private int minLife;
	[SerializeField]
	private int maxLife;

	private int life;


	private void Update ()
	{
		//meshTransform.SetMorph( );
	}
}
