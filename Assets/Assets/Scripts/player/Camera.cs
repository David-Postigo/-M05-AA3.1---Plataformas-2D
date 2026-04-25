using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -10);

    public float smoothTime = 0.2f;

    [Header("Vertical Dead Zone")]
    public float verticalThreshold = 2f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        float currentY = transform.position.y;
        float targetY = currentY;

        float desiredY = target.position.y + offset.y;

        // postive Height check
        if (desiredY > currentY + verticalThreshold)
        {
            targetY = desiredY - verticalThreshold;
        }
        // negative Height check
        else if (desiredY < currentY - verticalThreshold)
        {
            targetY = desiredY + verticalThreshold;
        }

        Vector3 targetPosition = new Vector3(
            target.position.x + offset.x,
            targetY,
            offset.z
        );

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            smoothTime
        );
    }
}