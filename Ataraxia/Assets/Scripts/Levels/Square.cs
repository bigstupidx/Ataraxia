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

	public void Execute ()
	{
		Debug.Log(squareType);
	}
}