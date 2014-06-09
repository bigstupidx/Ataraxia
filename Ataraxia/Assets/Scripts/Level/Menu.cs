using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour 
{
	public Level level;
	public UIDialogMessage dialogMessage;
	[SerializeField]
	private List<Character> characters;

	public static Menu Instance
	{
		get;
		private set;
	}

	public Character GetCharacterByType (CharacterType type)
	{
		foreach(Character character in characters)
		{
			if(character.characterType == type)
				return character;
		}
		return null;
	}

	private void Awake ()
	{
		if(Instance == null)
			Instance = this;
	}
}