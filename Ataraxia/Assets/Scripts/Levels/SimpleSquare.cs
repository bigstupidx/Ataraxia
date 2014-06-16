using UnityEngine;
using System.Collections;

public class SimpleSquare : ISquare
{
	public void Execute ()
	{
		Board.Instance.LoadMiniGame ();
	}
}


