using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] long _damage;

    [SerializeField] float _attackSpeed = 1.0f;
    Coroutine _idleAttack;

    [SerializeField] CharacterHealth _target;

    //Properties
    #region Properties
    #endregion

    private void Start()
    {
        StartIdleAttack();
    }

    public void Attack(long damage)
    {
        if (!_target.IsAlive) return;

        _target.TakeDamage(damage);
    }

    public void StartIdleAttack()
    {
        if (_idleAttack == null) _idleAttack = StartCoroutine(IdleAttack());
    }

    IEnumerator IdleAttack()
    {
        while (true)
        {
            if (_target != null) Attack(_damage);
            yield return new WaitForSeconds(_attackSpeed);
        }
    }

    public void StopIdleAttack()
    {
        if (_idleAttack != null)
        {
            StopCoroutine(_idleAttack);
            _idleAttack = null;
        }
    }
}
