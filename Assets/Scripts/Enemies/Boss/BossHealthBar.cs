// BossHealthBar.cs
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Image slider;

    private void Start()
    {
        // Desactivar el slider al inicio
        SetSliderActive(false);
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.fillAmount = maxHealth;
    }

    public void SetHealth(int health)
    {
        slider.fillAmount = health;
    }

    public void SetSliderActive(bool active)
    {
        // Activa o desactiva el slider según el parámetro 'active'
        slider.gameObject.SetActive(active);
    }
}
