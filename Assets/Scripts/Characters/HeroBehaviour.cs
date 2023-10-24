using System.Collections;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    private bool _isDead = false;
    [SerializeField] private float _attackRate = 2;

    private IEnumerator _doDamageCoroutine;

    [SerializeField] private HeroStats _heroStats;

    private void Awake()
    {
        GameManager.onClickDamage += TakeDamage;
        GameManager.onPlayerDamage += TakeDamage;
        GameManager.onNextSegment += LevelUp;

        _doDamageCoroutine = DoDamageCoroutine();
    }

    private void Start()
    {
        StartCoroutine(_doDamageCoroutine);
    }

    // Boost on new segment //
    private void LevelUp()
    {
        _heroStats.Damage += 1;
    }

    // Reset //
    private void Reset()
    {
        _heroStats.Health = _heroStats.MaxHealth;
    }

    // Damage //
    private IEnumerator DoDamageCoroutine()
    {
        while (!_isDead)
        {
            GameManager.onHeroDamage?.Invoke(_heroStats.Damage);
            yield return new WaitForSeconds(1 / _attackRate);
        }
    }

    // Health //
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
        Reset();
    }
}
