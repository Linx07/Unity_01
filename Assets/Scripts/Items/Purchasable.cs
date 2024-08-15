using UnityEngine;

public class Purchasable : MonoBehaviour
{
    public int price;

    private void Start()
    {
        transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
