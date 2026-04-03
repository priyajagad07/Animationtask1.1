using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.3f;
    public float forwardOffset = 3f;
    public float verticalOffset = 0f;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        float targetX = player.position.x + forwardOffset;
        float targetY = player.position.y + verticalOffset;

        Vector3 targetPos = new Vector3(
            targetX,
            targetY,
            transform.position.z
        );

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPos,
            ref velocity,
            smoothSpeed
        );

    }
}

// transform.position = Vector3.Lerp(
//             transform.position,
//             targetPos,
//             smoothSpeed * Time.deltaTime
//         );