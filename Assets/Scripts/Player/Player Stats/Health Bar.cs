using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerStats playerStats;
    private Slider slider;
    public Text value;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = playerStats.maxHealth;
    }

    private void Update()
    {
        slider.value = playerStats.health;
        if (value != null)
        {
            value.text = slider.value.ToString();
        }
    }
}
