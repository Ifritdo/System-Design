// Boss.cs
using UnityEngine;

[System.Serializable]
public class BossReference
{
    public BossCanvasManager canvasManager;
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

        if (bossReference != null && bossReference.healthBar != null && bossReference.canvasManager != null)
        {
            healthBar = bossReference.healthBar;
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);

            // Desactivar el objeto del Canvas al inicio
            bossReference.canvasManager.DeactivateBossCanvas();
        }
        else
        {
            Debug.LogWarning("La referencia a la barra de salud del jefe o al Canvas Manager no est� configurada correctamente.");
        }
    }

    void Update()
    {
        // Puedes agregar l�gica de actualizaci�n adicional para el jefe aqu�
    }

    // Resto del c�digo del jefe...

    void Die()
    {
        if (healthBar != null && bossReference.canvasManager != null)
        {
            // Activar el objeto del Canvas cuando el jefe muere
            bossReference.canvasManager.ActivateBossCanvas();

            // Desactivar el slider cuando el jefe muere
            healthBar.SetSliderActive(false);
        }

        // Puedes agregar cualquier l�gica adicional cuando el jefe muere
        // Por ejemplo, reproducir una animaci�n, mostrar un mensaje, etc.

        gameObject.SetActive(false);
    }
}
