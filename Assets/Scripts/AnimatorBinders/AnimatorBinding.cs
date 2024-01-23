using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBinding : MonoBehaviour
{
    [SerializeField] Animator _anim;

    //Refs to components
    [SerializeField] CharacterHealth _characterHealth;
    [SerializeField] BrainBinding _brainBinding;
    [SerializeField] CharacterBrain _currentBrain;

    private void Reset()
    {
        _anim = GetComponent<Animator>();

        _characterHealth = GetComponentInParent<CharacterHealth>();
    }

    private void Start()
    {
        _characterHealth.OnStartDeath += TriggerDeathAnimation;

        _brainBinding.OnBrainChange += ChangeBrain;

        _currentBrain.OnBasicAttack += TriggerBasicAttackAnimation;
        _currentBrain.OnSpecialAttack += TriggerSpecialAttackAnimation;
    }

    void ChangeBrain(CharacterBrain newBrain)
    {
        _currentBrain = newBrain;
    }

    void TriggerDeathAnimation()
    {
        _anim.SetTrigger("Die");
    }

    void TriggerDie()
    {
        _characterHealth.Die();
    }

    void TriggerBasicAttackAnimation()
    {
        _anim.SetTrigger("Attack");
    }

    void TriggerAttack()
    {
        _currentBrain.DoBasicAttack();
    }

    private void TriggerSpecialAttackAnimation()
    {
        _anim.SetTrigger("SpecialAttack");
    }

    void TriggerSpecialAttack()
    {
        _currentBrain.DoSpecialAttack();
    }
}
