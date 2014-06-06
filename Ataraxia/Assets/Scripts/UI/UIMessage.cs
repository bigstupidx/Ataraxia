using UnityEngine;
using System.Collections;

public class UIMessage : MonoBehaviour 
{
	[SerializeField]
	private UIPanel panel;
	[SerializeField]
	private AtaraxiaText text;
	[SerializeField]
	private UIMessageDescriptor defaultMessage;

	public static UIMessage Instance
	{
		get;
		private set;
	}

	private void Awake ()
	{
		if(Instance == null)
			Instance = this;
	}

	public void Show (UIMessageDescriptor messaage)
	{
		text.Text = messaage.message;
		panel.BringIn ();
	}

	public void Hide ()
	{
		panel.Dismiss ();
	}

	private void OnGUI ()
	{
		if(GUI.Button(new Rect(0F,200F,150F,25F),"Show"))
			UIMessage.Instance.Show (defaultMessage);

		if(GUI.Button(new Rect(0F,250F,150F,25F),"Hide"))
			UIMessage.Instance.Hide ();
	}
}