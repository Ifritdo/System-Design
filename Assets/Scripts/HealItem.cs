using UnityEngine;

public class HealItem : MonoBehaviour
{
    public int healAmount = 20; // La cantidad de salud que se restaurará.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Asegúrate de que tu nave tenga la etiqueta "Player".
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                player.Heal(healAmount); // Llamada al método Heal en el script de la nave.
                Destroy(gameObject); // Destruimos el ítem de curación después de usarlo.
            }
        }
    }
}