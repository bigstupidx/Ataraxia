using UnityEngine;
using System.Collections;

public class PlantMiniGame : MiniGameManagerBase , IMiniGame
{
	[SerializeField]
	private Character character;
	[SerializeField]
	private GameObject containerGame;
	[SerializeField]
	private Timer timer;
	[SerializeField]
	private PlantsManager plantsManager;
	private bool isStartGame = false;

	private void Start ()
	{
		StartExplaining ();
	}

	public void StartExplaining ()
	{
		UIMessage.Instance.Show(this.initialExplaining);
		UIMessage.Instance.OnAccepted = ExplainingRules;
	}

	public void ExplainingRules ()
	{
		UIMessage.Instance.Show(this.gameExplaining);
		UIMessage.Instance.OnAccepted = StartPlaying;
	}

	public void StartPlaying ()
	{
		containerGame.SetActive(true);
		timer.StartTimer ();
		isStartGame = true;
	}

	public void GameIsOver ()
	{
		if(plantsManager.HasWonGame)
			Invoke(Helpers.NameOf( ShowCelebration),1.5F);
		else
			Invoke(Helpers.NameOf( ShowFailed),1.5F);
		containerGame.SetActive (false);
	}

	private void ShowCelebration ()
	{
		UIMessage.Instance.Show(this.winMessage);
		UIMessage.Instance.OnAccepted = LoadBoard;
		character.StartCelebration ();
	}

	private void ShowFailed ()
	{
		UIMessage.Instance.Show(this.loseMessage);
		UIMessage.Instance.OnAccepted = LoadBoard;
		character.StartLose ();
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