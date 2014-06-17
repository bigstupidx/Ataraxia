using UnityEngine;
using System.Collections;

public class PlantsManager : MonoBehaviour 
{
	[SerializeField]
	private Character character;
	[SerializeField]
	private Plant [] plants;
	private bool isCharacterMoving = false;

	private void Start ()
	{
		foreach(Plant plant in plants)
			plant.GetWateringPosition += MoveCharacterToPosition;
	}

	private	void MoveCharacterToPosition (Vector3 position)
	{
		isCharacterMoving = true;
		character.MoveTo (position);
	}

	private void Update ()
	{
		if(character.HasGetArrive && isCharacterMoving)
		{
			isCharacterMoving = false;
			Debug.Log("Has Get Arrive");
		}
	}
}