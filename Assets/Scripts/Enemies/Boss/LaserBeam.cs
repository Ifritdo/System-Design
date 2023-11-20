using UnityEngine;

public class LaserBeam : MonoBehaviour
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
                _playerScript.TakeDamage(damage);
                gameObject.SetActive(false);
            }
        }

        if (collision.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
        }
    }
}