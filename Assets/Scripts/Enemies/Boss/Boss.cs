// Boss.cs
using UnityEngine;

[System.Serializable]
public class BossReference
{
    public BossCanvasManager canvasManager;
    public BossHealthBar healthBar;
    public ScoreManager scoreManager;  // Agrega una referencia al ScoreManager
}

public class Boss : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    private int currentHealth;

    [SerializeField]
    private int pointsValue = 50;  // Valor de puntos que otorga al ser derrotado

    public BossReference bossReference;

    private BossHealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;

        if (bossReference != null && bossReference.healthBar != null && bossReference.canvasManager != null && bossReference.scoreManager != null)
        {
            healthBar = bossReference.healthBar;
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);

            // Desactivar el objeto del Canvas al inicio
            bossReference.canvasManager.DeactivateBossCanvas();
        }
        else
        {
            Debug.LogWarning("La referencia a la barra de salud del jefe, al Canvas Manager o al Score Manager no está configurada correctamente.");
        }
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (healthBar != null && bossReference.canvasManager != null && bossReference.scoreManager != null)
        {
            // Activar el objeto del Canvas cuando el jefe muere
            bossReference.canvasManager.ActivateBossCanvas();

            // Desactivar el slider cuando el jefe muere
            healthBar.SetSliderActive(false);

            // Otorgar puntos al ScoreManager
            bossReference.scoreManager.AddPoints(GetPointsValue());

            // Puedes agregar cualquier lógica adicional cuando el jefe muere
            // Por ejemplo, reproducir una animación, mostrar un mensaje, etc.

            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica la colisión con la bala del jugador
        if (collision.CompareTag("PlayerBullet"))
        {
            Bullet bullet = collision.GetComponent<Bullet>();

            if (bullet != null && currentHealth > 0)
            {
                // Restar la cantidad de daño a la salud actual
                currentHealth -= bullet.damage;

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
        }
    }

    // Resto del código...

    // Método para obtener el valor en puntos del jefe
    public int GetPointsValue()
    {
        return pointsValue;
    }
}
