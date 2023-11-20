using UnityEngine;

public class BossCollisionHandlerFail : MonoBehaviour
{
    private float _enemySpeed = 4f;
    private bool _moveLeft = false;
    private int _lifeTotal = 25;
    private bool _fightStarted = false;
    private BoxCollider2D _bossCollider;
    private GameObject _player;
    [SerializeField] private GameObject _explosionPrefab;
    private Animator _animator;

    private void Start()
    {
        _bossCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        if (transform.position.y > 3.25)
        {
            transform.Translate(Vector3.down * (_enemySpeed / 2) * Time.deltaTime);
        }

        if (transform.position.x <= 4f)
        {
            _moveLeft = true;
        }

        if (_moveLeft == true && _fightStarted == true)
        {
            transform.Translate(Vector3.left * _enemySpeed * Time.deltaTime);
        }

        if (transform.position.x <= -10f)
        {
            _moveLeft = false;
        }

        if (_moveLeft == false && _fightStarted == true)
        {
            transform.Translate(Vector3.right * _enemySpeed * Time.deltaTime);
        }

        if (_fightStarted == true)
        {
            _bossCollider.enabled = true;
        }
    }

    private void BossDamage()
    {
        _lifeTotal--;
        _animator.SetTrigger("Damaged");

        if (_lifeTotal == 0)
        {
            _fightStarted = false;
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player _playerScript = other.GetComponent<Player>();
            _playerScript.TakeDamage(10.0f);
        }

        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            BossDamage();
        }

        if (other.CompareTag("Bomb"))
        {
            Destroy(other.gameObject);
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            BossDamage();
        }
    }
}
