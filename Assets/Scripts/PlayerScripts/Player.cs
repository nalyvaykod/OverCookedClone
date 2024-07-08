using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance { get; set; }


    public event EventHandler<OnSelectedCountChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCountChangedEventArgs : EventArgs
    {
        public ClearCounter selectedCounter;
    }

    [SerializeField] private float Speed = 10f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask counterLayerMask;

    private bool isWalking;
    private Vector3 InteractDirection;
    private ClearCounter selectedCounter;

    private void Awake()
    {
        if (Instance != null)
        {

        }

        Instance = this;
    }
    private void Start()
    {
        gameInput.OnInteract += GameInput_OnInteract;
    }

    private void GameInput_OnInteract(object sender, System.EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.Interact();
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleInteraction();
    }

    //Animation
    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleInteraction()
    {

        Vector2 inputVector = gameInput.GetMovementVectorNorm();
        Vector3 movementDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        if (movementDirection != Vector3.zero)
        {
            InteractDirection = movementDirection;
        }

        //Distance to interact
        float interactDistance = 2f;

        //Last point of raycast
        RaycastHit hit;

        //if Raycast fucntion find something,than debug log some text
        if (Physics.Raycast(transform.position, InteractDirection, out hit, interactDistance, counterLayerMask))
        {
            //try to take ClearCounter type of Component
            if (hit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                //ClearCounter is

                //If true,than call function Interact
                //clearCounter.Interact();
                if (clearCounter != selectedCounter)
                {
                    SetSelectedCount(clearCounter);
                }
                
            }
            else
            {
                SetSelectedCount(null);
            }

        }
        else
        {
            SetSelectedCount(null);
        }
        Debug.Log(selectedCounter);
    }

    //Counters
    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNorm();
        Vector3 movementDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        float playerRadius = .6f;
        float playerHeight = 2.2f;
        float moveDist = Speed * Time.deltaTime; //���������(�������� + ���)

        //Collision Detection
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, movementDirection, moveDist);

        if (!canMove)
        {
            //Cannot move towards MoveDir
            Vector3 moveDirX = new Vector3(movementDirection.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDist);

            if (canMove)
            {
                //Can move only on X axis
                movementDirection = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, movementDirection.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDist);

                if (canMove)
                {
                    //Only on Z
                    movementDirection = moveDirZ;
                }
                else
                {
                    //Cannot move in any dir
                }
            }
        }

        if (canMove)
        {
            transform.position += movementDirection * moveDist;
        }


        //Character Rotation
        isWalking = movementDirection != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward, movementDirection, Time.deltaTime * rotationSpeed);
    }

    private void SetSelectedCount(ClearCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCountChangedEventArgs
        {
            selectedCounter = selectedCounter
        });
    }

}
