using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Inputs : MonoBehaviour
{
    public Vector2 RowMoveInput {get; private set;}
    public int XmoveInput { get; private set;}
    public int YmoveInput { get; private set;}
    public bool Shot;
    public bool IsJump { get ; private set;}
    public void OnMove(InputAction.CallbackContext ctx)
    {
        RowMoveInput = ctx.ReadValue<Vector2>();
        XmoveInput = (int)(RowMoveInput * Vector2.right).normalized.x;
        YmoveInput = (int)(RowMoveInput * Vector2.up).normalized.y;
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            IsJump = true;
        } 
     }


    public void ResetJumpInput()
    {
        IsJump = false;
    }




    
}
 