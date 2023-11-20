using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserBeamAttackFail : MonoBehaviour
{
    private float _bossSpeed = 4;
    [SerializeField] private GameObject _laserBeam;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private AudioClip _explosionClip;
    private AudioSource _audioSource;
    private Animator _animator;
    private bool _isLaserBeamReady = false;
    private bool _hasUsedLaserBeam = false;
    [SerializeField] private AudioClip _laserBeamClip;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        if (_animator == null)
        {
            Debug.Log("_animator is NULL");
        }

        if (_audioSource == null)
        {
            Debug.Log("Audiosource is NULL");
        }
        else
        {
            _audioSource.clip = _laserBeamClip;
        }

        if (transform.position.x > 0)
        {
            transform.Rotate(0, 0, 270);
        }
        else if (transform.position.x < 0)
        {
            transform.Rotate(0, 0, 90);
        }
    }

    void Update()
    {
        BossMovement();
        FireLaserBeam();
    }

    private void BossMovement()
    {
        transform.Translate(Vector3.up * _bossSpeed * Time.deltaTime);

        if (transform.position.y < -9)
        {
            Destroy(gameObject);
        }
    }

    private void FireLaserBeam()
    {
        if (transform.position.y <= 1)
        {
            _isLaserBeamReady = true;
        }

        if (_isLaserBeamReady && !_hasUsedLaserBeam)
        {
            StartCoroutine(LaserBeamAttack());
        }
    }

    IEnumerator LaserBeamAttack()
    {
        _hasUsedLaserBeam = true;
        _laserBeam.SetActive(true);
        _audioSource.Play();
        yield return null;
    }
}
