using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    void Start()
    {
        Physics.IgnoreLayerCollision(3, 6);
    }
}
