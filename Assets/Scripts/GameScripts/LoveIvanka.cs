using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveIvanka : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Duck says: I love Ivanka <3");
        }
    }

    
}
