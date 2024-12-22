using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{
    // Object the camera will look at (e.g., the car)
    [SerializeField] private Transform lookAtTarget;

    // Object the camera will move toward (e.g., a point behind the car)
    [SerializeField] private Transform moveToTarget;

    // How fast the camera moves toward the moveToTarget position
    [SerializeField] private float moveSpeed = 2f;

    // How fast the camera rotates to look at the lookAtTarget
    [SerializeField] private float rotateSpeed = 5f;

    // Offset to adjust the look target position
    [SerializeField] private Vector3 lookAtOffset = new Vector3(0, 2, 0); // Example: Offset upwards by 2 units

    private void LateUpdate()
    {
        // Ensure both targets are assigned
        if (lookAtTarget == null || moveToTarget == null)
            return;

        // Smoothly move the camera toward the moveToTarget's position
        transform.position = Vector3.Lerp(transform.position, moveToTarget.position, moveSpeed * Time.deltaTime);

        // Calculate the offset lookAt position
        Vector3 adjustedLookAtPosition = lookAtTarget.position + lookAtOffset;

        // Smoothly rotate the camera to look at the adjusted position
        Quaternion targetRotation = Quaternion.LookRotation(adjustedLookAtPosition - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
}
