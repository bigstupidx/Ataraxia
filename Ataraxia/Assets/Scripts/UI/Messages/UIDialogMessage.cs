using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIDialogMessage : UIMessageBase,IUIMessage 
{
	[SerializeField]
	private UIButton closeButton;
	[SerializeField]
	private DialogThumbnail [] speakersThumbnails;
	[SerializeField]
	private DialogDescriptor [] messages;
	[SerializeField]
	private List<CharacterThumbnail> thumbnails;

	public void Show ( DialogDescriptor message , Action onClosed)
	{
		ResetThumbnails ();
		ShowThumbnail (message);
		OnAccepted =  onClosed;
		closeButton.AddInputDelegate( Close );
		base.Show(message);
	}

	private void ShowThumbnail (DialogDescriptor message)
	{
		foreach ( DialogThumbnail thumbnail in speakersThumbnails)
		{
			if(thumbnail.speakerPostion == message.speakerPosition)
				thumbnail.Show(message,GetTexture(message.character));
		}
	}
	
	private void ResetThumbnails ()
	{
		foreach ( DialogThumbnail thumbnail in speakersThumbnails)
			thumbnail.Hide ();
	}

	private Texture2D GetTexture (CharacterType character)
	{
		foreach(CharacterThumbnail thumbnail in thumbnails)
		{
			if(thumbnail.character == character)
				return thumbnail.thumbnail;
		}
		return null;
	}
}