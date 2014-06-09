using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour 
{
	[SerializeField]
	private float velocity;
	public bool activate = false;
	public float maxPos = 1.0f;
	public int maxTime = 3;
	public bool activeDice = false;
	private Vector3 initPos;
	private Quaternion initRot;
	private Transform myTransform;

	public int Value 
	{
		get;
		set;
	}

	private void Start()
	{
		myTransform = transform;
		initRot = Quaternion.identity;
		initPos = transform.localPosition;
	}
	
	private void Update () 
	{	
		Debug.Log(Value);
		if(!activate)
			return;
		
		Throw ();
	}

	private void Throw ()
	{
		myTransform.RotateAroundLocal (Vector3.up, Random.Range (200, 300) * Time.deltaTime * velocity);
		myTransform.RotateAroundLocal (Vector3.forward, Random.Range (200, 300) * Time.deltaTime * velocity);
		myTransform.RotateAroundLocal (Vector3.left, Random.Range (200, 300) * Time.deltaTime * velocity);
	}
	
	private void OnMouseDown() 
	{	
		if(!activeDice)
			return;
		
		activeDice = false;
		Move ();
		activate = true;
		Invoke("Fall",Random.Range(1,3));
	}

	private void Move ()
	{
		Vector3 newRot = new Vector3 (Random.Range (0, 360), Random.Range (0, 360), Random.Range (0, 360));
		myTransform.rigidbody.useGravity = false;
		myTransform.localPosition = initPos;
		myTransform.localRotation = initRot;
		myTransform.localRotation = Quaternion.Euler (newRot);
	}
	
	private void Fall()
	{
		activate = activeDice = false;
		myTransform.rigidbody.useGravity = true;
	}
}