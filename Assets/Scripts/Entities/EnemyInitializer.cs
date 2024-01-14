using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInitializer : MonoBehaviour
{
    [SerializeField] IdleBrain _enemyBrain;
    [SerializeField] Animator _animator;

    private void Reset()
    {
        _enemyBrain = GetComponent<IdleBrain>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Initialize(EnemyData enemyData, CharacterHealth target)
    {
        _animator.runtimeAnimatorController = enemyData.Controller;
        _enemyBrain.SetTarget(target);
    }
}
