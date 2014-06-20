using UnityEngine;
using System.Collections;

public abstract class MiniGameManagerBase : MonoBehaviour 
{
	[SerializeField]
	protected Character character;
	[SerializeField]
	protected UIMessageDescriptor initialExplaining;
	[SerializeField]
	protected UIMessageDescriptor gameExplaining;
	[SerializeField]
	protected UIMessageDescriptor winMessage;
	[SerializeField]
	protected UIMessageDescriptor loseMessage;

	protected abstract bool HasWonGame ();

	private void Start ()
	{
		StartExplaining ();
	}

	protected void StartExplaining ()
	{
		UIMessage.Instance.Show(this.initialExplaining);
		UIMessage.Instance.OnAccepted = ExplainingRules;
	}
	
	protected void ExplainingRules ()
	{
		UIMessage.Instance.Show(this.gameExplaining);
		UIMessage.Instance.OnAccepted = StartGame;
	}

	protected void ShowCelebration ()
	{
		UIMessage.Instance.Show(this.winMessage);
		UIMessage.Instance.OnAccepted = LoadBoard;
		character.StartCelebration ();
	}
	
	protected void ShowFailed ()
	{
		UIMessage.Instance.Show(this.loseMessage);
		UIMessage.Instance.OnAccepted = LoadBoard;
		character.StartLose ();
	}
#if UNITY_EDITOR
	protected void OnGUI ()
	{
		if (GUI.Button (new Rect (0F, 0F, 125F, 25F), "Ganar")) 
		{
			MiniGameState miniGameState = MiniGameState.Won;
			BoardData.Instance.FinishMiniGame (miniGameState);
			LevelLoader.Instance.LoadScene(LevelLoader.LEVEL_1);
		}

		if (GUI.Button (new Rect (0F, 30F, 125F, 25F), "Perder")) 
		{
			MiniGameState miniGameState = MiniGameState.Lost;
			BoardData.Instance.FinishMiniGame (miniGameState);
			LevelLoader.Instance.LoadScene(LevelLoader.LEVEL_1);
		}
	}
#endif
	protected abstract void StartGame ();

	protected virtual void LoadBoard ()
	{
		MiniGameState miniGameState = HasWonGame () ? MiniGameState.Won : MiniGameState.Lost;
		BoardData.Instance.FinishMiniGame (miniGameState);
		LevelLoader.Instance.LoadScene(LevelLoader.LEVEL_1);
	}
}