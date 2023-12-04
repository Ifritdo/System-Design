using UnityEngine;
using UnityEngine.SceneManagement;

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
        // Comprobar si el jugador se está moviendo
        bool isMoving = (horizontal != 0f || vertical != 0f);

        // Configurar los parámetros del Animator
        astronautAnimator.SetBool("IsMoving", isMoving);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Computer"))
        {
            string sceneToLoad = GetSceneNameFromCollider(other);
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

    private string GetSceneNameFromCollider(Collider2D collider)
    {
        // Lógica para determinar la escena basada en el collider
        // Puedes implementar la lógica específica de tu juego aquí
        // Devuelve el nombre de la escena a cargar

        if (collider.gameObject.name == "LevelAcces1")
        {
            return "MyMainGame";
        }
        else if (collider.gameObject.name == "LevelAcces2")
        {
            return "MyMainGame1";
        }
        else if (collider.gameObject.name == "LevelAcces3")
        {
            return "MyMainGame2";
        }

        return null;  // Devuelve null si no se encuentra una escena correspondiente
    }
}
