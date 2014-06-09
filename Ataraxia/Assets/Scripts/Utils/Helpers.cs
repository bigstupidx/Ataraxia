using UnityEngine;
using System.Collections;

public class Helpers
{
	public static string NameOf(System.Action callback)
	{
		return callback.Method.Name;
	}
}