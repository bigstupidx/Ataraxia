using UnityEngine;
using System.Collections;

public class SquareMoveBackwards : ISquare
{
	private int backwardStep;
	private Square square;
	public SquareMoveBackwards ( int backwardStep , Square square)
	{
		this.backwardStep = backwardStep;
		this.square = square;
	}

	public void Execute ()
	{
		Board.Instance.GoBackward (this.backwardStep, square);
	}
}