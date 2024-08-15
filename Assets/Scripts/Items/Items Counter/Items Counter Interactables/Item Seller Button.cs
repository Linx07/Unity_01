using UnityEngine;
using UnityEngine.UI;

public class ItemSellerButton : ItemCounerInteractable
{
    private Wallet ownerWallet;

    public override void DoAction(GameObject raycastOwner)
    {
        if (raycastOwner.GetComponent<Wallet>())
        {
            ownerWallet = raycastOwner.GetComponent<Wallet>();
        }
        for (int i = 0; i < itemCounter.objectsInTrigger.Count; i++)
        {
            if (itemCounter.objectsInTrigger[i] != null && itemCounter.objectsInTrigger[i].GetComponent<Saleable>() != null)
            {
                ownerWallet.GetMoney(itemCounter.objectsInTrigger[i].GetComponent<Saleable>().price);
                Destroy(itemCounter.objectsInTrigger[i]);
            }
        }
    }
}
