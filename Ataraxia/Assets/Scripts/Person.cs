using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Person : MonoBehaviour {
	private List<Box> boxes;

	// Use this for initialization
	private void Start () 
	{
		boxes = new List<Box> ();
		foreach (Box box in FindObjectsOfType<Box> () )
			boxes.Add(box);
		Debug.Log(boxes.Count);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
