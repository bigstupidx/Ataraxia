using UnityEngine;
using System.Collections;

public class RopeMiniGame : MiniGameManagerBase , IMiniGame
{
	[SerializeField]
	private Transform endPoint;
	private bool startGame;

	protected override void StartGame ()
	{
		startGame = true;
		character.MoveTo(endPoint.position);
	}

	protected override bool HasWonGame ()
	{
		return false;
	}

	public void StartPlaying ()
	{

	}

	public void GameIsOver ()
	{

	}

	public void Update ()
	{

	}
}