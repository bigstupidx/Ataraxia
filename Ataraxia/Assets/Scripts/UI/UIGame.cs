using UnityEngine;
using System.Collections;

public class UIGame : MonoBehaviour
{
	[SerializeField]
	private UIDialogMessage dialog;

	public static UIGame Instance;
	public UIDialogMessage UIDialogMessage
	{
		get{ return dialog;}
	}

	private void Awake ()
	{
		if(Instance == null)
			Instance = this;
	}
}