using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    public float health;
    public float maxHealth = 100;
    public float hunger;
    public float maxHunger = 100;

    [Header("Hunger Settings")]
    public float hungerDecreaseRate = 1f;

    public void Update()
    {
        DecreaseHunger();

        if (hunger <= 0)
        {
            TakeDamage(1f * Time.deltaTime);
        }
        else if (hunger > 50)
        {
            GetHealth(1f * Time.deltaTime);
        }
        
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxHealth);
    }

    public void GetHealth(float amount)
    {
        health = Mathf.Clamp(health + amount, 0, maxHealth);
    }

    public void DecreaseHunger()
    {
        hunger = Mathf.Clamp(hunger - hungerDecreaseRate * Time.deltaTime, 0, maxHunger);
    }
    public void GetHunger(float amount)
    {
        hunger = Mathf.Clamp(hunger + amount, 0, maxHunger);
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
