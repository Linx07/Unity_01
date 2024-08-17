using UnityEngine;

public class RaycastSystem : MonoBehaviour
{
    public Transform rayPosition;
    public LayerMask ignoredLayers;
    public RaycastHit hit;
    public GameObject heldItem;

    private Inventory inventory;
    private Wallet wallet;


    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        wallet = GetComponent<Wallet>();
    }

    private void Update()
    {
        HandleRaycastInput();

        if (Input.GetKeyDown(KeyCode.G) && heldItem != null)
        {
            Drop();
        }

    }

    private void HandleRaycastInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(rayPosition.position, rayPosition.forward, out hit, 3, ~ignoredLayers))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.TryGetComponent(out Item item) && !hitObject.GetComponent<Purchasable>())
            {
                if (!inventory.CheckFreeSlots()) return;
                PickUp(hitObject);
            }
            else if (hitObject.TryGetComponent(out Purchasable purchasable))
            {
                if (!inventory.CheckFreeSlots()) return;
                else if (transform.GetComponent<Wallet>().Payment(purchasable.price))
                {
                    Instantiate(hitObject);
                    Destroy(purchasable);
                    PickUp(hitObject);
                }
            }
            else if (hitObject.TryGetComponent(out ItemCounerInteractable itemCounterInteractable))
            {
                itemCounterInteractable.DoAction(gameObject);
            }
        }
    }

    public void PickUp(GameObject item)
    {
        heldItem = item;
        Item itemComponent = heldItem.GetComponent<Item>();
        itemComponent.enabled = true;

        heldItem.transform.SetParent(itemComponent.parentPosition);
        heldItem.transform.localPosition = Vector3.zero;
        heldItem.transform.localRotation = Quaternion.identity;
        heldItem.GetComponent<Rigidbody>().isKinematic = true;

        inventory.AddItem(item);
    }

    public void Drop()
    {
        if (heldItem == null) return;

        Item itemComponent = heldItem.GetComponent<Item>();
        itemComponent.enabled = false;

        inventory.RemoveItem(heldItem);

        heldItem.transform.SetParent(null);
        heldItem.GetComponent<Rigidbody>().isKinematic = false;
        heldItem = null;
    }
}