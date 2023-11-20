using UnityEngine;

public class HealItem : MonoBehaviour
{
    public int healAmount = 20; // La cantidad de salud que se restaurar�.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Aseg�rate de que tu nave tenga la etiqueta "Player".
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                player.Heal(healAmount); // Llamada al m�todo Heal en el script de la nave.
                Destroy(gameObject); // Destruimos el �tem de curaci�n despu�s de usarlo.
            }
        }
    }
}