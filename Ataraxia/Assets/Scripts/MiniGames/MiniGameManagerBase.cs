using UnityEngine;
using System.Collections;

public abstract class MiniGameManagerBase : MonoBehaviour 
{
	[SerializeField]
	protected UIMessageDescriptor initialExplaining;
	[SerializeField]
	protected UIMessageDescriptor gameExplaining;
	[SerializeField]
	protected UIMessageDescriptor winMessage;
	[SerializeField]
	protected UIMessageDescriptor loseMessage;

	protected abstract bool HasWonGame ();

	protected void LoadBoard ()
	{
		MiniGameState miniGameState = HasWonGame () ? MiniGameState.Won : MiniGameState.Lost;
		BoardData.Instance.FinishMiniGame (miniGameState);
		LevelLoader.Instance.LoadScene(LevelLoader.LEVEL_1);
	}
}