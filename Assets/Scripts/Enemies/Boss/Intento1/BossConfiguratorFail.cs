using System.Collections;
using UnityEngine;

public class BossConfiguratorFail : MonoBehaviour
{
    [SerializeField] private float _initialSpeed = 4f;
    [SerializeField] private int _initialLifeTotal = 25;
    [SerializeField] private GameObject[] _bossAttacks;
    [SerializeField] private GameObject _explosionPrefab;
    private Animator _animator;
    private BoxCollider2D _bossCollider;
    private bool _startBossAttacks = false;
    private bool _fightStarted = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _bossCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(StartBossFight());
    }

    private void Update()
    {
        if (_startBossAttacks == true && _fightStarted == true)
        {
            StartCoroutine(BossAttacksRoutine());
        }
    }

    private IEnumerator StartBossFight()
    {
        yield return new WaitForSeconds(4f);
        _startBossAttacks = true;
        _fightStarted = true;
    }

    private IEnumerator BossAttacksRoutine()
    {
        _startBossAttacks = false;
        yield return new WaitForSeconds(1f);

        while (_fightStarted == true)
        {
            int _randomAttack = Random.Range(0, 3);
            if (_randomAttack == 2)
            {
                Vector3 _laserSpawnPos1 = new Vector3(5.3f, 6.5f, 0);
                Vector3 _laserSpawnPos2 = new Vector3(-5.3f, 6.5f, 0);
                for (int i = 0; i < 3; i++)
                {
                    int _randomLaserPos = Random.Range(0, 2);
                    if (_randomLaserPos == 0)
                    {
                        Instantiate(_bossAttacks[2], _laserSpawnPos1, Quaternion.identity);
                    }
                    else if (_randomLaserPos == 1)
                    {
                        Instantiate(_bossAttacks[2], _laserSpawnPos2, Quaternion.identity);
                    }
                    yield return new WaitForSeconds(1f);
                }
            }
            else
            {
                Vector3 _attackSpawnPos = new Vector3(5.3f, Random.Range(2.5f, 6.5f), 0);
                Instantiate(_bossAttacks[_randomAttack], _attackSpawnPos, Quaternion.identity);
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
