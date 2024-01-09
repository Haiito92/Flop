using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInitializer : MonoBehaviour
{
    [SerializeField] CharacterAttack _characterAttack;
    [SerializeField] Animator _animator;

    private void Reset()
    {
        _characterAttack = GetComponent<CharacterAttack>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Initialize(EnemyData enemyData, CharacterHealth target)
    {
        _animator.runtimeAnimatorController = enemyData.Controller;
        _characterAttack.SetTarget(target);
    }
}
