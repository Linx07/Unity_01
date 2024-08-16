using UnityEngine;

public class FirsAidKit : Item
{
    public float hp;
    public PlayerStats stats;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            stats.GetHealth(hp);
            Destroy(gameObject);
        }
    }
}
