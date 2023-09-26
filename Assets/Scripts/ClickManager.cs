using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickManager : MonoBehaviour
{
   public void OnMouseClick(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("Click");
        }
    }
}
