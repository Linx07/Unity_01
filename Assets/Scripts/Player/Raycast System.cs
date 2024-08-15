using UnityEngine;

public class RaycastSystem : MonoBehaviour
{
    public Transform rayPosition;
    public LayerMask ignoredLayers;

    private bool equipped;
    private RaycastHit hit;
    public GameObject heldItem;
    private Item itemComponent;

    private void Update()
    {
        HandleEquipped();
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(rayPosition.position, rayPosition.forward, out hit, 3, ~ignoredLayers))
        {
            if (hit.collider.gameObject.GetComponent<Item>() != null && !equipped && hit.collider.gameObject.GetComponent<Purchasable>() == null)
            {
                PickUp(hit.collider.gameObject);
            }
            else if (hit.collider.gameObject.GetComponent<ItemCounerInteractable>() != null)
            {
                hit.collider.gameObject.GetComponent<ItemCounerInteractable>().DoAction(transform.gameObject);
            }
            else if (hit.collider.gameObject.GetComponent<Purchasable>() && heldItem == null)
            {
                if (transform.GetComponent<Wallet>().Payment(hit.collider.gameObject.GetComponent<Purchasable>().price))
                {
                    Instantiate(hit.collider.gameObject);
                    Destroy(hit.collider.gameObject.GetComponent<Purchasable>());
                    PickUp(hit.collider.gameObject);
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.G) && equipped)
        {
            Drop();
        }
    }

    private void PickUp(GameObject heldItem)
    {
        this.heldItem = heldItem;
        itemComponent = heldItem.GetComponent<Item>();
        itemComponent.enabled = true;

        heldItem.transform.SetParent(itemComponent.parentPosition);
        heldItem.transform.localPosition = Vector3.zero;
        heldItem.transform.localRotation = Quaternion.identity;
        heldItem.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Drop()
    {
        itemComponent.enabled = false;
        heldItem.transform.SetParent(null);
        heldItem.GetComponent<Rigidbody>().isKinematic = false;
        heldItem = null;
    }

    private void HandleEquipped()
    {
        if (heldItem != null)
        {
            equipped = true;
        }
        else
        {
            equipped = false;
        }
    }
}