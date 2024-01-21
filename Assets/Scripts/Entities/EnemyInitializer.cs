using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInitializer : MonoBehaviour
{
    [SerializeField] IdleBrain _enemyBrain;
    [SerializeField] EnemyHealth _enemyHealth;
    [SerializeField] BaseAttack _enemyAttack;
    [SerializeField] EnemyDrop _enemyDrop;
    [SerializeField] Animator _animator;
    [SerializeField] AnimationCurve _healthScalingCurve;
    [SerializeField] AnimationCurve _damageScalingCurve;
    [SerializeField] AnimationCurve _dropScalingCurve;

    private void Reset()
    {
        _enemyBrain = GetComponent<IdleBrain>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Initialize(EnemyData enemyData, CharacterHealth target, int currentBossfight, int currentSegment)
    {
        _animator.runtimeAnimatorController = enemyData.Controller;
        _enemyBrain.SetTarget(target);

        _enemyHealth.MaxHealth += Scale(_healthScalingCurve, currentBossfight, currentSegment);

        //Debug.Log(_enemyHealth.MaxHealth);
    }

    private long Scale(AnimationCurve animationCurve, int currentBossfight, int currentSegment)
    {
        return (long)((currentBossfight - 1 + currentSegment) * (animationCurve.Evaluate((float)currentSegment / 10) * 10) * (currentBossfight + animationCurve.Evaluate(currentSegment / 10))); //Scaling plus linéaire mais dernier mob de chaque segment a bcp plus d'hp (genre de boss)
    }
}
