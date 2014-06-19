using UnityEngine;
using System.Collections;

public class HidingMiniGame : MiniGameManagerBase , IMiniGame
{
	[SerializeField]
	private HiddenManager hiddenManager;
	[SerializeField]
	private Timer timer;

	protected override bool HasWonGame ()
	{
		return hiddenManager.HasWon;
	}

	protected override void StartGame ()
	{
		StartPlaying ();
		hiddenManager.Finish = GameIsOver;
	}

	public void StartPlaying ()
	{
		hiddenManager.StartGame ();
	}

	public void GameIsOver ()
	{
		if(HasWonGame ())
			Invoke(Helpers.NameOf( ShowCelebration),1.5F);
		else
			Invoke(Helpers.NameOf( ShowFailed),1.5F);
	}
}