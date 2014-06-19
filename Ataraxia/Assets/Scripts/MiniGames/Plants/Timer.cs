using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	[SerializeField]
	private bool isDecreaseTime = true;
	[SerializeField]
	private AtaraxiaText label;
	[SerializeField]
	private float totalTime = 59.0F;
	private float currentTime = 0.0F;
	private float descountTime = 1.0F;
	private float storedTime = 0.0F;
	private bool isTimeStart = false;
	public bool IsTimeOver
	{
		get
		{
			if(isDecreaseTime)
				return currentTime <= 0;
			else
				return currentTime >= totalTime;
		}
	}

	public float TotalTime
	{
		get{ return totalTime; }
	}

	public void StartTimer ()
	{
		isTimeStart = true;
		if(isDecreaseTime)
			currentTime = totalTime;
		CreateDelay ();
	}

	public void Stop ()
	{
		if(isDecreaseTime)
			currentTime = 0;
		else
			currentTime = totalTime;
	}

	private void CreateDelay ()
	{
		storedTime = Time.realtimeSinceStartup + descountTime;
	}

	private void Update ()
	{
		if(isTimeStart)
			CountDown ();	
	}

	private void CountDown ()
	{
		if (IsTimeOver) 
		{
			label.Text = string.Empty;
			return;
		}
		else if (Time.realtimeSinceStartup > storedTime) 
		{
			ManageTime ();
			CreateDelay ();
			label.Text = currentTime.ToString ();
		}
	}

	private void ManageTime ()
	{
		if(isDecreaseTime)
			currentTime -= descountTime;
		else 
			currentTime += descountTime;
	}
}