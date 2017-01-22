using UnityEngine;
using System.Collections;

public class CameraShaking : MonoBehaviour
{
    private Camera cam; // set this via inspector
    [HideInInspector]
    public float shakeTime;
    [HideInInspector]
    public float shakeAmount;
    private float decreaseFactor;

    void Start()
    {
        cam = Camera.main;
        decreaseFactor = 1;
    }

    void Update()
    {
        if (!GameManager.Instance.isGameOver)
        {
            if (shakeTime > 0)
            {
                cam.transform.localPosition = new Vector3(cam.transform.localPosition.x + Random.insideUnitCircle.x * shakeAmount,
                                                            cam.transform.localPosition.y + Random.insideUnitCircle.y * shakeAmount,
                                                            cam.transform.localPosition.z);
                shakeTime -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeTime = 0.0f;
            }
        }
    }

    public void Shake(float shakeAmount, float shakeTime)
    {
        this.shakeAmount = shakeAmount;
        this.shakeTime = shakeTime;
    }
}
