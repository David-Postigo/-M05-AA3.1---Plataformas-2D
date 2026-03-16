using UnityEngine;

public class grounddetected : MonoBehaviour
{
    public bool isgrounded;
    public float distance;
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
    }
}
