using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    public float health;
    public float maxHealth = 100;
    public float hunger = 100;

    [Header("Hunger Settings")]
    public float hungerDecreaseRate = 1f;

    private void Start()
    {
        
    }

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

    public void DecreaseHunger()
    {
        if (hunger > 0)
        {
            hunger -= hungerDecreaseRate * Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {
        if (health - damage < 0)
        {
            health = 0;
        }
        else
        {
            health -= damage;
        }
    }

    public void GetHealth(float amount)
    {
        if (health + amount > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += amount;
        }
    }

    public void GetHunger(float amount)
    {
        if (hunger + amount > 100)
        {
            hunger = 100;
        }
        else
        {
            hunger += amount;
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
