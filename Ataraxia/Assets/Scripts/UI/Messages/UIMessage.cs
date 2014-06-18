using System;
using UnityEngine;
using System.Collections;

public class UIMessage : UIMessageBase , IUIMessage
{
	[SerializeField]
	private UIButton acceptButton;
	[SerializeField]
	private UIButton cancelButton;
	[SerializeField]
	private UIMessageDescriptor defaultMessage;
	public UIMessageDescriptor doYouWannaGoToLevel;

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
		acceptButton.AddInputDelegate (Close);
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
		}
	}

	public override void Show (UIMessageDescriptor message)
	{
		base.Show(message);
		if(!message.isButtonCancelVisible)
			SetOnlyButtonAccept ();
	}

	private void SetOnlyButtonAccept ()
	{
		cancelButton.transform.localScale = Vector3.zero;
		acceptButton.transform.localPosition = new Vector3 (0.0f, 30f, 0.9f);
	}

	public override void Hide ()
	{
		base.Hide ();
		ResetButtonAccept ();
	}

	private void ResetButtonAccept ()
	{
		cancelButton.transform.localScale = Vector3.one;
		acceptButton.transform.localPosition = new Vector3 (-135f, 30f, 0.9f);;
	}
}