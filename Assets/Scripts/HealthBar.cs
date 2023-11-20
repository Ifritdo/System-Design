using UnityEngine;
using UnityEngine.UI;
using TMPro; // Asegúrate de incluir este namespace

    public class HealthBar : MonoBehaviour
    {
        public Slider slider;
        public TextMeshProUGUI lifePointText; // Referencia al componente TextMeshProUGUI

        private void Start()
        {
            if (lifePointText == null)
            {
                lifePointText = GetComponentInChildren<TextMeshProUGUI>();
            }
        }

        public void SetHealth(float health)
        {
            slider.value = health;
            lifePointText.text = health.ToString(); // Actualizar el texto
        }

        public void SetMaxHealth(float health)
        {
            slider.maxValue = health;
            slider.value = health;
            lifePointText.text = health.ToString(); // Actualizar el texto
        }
    }