using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour 
{
	[SerializeField]
	private Character chracter;
	[SerializeField]
	private Dice dice;
	[SerializeField]
	private GameObject squaresContainer;
	private List<Square> squares = new List<Square>();
	private int currentIndexSquare = 0;
	private List<Square> squaresToSteps;

	private void Start ()
	{
		squares = new List<Square> ();
		foreach(Square square in squaresContainer.GetComponentsInChildren<Square>())
			squares.Add(square);
		dice.Throw ();
	}

	private void Update()
	{
		dice.Position (chracter.Position + (Vector3.up *2));
		if(squaresToSteps != null && squaresToSteps.Count > 0)
		{
			chracter.MoveTo( squaresToSteps[0].transform );
			float distance = Vector3.Distance(chracter.Position,squaresToSteps[0].transform.position);
	
			if(distance < 1.6F)
				squaresToSteps.RemoveAt(0);
		}

	}

	private void OnGUI ()
	{
		if(GUI.Button(new Rect(0F,0F,150F,25F),"Throw Dice"))
			dice.Throw ();

		if(GUI.Button(new Rect(0F,50F,150F,25F),"Stop Dice"))
		{
			dice.Stop ();
			squaresToSteps = squares.GetRange(currentIndexSquare,dice.Value);
			currentIndexSquare+= dice.Value;
		}
	}


}