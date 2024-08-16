using Unity.VisualScripting;
using UnityEngine;

public class Food : Item
{
    public PlayerStats stats;
    public int satisfiedhunger;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            stats.GetHunger(satisfiedhunger);
            Destroy(gameObject);
        }
    }
}
