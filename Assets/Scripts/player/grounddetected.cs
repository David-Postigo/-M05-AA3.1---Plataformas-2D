using System.Collections.Generic;
using UnityEngine;

public class grounddetected : MonoBehaviour
{
    public bool isgrounded;
    public float distance;
    public LayerMask layerMask;
    public Vector3 offset;
    public float radius;
    PlayerMovement test;
    private void Start()
    {
        test = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        Debug.DrawRay(transform.position + offset, Vector3.down * distance, Color.red);

        //RaycastHit2D hit = Physics2D.Raycast(transform.position + offset, Vector2.down, distance, layerMask);
        RaycastHit2D hit = Physics2D.CircleCast(transform.position + offset, radius, Vector2.down, distance, layerMask);

        if (hit.collider == null )
        {
            isgrounded = false;
        }
        else
        {
            isgrounded = true;
            test.candash = true;
            test.dashToggle.isOn = true;
            Debug.DrawRay(transform.position + offset, Vector3.down * hit.distance, Color.green);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = isgrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position + offset, radius);
        Gizmos.DrawWireSphere(transform.position + Vector3.down * distance, radius);
    }
}
