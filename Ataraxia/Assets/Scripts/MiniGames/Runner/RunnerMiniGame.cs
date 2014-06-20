using UnityEngine;
using System.Collections;

public class RunnerMiniGame : MiniGameManagerBase , IMiniGame
{
	[SerializeField]
	private RunnerManager runnerManager;
	[SerializeField]
	private CameraFollowerSmooth camera;
	protected override bool HasWonGame ()
	{
		return true;
	}

	protected override void StartGame ()
	{
		StartPlaying ();
		runnerManager.OnFinishRun = GameIsOver;
	}

	public void StartPlaying ()
	{
		runnerManager.StartGame ();
	}

	public void GameIsOver ()
	{
		camera.Stop ();
		Invoke(Helpers.NameOf( ShowCelebration),1.5F);
	}

	protected override void LoadBoard ()
	{
		base.LoadBoard ();
		MiniGameState miniGameState =  MiniGameState.Won;
		BoardData.Instance.FinishMiniGame (miniGameState);
		BoardData.Instance.gameState = GameState.Dialog;
	}
}