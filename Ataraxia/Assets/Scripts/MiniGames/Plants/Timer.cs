using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	[SerializeField]
	private AtaraxiaText label;
	[SerializeField]
	private float totalTime = 59.0F;
	private float currentTime = 0.0F;
	private float descountTime = 1.0F;
	private float storedTime = 0.0F;

	public bool IsTimeOver
	{
		get{ return currentTime <= 0.0F;}
	}

	public void StartTimer ()
	{
		currentTime = totalTime;
		CreateDelay ();
	}

	private void CreateDelay ()
	{
		storedTime = Time.realtimeSinceStartup + descountTime;
	}

	private void Update ()
	{
		if(IsTimeOver)
			return;

		if(Time.realtimeSinceStartup > storedTime)
		{
			currentTime-=descountTime;
			CreateDelay ();
			label.Text = currentTime.ToString ();
		}

		if(currentTime == 0)
			label.text = string.Empty;
	}
}