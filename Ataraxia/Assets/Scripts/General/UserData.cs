using UnityEngine;
using System.Collections;

public class UserData
{
	public const string SCENE = "Scenes_";
	public static bool HasDialogTypeFinished (SceneDialogType type)
	{
		int hasViewed = PlayerPrefs.GetInt(SCENE + type,0);
		return hasViewed != 0;
	}

	public static void SetDialogTypeFinished (SceneDialogType type)
	{
		PlayerPrefs.SetInt(SCENE + type,1);
	}

	public static void ClearDialog (SceneDialogType type)
	{
		PlayerPrefs.DeleteKey(SCENE + type);
	}
}	