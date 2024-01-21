using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBinding : MonoBehaviour
{
    [SerializeField] Animator _anim;

    //Refs to components
    [SerializeField] CharacterHealth _characterHealth;
    [SerializeField] CharacterBrain _characterBrain;

    private void Reset()
    {
        _anim = GetComponent<Animator>();

        _characterHealth = GetComponentInParent<CharacterHealth>();
    }

    private void Start()
    {
        _characterHealth.OnStartDeath += TriggerDeathAnimation;

        _characterBrain.OnBasicAttack += TriggerBasicAttackAnimation;
        _characterBrain.OnSpecialAttack += TriggerSpecialAttackAnimation;
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
        _characterBrain.DoBasicAttack();
    }

    private void TriggerSpecialAttackAnimation()
    {
        _anim.SetTrigger("SpecialAttack");
    }

    void TriggerSpecialAttack()
    {
        _characterBrain.DoSpecialAttack();
    }
}
