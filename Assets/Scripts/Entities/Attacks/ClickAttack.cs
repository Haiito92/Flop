using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAttack : BaseAttack
{
    public void OnClickAttack()
    {
        Attack(_damage);
    }
}
