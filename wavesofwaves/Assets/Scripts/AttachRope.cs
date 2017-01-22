using UnityEngine;

public class AttachRope : MonoBehaviour
{
    LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Update() //OnEnable()
    {
        Vector3 playerPos = transform.InverseTransformPoint(GameObject.FindGameObjectWithTag("Player").transform.position);
        line.SetPosition(1, playerPos);
    }

    private void OnDisable()
    {

    }
}
