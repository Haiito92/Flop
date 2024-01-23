using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBrain : CharacterBrain
{
    protected override IEnumerator AttackRoutine()
    {
        while (true) 
        {
            yield return null;
        }
    }
}
