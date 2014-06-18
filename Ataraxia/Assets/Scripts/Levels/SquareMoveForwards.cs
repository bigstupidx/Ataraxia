using UnityEngine;
using System.Collections;

public class SquareMoveForwards : ISquare
{
	private int forwardSteps;
	private Square square;
	public SquareMoveForwards (int forwardSteps,Square square)
	{
		this.forwardSteps = forwardSteps;
		this.square = square;
	} 

	public void Execute ()
	{
		Board.Instance.GoForward ( this.square,this.forwardSteps );
	}
}