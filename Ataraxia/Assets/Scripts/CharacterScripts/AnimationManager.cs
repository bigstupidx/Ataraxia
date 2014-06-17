using UnityEngine;
using System.Collections;

public class AnimationManager 
{
	public const string IDLE = "Idle";
	public const string CELEBRATION = "Celebration";
	public const string COUNT = "Couting";
	public const string JUMP_DICE = "Jump_Dice";
	public const string LOSE = "Lose";
	public const string RUN = "Run";
	public const string SPRINT = "Sprint";
	public const string WALK = "Walk";
	private Animation animation;

	public AnimationManager ( Animation animation)
	{
		this.animation = animation;
	}

	public Animation Play (string animationName)
	{
		Debug.Log (animationName + " : " + animation.IsPlaying(animationName));
		if(!animation.IsPlaying(animationName))
			animation.Play(animationName);

		return animation;
	}
}