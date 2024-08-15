using UnityEngine;

public abstract class ItemCounerInteractable : MonoBehaviour
{
    public ItemCounter itemCounter;

    public abstract void DoAction(GameObject gameObject);
}
