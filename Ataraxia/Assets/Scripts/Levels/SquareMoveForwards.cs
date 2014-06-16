using UnityEngine;
using System.Collections;

public class SquareMoveForwards : ISquare
{
	private int forwardSteps;
	public SquareMoveForwards (int forwardSteps)
	{
		this.forwardSteps = forwardSteps;
	} 

	public void Execute ()
	{
		Board.Instance.GoForward ( this.forwardSteps );
	}
}