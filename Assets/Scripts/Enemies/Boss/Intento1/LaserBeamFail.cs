using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamFail : MonoBehaviour
{
    public int damage = 10;

    private Player _playerScript;

    void Start()
    {
        _playerScript = GameObject.Find("Player").GetComponent<Player>();

        if (_playerScript == null)
        {
            Debug.LogError("Player script is null");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_playerScript != null)
            {
                _playerScript.TakeDamage(damage);  // Cambia aqu� de Damage a TakeDamage
                gameObject.SetActive(false);
            }
        }

        if (collision.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
        }
    }
}
