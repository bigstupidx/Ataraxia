using UnityEngine;
using System.Collections;

public interface IUIMessage
{
	void Show (UIMessageDescriptor messaage);
	void Hide ();
}