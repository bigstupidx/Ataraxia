using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
	public const string MENU = "Main Room";
	public const string MENU2 = "Main Room Portal 1 Cleared";
	public const string LEVEL_1 = "Portal 1 - Love";
	private const string LOADING_SCREEN = "LoadingScreen";
	private string currentScene;
	private string PendingScene
	{
		get;
		set;
	}

	public static LevelLoader Instance
	{
		get;
		private set;
	}
	
	private void Awake()
	{
		if(Instance == null)
		{
			if(Application.isEditor && string.IsNullOrEmpty (PendingScene))
				PendingScene = MENU;
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
			Destroy(this.gameObject);
	}

	public bool IsMainRoomScene
	{
		get{ return currentScene == MENU || currentScene == MENU2; }
	}
	
	public void LoadPendingScene()
	{
		StartCoroutine (LoadLevelAsync());
	}
	
	private IEnumerator LoadLevelAsync()
	{	
		System.GC.Collect ();
		System.GC.WaitForPendingFinalizers ();
		yield return Resources.UnloadUnusedAssets();
		yield return Application.LoadLevelAsync (this.PendingScene);
	}

	private void Update ()
	{
		if(PendingScene != string.Empty && PendingScene != currentScene)
			currentScene = Application.loadedLevelName ;
	}

	public void LoadScene(string levelName)
	{
		PendingScene = levelName;
		Application.LoadLevelAsync (LOADING_SCREEN);
	}
}