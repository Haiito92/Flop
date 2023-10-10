using NaughtyAttributes;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private bool _isDead = false;
    [SerializeField] private float _attackRate = 2;
    
    private IEnumerator _doDamageCoroutine;

    [SerializeField] private PlayerStats _playerStats;

    private void Awake()
    {
        GameManager.onHeroDamage += TakeDamage;
        _doDamageCoroutine = DoDamageCoroutine();
    }

    private void Start()
    {
        StartCoroutine(_doDamageCoroutine);
    }

    public void ClickDamage()
    {
        Debug.Log("Clicked");
        GameManager.onClickDamage?.Invoke(_playerStats.ClickDamage);
    }

    private IEnumerator DoDamageCoroutine()
    {
        while (!_isDead)
        {
            GameManager.onPlayerDamage?.Invoke(_playerStats.Damage);
            yield return new WaitForSeconds(1/_attackRate);
        }
    }

    public void TakeDamage(long amount)
    {
        _playerStats.Health -= amount;

        if (_playerStats.Health <= 0)
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
        _playerStats.Health = _playerStats.MaxHealth;
    }
}
