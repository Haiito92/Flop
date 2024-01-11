using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] List<BaseAttack> _attackList = new List<BaseAttack>();

    private void Reset()
    {
        _attackList = GetComponents<BaseAttack>().ToList();
    }

    public void SetAllTargets(CharacterHealth target)
    {
        foreach (BaseAttack attack in _attackList)
        {
            attack.SetTarget(target);
        }
    }
}
