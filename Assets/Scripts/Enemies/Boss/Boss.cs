using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public BossHealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;

        // Configuraci�n inicial de la barra de salud
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);

            // Activa el slider al inicio
            healthBar.SetSliderActive(true);
        }
    }

    public void TakeDamage(int damage)
    {
        // Restar la cantidad de da�o a la salud actual
        currentHealth -= damage;

        // Actualizar la barra de salud si est� asignada
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        // Verificar si la salud lleg� a cero
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Desactivar el slider cuando el jefe muere
        if (healthBar != null)
        {
            healthBar.SetSliderActive(false);
        }

        // Aqu� puedes agregar cualquier l�gica que quieras cuando el jefe muere
        // Por ejemplo, reproducir una animaci�n, mostrar un mensaje, etc.

        // Desactivar el GameObject del jefe
        gameObject.SetActive(false);
    }
}
