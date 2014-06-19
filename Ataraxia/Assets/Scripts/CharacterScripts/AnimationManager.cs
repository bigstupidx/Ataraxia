using UnityEngine;
using System.Collections;

public class AnimationManager 
{
	public const string IDLE = "Idle";
	public const string CELEBRATION = "Celebration";
	public const string COUNT = "Counting";
	public const string JUMP_DICE = "Jump_Dice";
	public const string LOSE = "Lose";
	public const string RUN = "Run";
	public const string SPRINT = "Sprint";
	public const string WALK = "Walk";
	public const string FISHING = "Fishing_Idle";
	public const string CATCH = "Fishing_Catch";
	public const string WATERING = "Watering";


	private Animation animation;

	public AnimationManager ( Animation animation)
	{
		this.animation = animation;
	}

	public bool IsPlaying (string animationName)
	{
		return animation.IsPlaying(animationName);
	}

	public Animation Play (string animationName)
	{
		if(!animation.IsPlaying(animationName) && animation.GetClip(animationName) != null)
			animation.Play(animationName);

		return animation;
	}
}