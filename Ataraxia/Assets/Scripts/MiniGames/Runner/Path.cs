using UnityEngine;
using System.Collections;

public enum DirectionToRotate
{
	Left = 0,
	Right = 1,
	None = 3
}
public class Path : MonoBehaviour 
{
	[SerializeField]
	private Transform initialPoint;
	[SerializeField]
	private Transform endPoint;
	public DirectionToRotate nextDirection = DirectionToRotate.Left;

	public Vector3 InitialPoint
	{
		get{ return initialPoint.position;}
	}

	public Vector3 EndPoint
	{
		get{ return endPoint.position;}
	}
}