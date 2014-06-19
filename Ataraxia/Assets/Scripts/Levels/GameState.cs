using UnityEngine;
using System.Collections;

public enum GameState
{
	StartingTurn = 0,
	MovingTurn = 1,
	EndTurn = 2,
	ExecuteAction = 3,
	GiveRewards = 4,
	Dialog = 5
}