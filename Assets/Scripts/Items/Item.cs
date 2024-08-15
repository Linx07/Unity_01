using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public abstract class Item : MonoBehaviour
{
    public Transform parentPosition;
    public RaycastSystem raycastSystem;

    private void Start()
    {
        if (raycastSystem.heldItem != gameObject)
        {
            gameObject.GetComponent<Item>().enabled = false;
        }
    }
}
