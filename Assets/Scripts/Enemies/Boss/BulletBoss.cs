using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    public float bulletLife = 1f;  // Define cu�nto tiempo antes de que la bala sea destruida
    public float speed = 1f;

    private Vector2 spawnPoint;
    private float timer = 0f;

    // Da�o que la bala inflige al jugador.
    public int damageToPlayer = 20;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > bulletLife)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  // Aseg�rate de que tu jugador tenga el tag "Player".
        {
            // Obt�n la referencia al componente de salud del jugador (ajusta esto seg�n la estructura de tu jugador).
            Player playerHealth = collision.GetComponent<Player>();

            // Si el componente de salud del jugador existe, inflige da�o al jugador.
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageToPlayer);
            }

            // Desactiva la bala.
            gameObject.SetActive(false);
        }
    }

    private Vector2 Movement(float timer)
    {
        // Mueve la bala hacia la derecha seg�n la rotaci�n de la bala
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }
}
