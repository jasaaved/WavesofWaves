using UnityEngine;
using UnityEngine.UI;

public class ButtonStartSelecter : MonoBehaviour
{
	void OnEnable ()
    {
        GetComponentInChildren<Selectable>().Select();
	}
}
