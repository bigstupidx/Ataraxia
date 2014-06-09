using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour 
{
	public bool IsEnabled
	{
		get;
		set;
	}

	private void Awake ()
	{
		IsEnabled =  true;
	}

	private void OnMouseDown ()
	{
		if(IsEnabled)
		{
			UIMessage.Instance.Show(UIMessage.Instance.doYouWannaGoToLevel);
			UIMessage.Instance.OnAccepted = GoToCurrentLevel;
		}
	}

	private void GoToCurrentLevel ()
	{
		if( Menu.Instance.level == Level.Level1 )
			LevelLoader.Instance.LoadScene(LevelLoader.LEVEL_1);
	}
}
