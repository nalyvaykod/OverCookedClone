using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float Speed = 10f;
    [SerializeField] private float rotationSpeed = 10f;

    private bool isWalking;

    private void Update()
    {
        //Input 
        Vector2 inputVector = new Vector2(0, 0);

        if(Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;

        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;

        }

        //Move Character
        inputVector = inputVector.normalized;

        Vector3 movementDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        transform.position += movementDirection * Speed * Time.deltaTime;

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
