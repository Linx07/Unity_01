using TMPro;
using UnityEngine;

public class Price : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Purchasable>() != null)
        {
            transform.gameObject.GetComponent<TextMeshPro>().text = other.gameObject.GetComponent<Purchasable>().price.ToString() + "$";
        }
    }
}
