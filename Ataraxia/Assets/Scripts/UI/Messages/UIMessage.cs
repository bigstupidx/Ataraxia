using System;
using UnityEngine;
using System.Collections;

public class UIMessage : MonoBehaviour , IUIMessage
{
	[SerializeField]
	protected UIPanel panel;
	[SerializeField]
	protected AtaraxiaText text;
	[SerializeField]
	private UIButton acceptButton;
	[SerializeField]
	private UIButton cancelButton;
	[SerializeField]
	private UIMessageDescriptor defaultMessage;
	public UIMessageDescriptor doYouWannaGoToLevel;
	public Action OnAccepted;

	public static UIMessage Instance
	{
		get;
		private set;
	}

	private void Awake ()
	{
		if(Instance == null)
		{
			Instance = this;
			AddButtonsDelegates ();
		}
	}

	private void AddButtonsDelegates ()
	{
		if(acceptButton != null)
			acceptButton.AddInputDelegate (Close);
		if(cancelButton != null)
			cancelButton.AddInputDelegate (Cancel);
	}

	private void Cancel (ref POINTER_INFO ptr)
	{
		if(ptr.evt == POINTER_INFO.INPUT_EVENT.TAP)
			Hide();
	}

	protected void Close (ref POINTER_INFO ptr)
	{
		if(ptr.evt == POINTER_INFO.INPUT_EVENT.TAP)
		{
			Hide();
			if(OnAccepted != null)
				OnAccepted ();
			OnAccepted = null;
		}
	}

	public void Show (UIMessageDescriptor message)
	{
		text.Text = message.message;
		panel.BringIn ();
	}

	public void Hide ()
	{
		panel.Dismiss ();
	}
}