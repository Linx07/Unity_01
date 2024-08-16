using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    private Slider slider;
    public PlayerStats playerStats;
    public Text value;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = playerStats.hunger;
    }

    private void Update()
    {
        slider.value = playerStats.hunger;
        if (value != null)
        {
            value.text = slider.value.ToString();
        }
    }
}
