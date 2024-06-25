using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    public event EventHandler OnInteract;

    private PlayerInputActions playerInputActions;

    //Initialization of Input Actions   
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        //Initialize Interact performed event
        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //if press Interact,then message of Callback Context
        //Debug.Log(obj);
            OnInteract?.Invoke(this, EventArgs.Empty);
    }

    //Get normalized input vector 
    public Vector2 GetMovementVectorNorm()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
