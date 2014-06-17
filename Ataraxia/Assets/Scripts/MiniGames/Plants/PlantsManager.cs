using UnityEngine;
using System.Collections;

public class PlantsManager : MonoBehaviour 
{
	[SerializeField]
	private CharacterLookAtCamera lookAtController;
	[SerializeField]
	private Character character;
	[SerializeField]
	private Plant [] plants;
	private bool isCharacterMoving = false;
	private int currentPlant = 1;
	private int maxLife;

	public bool HasWonGame 
	{
		get { return CheckIfWonGame (); }
	}

	private bool CheckIfWonGame ()
	{
		int currentLife = 0;
		foreach (Plant plant in plants)
			currentLife += plant.Life;
		float rate =  (float)currentLife / (float)maxLife;
		return rate > 0.35F;
	}

	private void Start ()
	{
		foreach(Plant plant in plants)
		{
			maxLife += plant.MaxLife;
			plant.GetWateringPosition += MoveCharacterToPosition;
		}
	}

	private	void MoveCharacterToPosition (Vector3 position, Plant plant)
	{
		currentPlant = GetCurrentPlant (plant);
		isCharacterMoving = true;
		character.MoveTo (position);
	}

	private int GetCurrentPlant (Plant plant)
	{
		for(int i = 0; i < plants.Length; i++)
		{
			if(plants[i] == plant)
				return i;
		}
		return 1;
	}

	private void Update ()
	{
		if(character.HasGetArrive && isCharacterMoving)
		{
			isCharacterMoving = false;
			Vector3 target = plants[currentPlant].Position;
			lookAtController.LookAt (target);
		}
	}
}