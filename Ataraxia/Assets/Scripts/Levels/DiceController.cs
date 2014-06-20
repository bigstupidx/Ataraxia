using UnityEngine;
using System.Collections;

public class DiceController : MonoBehaviour 
{
	[SerializeField]
	private Dice dice;
	[SerializeField]
	private UIButton buttonSetDice;
	private Transform myTransform;

	private void Start ()
	{
		myTransform = transform;
		buttonSetDice.AddInputDelegate ( StopDice );
	}

	private void StopDice (ref POINTER_INFO ptr)
	{
		if( ptr.evt == POINTER_INFO.INPUT_EVENT.TAP && !Board.Instance.IsSpecialEvent)
			MoveCharacter ();
	}

	private void Update ()
	{
		if(Board.Instance.GameState == GameState.StartingTurn)
			myTransform.localScale = Vector3.one;
		else
			myTransform.localScale = Vector3.zero;
	}

	private void MoveCharacter ()
	{
		dice.Stop ();
		Board.Instance.StartMovingCharacter ();
	}
}