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
        _doDamageCoroutine = DoDamageCoroutine();
    }

    private void Start()
    {
        StartCoroutine(_doDamageCoroutine);
    }

    private IEnumerator DoDamageCoroutine()
    {
        while (!_isDead)
        {
            GameManager.onHeroDamage?.Invoke(_heroStats.Damage);
            yield return new WaitForSeconds(1 / _attackRate);
        }
    }
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
        Reset();
    }

    private void Reset()
    {
        _heroStats.Health = _heroStats.MaxHealth;
    }
}
