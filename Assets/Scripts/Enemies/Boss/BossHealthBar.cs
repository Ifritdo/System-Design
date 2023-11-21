// BossHealthBar.cs
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        // Desactivar el slider al inicio
        SetSliderActive(false);
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void SetSliderActive(bool active)
    {
        // Activa o desactiva el slider según el parámetro 'active'
        slider.gameObject.SetActive(active);
    }
}
