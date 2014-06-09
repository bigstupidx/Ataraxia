using UnityEngine;
using System.Collections;

public class DialogThumbnail : MonoBehaviour 
{
	public SpeakerPosition speakerPostion;
	[SerializeField]
	private UIPanel panel;
	[SerializeField]
	private SimpleSprite thumbnail;
	[SerializeField]
	private AtaraxiaText speakerName;

	public void Show (DialogDescriptor message,Texture2D texture)
	{
		SetTexture (texture);
		speakerName.Text = message.character.ToString ();
		panel.BringIn ();
		DoMirror (message);
	}

	private void DoMirror (DialogDescriptor message)
	{
		if(message.speakerPosition == SpeakerPosition.Left)
			thumbnail.transform.localScale = new Vector3 (-1F,1F,1F);
	}

	public void Hide ()
	{
		panel.Dismiss ();
	}

	private void SetTexture (Texture2D texture)
	{
		thumbnail.SetTexture (texture);
		thumbnail.UpdateUVs ();
	}
}