using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDublicate : ItemCounerInteractable
{
    public override void DoAction(GameObject gameObject)
    {
        foreach (GameObject obj in itemCounter.objectsInTrigger)
        {
            if (obj != null)
            {
                GameObject duplicatedObject = Instantiate(obj);
                duplicatedObject.transform.position += new Vector3(0, 1, 0);
            }
        }
    }
}
