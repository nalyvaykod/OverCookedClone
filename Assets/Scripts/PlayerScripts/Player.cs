using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float Speed = 10f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    private void Update()
    {

        Vector2 inputVector = gameInput.GetMovementVectorNorm();
        Vector3 movementDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        float playerRadius = .6f;
        float playerHeight = 2.2f;
        float moveDist = Speed * Time.deltaTime; //���������(�������� + ���)

        //Collision Detection
        bool canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHeight,playerRadius,movementDirection, moveDist);

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
        transform.forward = Vector3.Slerp(transform.forward,movementDirection, Time.deltaTime * rotationSpeed);
        


    
    
    
    
    
    
    }

    //Animation
    public bool IsWalking()
    {
        return isWalking;
    }


}
