using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpreadLaserAttackFail : MonoBehaviour
{
    [SerializeField] private float _laserSpeed = 8f;

    void Update()
    {
        transform.Translate(-transform.up * _laserSpeed * Time.deltaTime);

        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other);
    }

    private void HandleCollision(Collider2D other)
    {
        if (other.CompareTag("Laser") || other.CompareTag("Explosion") || other.CompareTag("Bomb"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
