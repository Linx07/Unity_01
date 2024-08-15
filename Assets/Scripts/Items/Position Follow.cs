using UnityEngine;

public class PositionFollow : MonoBehaviour
{
    public Transform cameraTransform;
    public float followSpeed;

    private void LateUpdate()
    {
        transform.position = cameraTransform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraTransform.rotation, followSpeed * Time.deltaTime);
    }
}
