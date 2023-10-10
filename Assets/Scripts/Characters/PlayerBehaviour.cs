using NaughtyAttributes;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private bool _isDead = false;
    [SerializeField] private float _attackRate = 2;
    
    private IEnumerator _doDamageCoroutine;

    [SerializeField] private PlayerData _playerData;

    private void Awake()
    {
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
            GameManager.onPlayerDamage?.Invoke(_playerData.Damage);
            yield return new WaitForSeconds(1/_attackRate);
        }
    }
}
