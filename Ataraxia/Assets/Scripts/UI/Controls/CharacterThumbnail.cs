using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class UIMessageDescriptor
{
	public string message;
	public bool isButtonCancelVisible = true;
}

public enum SpeakerPosition
{
	Left = 0,
	Right = 1,
	None = 2
}

[Serializable]
public class CharacterThumbnail
{
	public CharacterType character;
	public Texture2D thumbnail;
}

[Serializable]
public class DialogDescriptor : UIMessageDescriptor
{
	public SpeakerPosition speakerPosition;
	public CharacterType character;
}