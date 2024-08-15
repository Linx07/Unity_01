using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform cameraPosition;

    private void LateUpdate()
    {
        transform.position = cameraPosition.position;
    }
}
