using UnityEngine;
using System.Collections;

public class MiniGameManagerBase : MonoBehaviour 
{
	[SerializeField]
	protected UIMessageDescriptor initialExplaining;
	[SerializeField]
	protected UIMessageDescriptor gameExplaining;
	[SerializeField]
	protected UIMessageDescriptor winMessage;
	[SerializeField]
	protected UIMessageDescriptor loseMessage;

	protected void LoadBoard ()
	{
		LevelLoader.Instance.LoadScene(LevelLoader.LEVEL_1);
	}
}