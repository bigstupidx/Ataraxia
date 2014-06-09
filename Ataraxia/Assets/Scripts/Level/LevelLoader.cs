using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
	public const string MENU = "Menu";
	public const string LEVEL_1 = "Portal 1 - Love";
	private const string LOADING_SCREEN = "LoadingScreen";
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
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
			Destroy(this.gameObject);
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
	
	public void LoadScene(string levelName)
	{
		PendingScene = levelName;
		Application.LoadLevelAsync (LOADING_SCREEN);
	}
}