using TMPro;
using UnityEngine;

public class Price : MonoBehaviour
{
    private TextMeshPro _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Purchasable purchasable))
        {
            _textMeshPro.text = $"{purchasable.price}$";
        }
    }
}
