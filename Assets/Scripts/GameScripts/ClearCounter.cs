using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO tomatoKitchenObjectSO;
    [SerializeField] private Transform vegetableTarget;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private KitchenObject kitchenObject;


    private void Update()
    {
        if(testing && Input.GetKeyDown(KeyCode.T))
        {
            if(kitchenObject != null)
            {
                kitchenObject.SetClearCounter(secondClearCounter);
            }
        }
    }

    public void Interact(Player player)
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(tomatoKitchenObjectSO.prefab, vegetableTarget);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);
        } else {
            //Give object to player
            kitchenObject.SetClearCounter(player);
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return vegetableTarget;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
