using UnityEngine;
using System.Collections;

public class TakeTheDice : TakeScene
{
	[SerializeField]
	private GameObject prefabDice;
	[SerializeField]
	private Transform startPoint;
	[SerializeField]
	private Transform endPoint;
	private Transform dice;
	private bool canFinish;

	public override void StartScene (System.Action endCallback, CameraManager cameraManager)
	{
		Character characterOldMan = Menu.Instance.GetCharacterByType (CharacterType.GranSabio);
		Character ataraxia = Menu.Instance.GetCharacterByType (CharacterType.Ataraxia);
		startPoint = characterOldMan.transform;
		endPoint = ataraxia.transform;
		base.StartScene (endCallback, cameraManager);
		GameObject prefabDiceGO = Instantiate (prefabDice,startPoint.position + Vector3.up,Quaternion.identity) as GameObject;
		dice = prefabDiceGO.transform;
		StartDialog ();
	}

	private void Update ()
	{
		if(dice == null)
			return;
		Vector3 end = endPoint.position - (Vector3.up/2);
		Vector3 newPos = end - dice.position;
		newPos.Normalize ();

		if( (dice.position - endPoint.position).sqrMagnitude > 1F)
			dice.Translate(newPos * Time.deltaTime * 5.0F);

		else if(!canFinish)
		{
			canFinish = true;
			Invoke(Helpers.NameOf(EndTake),1F);
		}
	}

	protected override void EndTake ()
	{
		Destroy (dice.gameObject);
		base.EndTake ();
	}

	protected override void StartDialog ()
	{
		Menu.Instance.dialogMessage.Show(dialog,null);
	}
}
