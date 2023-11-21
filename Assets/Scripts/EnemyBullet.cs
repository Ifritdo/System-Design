using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si la bala colisiona con un cometa, simplemente la atraviesa.
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}

