using UnityEngine;
using System.Collections;

public class RunnerMiniGame : MiniGameManagerBase , IMiniGame
{
	protected override bool HasWonGame ()
	{
		return false;
	}

	protected override void StartGame ()
	{
		StartPlaying ();
	}


	public void StartPlaying ()
	{

	}

	public void GameIsOver ()
	{

	}
}