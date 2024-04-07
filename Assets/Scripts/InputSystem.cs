using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.InputSystem.Controls;

public class InputSystem : MonoBehaviour
{
    private float horizontalMovement;
    public PlayerController pController;
    public void GetAxis(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<float>();
    }
    public void GetJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pController.JumpPlayer();
        }
    }
    public void GetButtonNorth(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pController.UpdateColor(1);
        }
    }
    public void GetButtonEast(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pController.UpdateColor(2);
        }
    }
    public void GetButtonWest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pController.UpdateColor(0);
        }
    }
    public float GetAxis()
    {
        return horizontalMovement;
    }
}