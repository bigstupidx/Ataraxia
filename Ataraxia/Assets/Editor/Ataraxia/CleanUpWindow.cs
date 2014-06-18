using UnityEngine;  
using UnityEditor;  
using System.Collections;  
using System.Collections.Generic;  

public class CleanUpWindow : EditorWindow  
{  
	[MenuItem("Window/CleanUpWindow")]
	static void Init()
	{ 
		EditorWindow.GetWindow(typeof(CleanUpWindow));
	}
	
	void OnGUI()
	{ 
		if(GUILayout.Button("Clear PlayerPrefs"))
			PlayerPrefs.DeleteAll ();
	}  
}