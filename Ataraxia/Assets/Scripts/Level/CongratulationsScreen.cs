using UnityEngine;
using System.Collections;

public class CongratulationsScreen : MonoBehaviour 
{
	[SerializeField]
	private UIButton buttonReset;

	private void Start ()
	{
		buttonReset.SetInputDelegate (ResetGame);
	}

	private void ResetGame (ref POINTER_INFO ptr)
	{
		if(ptr.evt == POINTER_INFO.INPUT_EVENT.TAP)
		{
			PlayerPrefs.DeleteAll ();
			LevelLoader.Instance.LoadScene (LevelLoader.MENU);
		}
	}
}