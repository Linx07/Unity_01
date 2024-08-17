using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public enum StatusTypes
    {
        Health,
        Hunger
    }

    public StatusTypes statusType;
    public PlayerStats playerStats;
    public Text value;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();

        if (statusType == StatusTypes.Health)
        {
            slider.maxValue = playerStats.maxHealth;
        }
        else if (statusType == StatusTypes.Hunger)
        {
            slider.maxValue = playerStats.maxHunger;
        }
    }

    private void Update()
    {
        if (statusType == StatusTypes.Health)
            slider.value = playerStats.health;
        else if (statusType == StatusTypes.Hunger)
            slider.value = playerStats.hunger;

        if (value != null)
        {
            value.text = slider.value.ToString();
        }
    }
}
