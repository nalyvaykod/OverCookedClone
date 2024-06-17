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

        float playerSize = .6f;
        float playerHeight = 2.2f;
        float moveDist = Speed * Time.deltaTime;

        bool canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHeight,playerSize,movementDirection, moveDist);

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
