// Boss.cs
using UnityEngine;

[System.Serializable]
public class BossReference
{
    public BossHealthBar healthBar;
}

public class Boss : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public BossReference bossReference;

    private BossHealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;

        if (bossReference != null && bossReference.healthBar != null)
        {
            healthBar = bossReference.healthBar;
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);
            healthBar.SetSliderActive(true);
        }
        else
        {
            Debug.LogWarning("La referencia a la barra de salud del jefe no est� configurada correctamente.");
        }
    }

    void Update()
    {
        // Puedes agregar l�gica de actualizaci�n adicional para el jefe aqu�
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (healthBar != null)
        {
            healthBar.SetSliderActive(false);
        }

        // Puedes agregar cualquier l�gica adicional cuando el jefe muere
        // Por ejemplo, reproducir una animaci�n, mostrar un mensaje, etc.

        gameObject.SetActive(false);
    }
}
