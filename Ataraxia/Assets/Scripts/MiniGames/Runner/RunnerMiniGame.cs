using UnityEngine;
using System.Collections;

public class RunnerMiniGame : MiniGameManagerBase , IMiniGame
{
	[SerializeField]
	private RunnerManager runnerManager;
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
		runnerManager.StartGame ();
	}

	public void GameIsOver ()
	{

	}
}