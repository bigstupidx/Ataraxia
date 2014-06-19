using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishingMiniGame : MiniGameManagerBase , IMiniGame 
{
	[SerializeField]
	private Timer timer;
	[SerializeField]
	private int minItemsToCatch;
	[SerializeField]
	private GetCollision areaToFishing;
	[SerializeField]
	private GetCollision endPoint;
	[SerializeField]
	private Transform poolItems;
	[SerializeField]
	private Transform itemsContainer;
	private List<Transform> items;
	private Transform itemCatched;
	private int itemsCatched;
	private bool isStartGame;

	public int ItemsCatched
	{
		get{ return itemsCatched;}
	}
	public bool CanFishing
	{
		get{ return areaToFishing.CurrentItemCollisioning != null && !timer.IsTimeOver && isStartGame;}
	}
	

	protected override bool HasWonGame ()
	{
		return itemsCatched >= itemsCatched;
	}

	protected override void StartGame ()
	{
		items = new List<Transform> ();
		foreach(Transform item in poolItems.GetComponentsInChildren<Transform> ())
			items.Add (item);
		StartPlaying ();
	}

	public void StartPlaying ()
	{
		timer.StartTimer ();
		isStartGame = true;
	}

	public void Catch ()
	{
		if(CanFishing && character.IsWaitingToCatch)
		{
			character.Catch ();
			areaToFishing.Catched ();
			itemsCatched++;
			Invoke( Helpers.NameOf(PutItemCatched), 1.5F );
		}
	}

	private void PutItemCatched ()
	{
		int itemRandom = Random.Range(0,items.Count);
		itemCatched = items[itemRandom];
		itemCatched.parent = itemsContainer;
		itemCatched.localPosition = Vector3.zero;
		items.RemoveAt(itemRandom);
	}
	
	private void Update ()
	{
		if(endPoint.CurrentItemCollisioning != null)
			endPoint.CurrentItemCollisioning.RestartPosition ();

		if(timer.IsTimeOver && isStartGame)
		{
			isStartGame = false;
			GameIsOver ();
		}
	}

	public void GameIsOver ()
	{
		if(HasWonGame ())
			Invoke(Helpers.NameOf( ShowCelebration),1.5F);
		else
			Invoke(Helpers.NameOf( ShowFailed),1.5F);
	}
}
