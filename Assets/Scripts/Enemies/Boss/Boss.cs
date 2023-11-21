using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public BossHealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;

        // Configuración inicial de la barra de salud
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
        // Restar la cantidad de daño a la salud actual
        currentHealth -= damage;

        // Actualizar la barra de salud si está asignada
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        // Verificar si la salud llegó a cero
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

        // Aquí puedes agregar cualquier lógica que quieras cuando el jefe muere
        // Por ejemplo, reproducir una animación, mostrar un mensaje, etc.

        // Desactivar el GameObject del jefe
        gameObject.SetActive(false);
    }
}
