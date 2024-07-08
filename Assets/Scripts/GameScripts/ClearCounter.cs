using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private Transform tomatoPref;
    [SerializeField] private Transform vegetableTarget;

    public void Interact()
    {
        Debug.Log("Interact");
        Transform tomatoTransform = Instantiate(tomatoPref, vegetableTarget);
        tomatoTransform.localPosition = Vector3.zero;
    }
}
