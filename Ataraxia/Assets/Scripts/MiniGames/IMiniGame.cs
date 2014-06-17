using UnityEngine;
using System.Collections;

public interface IMiniGame
{
	void StartExplaining ();
	void ExplainingRules ();
	void StartPlaying ();
	void GameIsOver ();
}
