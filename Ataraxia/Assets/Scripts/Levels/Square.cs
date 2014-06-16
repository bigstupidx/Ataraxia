using UnityEngine;
using System.Collections;

public enum SquareType
{
	Simple = 0,
	Special = 1,
	Reward = 2,
	MoveForwards = 3,
	MoveBackwards = 4
}

public class Square : MonoBehaviour 
{
	[SerializeField]
	private SquareType squareType;
	[SerializeField]
	private int reward;
	[SerializeField]
	private int moveSquares;
	private ISquare square;
	private Transform myTransform;

	public Vector3 Position
	{
		get{ return myTransform.position; }
	}

	private void Start ()
	{
		myTransform = transform;
		SetSquare () ;
	}

	private void SetSquare () 
	{
		if(squareType == SquareType.Simple)
			square = new SimpleSquare ();
		else if(squareType == SquareType.Reward)
			square = new RewardSquare ();
		else if( squareType == SquareType.MoveBackwards)
			square = new SquareMoveBackwards (moveSquares);
		else if( squareType == SquareType.MoveForwards)
			square = new SquareMoveForwards (moveSquares);
		else
			square = new SpecialSquare ();
	}

	public void Execute ()
	{
		square.Execute ();
	}
}