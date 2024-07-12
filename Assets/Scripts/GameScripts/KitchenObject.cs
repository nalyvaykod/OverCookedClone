using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        //Clear Counter from old Objects
        if(this.clearCounter != null) {
            this.clearCounter.ClearKitchenObject();
        }
        
        //Assign new Kitchen Object
        this.clearCounter = clearCounter;

        //If Counter Has an Object
        if(clearCounter.HasKitchenObject())
        {
            Debug.LogError("Has a Object");
        }

        clearCounter.SetKitchenObject(this);


        //Visual Update
        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    
    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}
