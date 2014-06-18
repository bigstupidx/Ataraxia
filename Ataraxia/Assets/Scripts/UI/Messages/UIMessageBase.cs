using UnityEngine;
using System.Collections;
using System;

public abstract class UIMessageBase : MonoBehaviour 
{
	[SerializeField]
	protected UIPanel panel;
	[SerializeField]
	protected AtaraxiaText text;
	public Action OnAccepted;

	protected void Close (ref POINTER_INFO ptr)
	{
		if(ptr.evt == POINTER_INFO.INPUT_EVENT.TAP)
		{
			Hide();
			if(OnAccepted != null)
				OnAccepted ();
		}
	}
	
	public virtual void Show (UIMessageDescriptor message)
	{
		text.Text = message.message;
		panel.BringIn ();
	}

	public virtual void Hide ()
	{
		panel.Dismiss ();
	}
}
