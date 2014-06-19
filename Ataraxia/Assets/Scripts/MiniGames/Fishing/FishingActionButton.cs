using UnityEngine;
using System.Collections;

public class FishingActionButton : MonoBehaviour 
{
	[SerializeField]
	private FishingMiniGame fishingManager;
	[SerializeField]
	private UIButton buttonAction;
	[SerializeField]
	private SimpleSprite alert;
	[SerializeField]
	private AtaraxiaText counter;

	private void Start ()
	{
		alert.Hide (true);
		buttonAction.SetInputDelegate(Catch);
	}

	private void Update ()
	{
		alert.Hide ( !fishingManager.CanFishing );
	}

	private void Catch (ref POINTER_INFO ptr)
	{
		if(ptr.evt == POINTER_INFO.INPUT_EVENT.PRESS || ptr.evt == POINTER_INFO.INPUT_EVENT.TAP)
		{
			fishingManager.Catch ();
			counter.Text = fishingManager.ItemsCatched.ToString ();
		}
	}
}