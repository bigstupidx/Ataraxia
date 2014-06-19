using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour 
{
	[SerializeField]
	private bool canRotate = false;
	[SerializeField]
	private Transform myTransform;
	[SerializeField]
	private float delayToChangeRotation  = 0.5F;
	[SerializeField]
	private float velocity = 10F;
	[SerializeField]
	private Vector3 [] diceValue;
	private float timeToChangeDirection;
	private Vector3 directionPoint = Vector3.one;
	private Quaternion currentRotation = new Quaternion ();
	private Vector3 initialScale;
	private GameState gameState;

	public int Value
	{
		get;
		private set;
	}

	public void Position ( Vector3 position)
	{
		myTransform.position = position;
	}

	public void UpdateGameState (GameState gameState)
	{
		this.gameState = gameState;
	}

	public void Throw ()
	{
		canRotate = true;
	}

	public void Hide ()
	{
		myTransform.localScale = Vector3.zero;
	}

	public void Show ()
	{
		myTransform.localScale = initialScale;
	}

	public void Stop ()
	{
		canRotate = false;
		Value = Random.Range(1,6);
		currentRotation.eulerAngles = diceValue [ Value - 1];
	}

	private void Start ()
	{
		initialScale = myTransform.localScale;
		GetNewDirectionPoint ();
	}

	private void Update () 
	{
		CheckVisibility ();

		if (canRotate)
			Rotate ();
		else
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,currentRotation,Time.deltaTime * velocity);
	}

	private void CheckVisibility ()
	{
		if(gameState == GameState.StartingTurn)
			this.Show ();
		else
			this.Hide ();
	}

	private void Rotate ()
	{
		Vector3 direction = GetAxisDirection ();
		myTransform.Rotate (velocity * direction.x, velocity * direction.y, velocity * direction.z);
	}

	private Vector3 GetAxisDirection ()
	{
		if(Time.realtimeSinceStartup > timeToChangeDirection)
			GetNewDirectionPoint ();
		return directionPoint;
	}

	private void GetNewDirectionPoint ()
	{
		directionPoint = new Vector3 (GetValueToDirectionPoint (), GetValueToDirectionPoint (), GetValueToDirectionPoint ());
		timeToChangeDirection = Time.realtimeSinceStartup + delayToChangeRotation;
	}

	private float GetValueToDirectionPoint ()
	{
		float number = Random.value;
		if(number > 0.5F) return 1.0F;
		return -1.0F;
	}
}