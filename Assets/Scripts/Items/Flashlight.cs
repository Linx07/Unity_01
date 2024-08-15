using UnityEngine;

public class Flashlight : Item
{
    public Light flashLight;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            flashLight.enabled = !flashLight.enabled;
        }
    }
}
