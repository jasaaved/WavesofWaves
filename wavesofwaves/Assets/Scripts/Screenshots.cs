using UnityEngine;

public class Screenshots : MonoBehaviour
{
    static int capNum;
	
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.P))
        {
            Application.CaptureScreenshot("Screenshot " + capNum.ToString() + ".png");
            capNum++;
        }
	}
}
