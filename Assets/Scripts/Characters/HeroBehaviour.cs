using System.Collections;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    //Fields
    private bool _isDead = false;
    [SerializeField] private float _attackRate = 2;
    private int _level = 1;
   
    //Coroutines&IEnumerators
    private IEnumerator _doDamageCoroutine;

    // References
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
        Reset();
    }
    // Reset Functions //
    private void Reset()
    {
        _heroStats.Health = _heroStats.MaxHealth.BaseValue;
    }
}
