using UnityEngine;
using System.Collections;

public class PlantMiniGame : MiniGameManagerBase , IMiniGame
{
	[SerializeField]
	private GameObject containerGame;
	[SerializeField]
	private Timer timer;
	[SerializeField]
	private PlantsManager plantsManager;
	private bool isStartGame = false;

	protected override bool HasWonGame ()
	{
		return plantsManager.HasWonGame;
	}

	protected override void StartGame ()
	{
		StartPlaying ();
	}

	public void StartPlaying ()
	{
		containerGame.SetActive(true);
		timer.StartTimer ();
		isStartGame = true;
	}

	public void GameIsOver ()
	{
		if(HasWonGame ())
			Invoke(Helpers.NameOf( ShowCelebration),1.5F);
		else
			Invoke(Helpers.NameOf( ShowFailed),1.5F);
		containerGame.SetActive (false);
	}

	private void Update ()
	{
		if(timer.IsTimeOver && isStartGame)
		{
			isStartGame = false;
			GameIsOver ();
		}
	}
}