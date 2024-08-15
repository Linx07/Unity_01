using UnityEngine;

public class Pistol : Item
{
    public Transform cameraTransform;
    public Transform aimPosition;
    public float aimSpeed;   
    public float shootForce;
    public LayerMask ignoredLayers;

    private RaycastHit hit;
    private Transform targetParent;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetMouseButton(1))
        {
            targetParent = aimPosition;
        }
        else
        {
            targetParent = parentPosition;
        }
        Aim();
    }

    private void Aim()
    {
        transform.position = Vector3.Lerp(transform.position, targetParent.position, Time.deltaTime * aimSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetParent.rotation, Time.deltaTime * aimSpeed);
    }

    private void Shoot()
    {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 100f, ~ignoredLayers))
        {
            Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce((hit.point - cameraTransform.position).normalized * shootForce, ForceMode.Impulse);
            }
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
        }
    }
}
