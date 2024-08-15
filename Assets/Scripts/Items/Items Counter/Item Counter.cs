using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ItemCounter : MonoBehaviour
{
    public string tagToCount;
    public Text displayCount;
    public string textMessage;

    public List<GameObject> objectsInTrigger = new List<GameObject>();

    private int totalValue;
    public TextMeshPro howManyGetText;

    private void Update()
    {
        objectsInTrigger.RemoveAll(item => item == null);
        SaleableCheck();
        UpdateDisplay();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagToCount))
        {
            objectsInTrigger.Add(other.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(tagToCount))
        {
            objectsInTrigger.Remove(other.gameObject);
        }
    }

    public void UpdateDisplay()
    {
        if (displayCount != null)
        {
            displayCount.text = textMessage + objectsInTrigger.Count;
        }
        if (howManyGetText != null)
        {
            howManyGetText.text = totalValue + "$";
        }
    }

    public void SaleableCheck()
    {
        totalValue = 0;
        for (int i = 0; i < objectsInTrigger.Count; i++)
        {
            if (objectsInTrigger[i].GetComponent<Saleable>())
            {
                totalValue += objectsInTrigger[i].GetComponent<Saleable>().price;
            }
        }
    }
}