using UnityEngine;

public class moviingplatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float speed = 2f;

    private Vector3 target;
    private bool goingToB = true;

    private void Start()
    {
        target = pointB.position;
    }

    private void Update()
    {
        // FIX: force target to stay in same Z plane
        target.z = transform.position.z;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        // FIX: keep platform in 2D camera plane
        Vector3 pos = transform.position;
        pos.z = transform.position.z;
        transform.position = pos;

        // upon reaching the zone switch places
        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            goingToB = !goingToB;
            target = goingToB ? pointB.position : pointA.position;
        }
    }
}