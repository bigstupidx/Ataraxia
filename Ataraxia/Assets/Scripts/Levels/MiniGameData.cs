using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MiniGameState
{
	NotPlayed = 0,
	Won = 1,
	Lost = 2
}

public class MiniGameData : MonoBehaviour
{
	public bool isSpecialLevel;
	public string miniGameName;
	public MiniGameState state = MiniGameState.NotPlayed;
	public UIMessageDescriptor messageReward;
}