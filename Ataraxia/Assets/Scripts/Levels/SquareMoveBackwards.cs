using UnityEngine;
using System.Collections;

public class SquareMoveBackwards : ISquare
{
	private int backwardStep;
	public SquareMoveBackwards ( int backwardStep)
	{
		this.backwardStep = backwardStep;
	}

	public void Execute ()
	{
		Board.Instance.GoBackward (this.backwardStep);
	}
}