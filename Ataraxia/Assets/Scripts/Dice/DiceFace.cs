using UnityEngine;
using System.Collections;

public class DiceFace : MonoBehaviour {
	
	public int value = 0;
	public Dice dice;
	
	private void OnTriggerEnter(Collider face) 
	{
		dice.Value = value;
    }
}