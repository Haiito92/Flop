using System.Collections;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    //Fields
    private bool _isDead = false;
    [SerializeField] private float _attackRate = 2;
    private int _level = 1;

    [SerializeField] private float _timeBeforeRespawn; 

    //Coroutines&IEnumerators
    private IEnumerator _doDamageCoroutine;
    private Coroutine _waitBeforeRespawn;

    // References
    [SerializeField] private HeroStats _heroStats;

    private void Awake()
    {
        GameManager.onClickDamage += TakeDamage;
        GameManager.onPlayerDamage += TakeDamage;
        GameManager.onNextSegment += LevelUp;
        GameManager.onResetBossFight += Reset;

        _doDamageCoroutine = DoDamageCoroutine();
    }

    private void Start()
    {
        StartCoroutine(_doDamageCoroutine);
    }

    // Scaling Functions //
    private void LevelUp()
    {
        _level++;
        _heroStats.ScaleStats(_level);
    }

    // Damage Functions //
    private IEnumerator DoDamageCoroutine()
    {
        while (!_isDead)
        {
            GameManager.onHeroDamage?.Invoke(_heroStats.Damage.BaseValue);
            yield return new WaitForSeconds(1 / _attackRate);
        }
    }

    // Health Functions //
    public void TakeDamage(long amount)
    {
        _heroStats.Health -= amount;

        if(_heroStats.Health <= 0 )
        {
            Die();
        }
    }
    private void Die()
    {
        GameManager.Instance.NextSegment();
        _waitBeforeRespawn = StartCoroutine(WaitBeforeRespawn());
    }
    // Reset Functions //
    private void Reset()
    {
        _heroStats.Health = _heroStats.MaxHealth.BaseValue;
    }

    private IEnumerator WaitBeforeRespawn()
    {
        StopCoroutine(_doDamageCoroutine);
        GameManager.onClickDamage -= TakeDamage;
        GameManager.onPlayerDamage -= TakeDamage;
        yield return new WaitForSeconds(_timeBeforeRespawn);
        Reset();
        GameManager.onClickDamage += TakeDamage;
        GameManager.onPlayerDamage += TakeDamage;
        _doDamageCoroutine = DoDamageCoroutine();
        StartCoroutine(_doDamageCoroutine);
        StopWaitBeforeRespawn();
    }

    private void StopWaitBeforeRespawn()
    {
        StopCoroutine(_waitBeforeRespawn);
    }

}
