using UnityEngine;

public class Destructable : MonoBehaviour
{
    bool canBeDestroyed = false;
    private Enemy enemyScript;
    private SoundManager soundManager;

    void Start()
    {
        enemyScript = GetComponent<Enemy>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        if (transform.position.x < 18.63f)
        {
            canBeDestroyed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroyed)
        {
            return;
        }

        // Comprueba si la colisi�n es con la DeathWall
        if (collision.gameObject.CompareTag("DeathWall"))
        {
            // Destruye el enemigo sin sumar puntos al score ni reproducir sonido
            Destroy(gameObject);
            return;
        }

        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (!bullet.isEnemy)
            {
                if (enemyScript != null)
                {
                    enemyScript.HandleBulletHit(); // Llama al m�todo en el script del enemigo

                    // A�adir puntos cuando se destruye el enemigo
                    ScoreManager.instance.AddPoints(enemyScript.GetPointsValue());
                }

                // Reproduce el sonido de explosi�n
                if (soundManager != null)
                {
                    soundManager.PlayExplosionSound(false); // Pasa false para indicar que no debe reproducir el sonido de explosi�n de enemigos
                }

                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
        }

        // Si el objeto colisionado es un �tem, destr�yelo
        if (collision.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
        }
    }
}