using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int slotCount;

    public List<GameObject> items = new List<GameObject>();
    private RaycastSystem raycastSystem;
    public int currentSlot = 0;

    private void Awake()
    {
        raycastSystem = GetComponent<RaycastSystem>();
    }

    private void Start()
    {
        for (int i = 0; i < slotCount; i++)
        {
            items.Add(null);
        }
    }

    private void Update()
    {
        HandleSlotSwitchInput();
    }

    public void AddItem(GameObject item)
    {
        if (items[currentSlot] == null) items[currentSlot] = item;
            

        else
        {
            int freeSlot = -1;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == null)
                {
                    freeSlot = i;
                    break;
                }
            }

            if (freeSlot != -1)
            {
                items[freeSlot] = item;
                SelectSlot(freeSlot);
            }
        }
    }
    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == item)
            {
                items[i] = null;
                break;
            }
        }
    }

    private void SelectSlot(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= slotCount) return;

        if (items[currentSlot] != null)
        {
            items[currentSlot].SetActive(false);
        }

        currentSlot = slotIndex;

        if (items[currentSlot] != null)
        {
            items[currentSlot].SetActive(true);
            raycastSystem.heldItem = items[currentSlot];
        }
    }

    private void HandleSlotSwitchInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { SelectSlot(0); }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) { SelectSlot(1); }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) { SelectSlot(2); }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) { SelectSlot(3); }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) { SelectSlot(4); }
        else if (Input.GetKeyDown(KeyCode.Alpha6)) { SelectSlot(5); }
        else if (Input.GetKeyDown(KeyCode.Alpha7)) { SelectSlot(6); }
        else if (Input.GetKeyDown(KeyCode.Alpha8)) { SelectSlot(7); }
        else if (Input.GetKeyDown(KeyCode.Alpha9)) { SelectSlot(8); }
        else if (Input.GetKeyDown(KeyCode.Alpha0)) { SelectSlot(9); }
    }

    public bool CheckFreeSlots()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null) return true;
        }
        return false;
    }
}
