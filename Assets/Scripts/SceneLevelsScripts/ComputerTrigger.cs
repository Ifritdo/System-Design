using UnityEngine;

public class ComputerTrigger : MonoBehaviour
{
    public ComputerController computerController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador está cerca, activar el mensaje
            computerController.ShowConfirmationPanel();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador se ha alejado, ocultar el mensaje
            computerController.HideConfirmationPanel();
        }
    }
}
