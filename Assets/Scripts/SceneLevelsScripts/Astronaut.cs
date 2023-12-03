using UnityEngine;

public class Astronaut : MonoBehaviour
{
    public float speed = 5f;  // Velocidad de movimiento

    private Animator astronautAnimator;

    private void Start()
    {
        astronautAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Obtener la entrada del teclado
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Mover al jugador
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Actualizar las animaciones
        UpdateAnimations(horizontalInput, verticalInput);
    }

    private void UpdateAnimations(float horizontal, float vertical)
    {
        // Comprobar si el jugador se est� moviendo
        bool isMoving = (horizontal != 0f || vertical != 0f);

        // Configurar los par�metros del Animator
        astronautAnimator.SetBool("IsMoving", isMoving);
    }
}