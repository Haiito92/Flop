using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBinding : MonoBehaviour
{
    [SerializeField] Animator _anim;

    //Refs to components
    [SerializeField] CharacterHealth _characterHealth;

    private void Reset()
    {
        _anim = GetComponent<Animator>();

        _characterHealth = GetComponentInParent<CharacterHealth>();
    }

    private void Start()
    {
        _characterHealth.OnStartDeath += TriggerDeathAnimation;
    }

    void TriggerDeathAnimation()
    {
        _anim.SetTrigger("Die");
    }

    void TriggerDie()
    {
        _characterHealth.Die();
    }
}
