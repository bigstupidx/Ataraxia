using UnityEngine;
using System.Collections;

public class CameraFollowCharacter : MonoBehaviour 
{
	[SerializeField]
	private float distance = 10.0F;
	[SerializeField]
	private Transform target;
	[SerializeField]
	private Transform myTransform;

	private void Update ()
	{
		if(Board.Instance != null && Board.Instance.GameState == GameState.Dialog)
			return;

		myTransform.position = new Vector3(target.position.x, myTransform.position.y, target.position.z - distance);
		myTransform.LookAt(target);
	}
}