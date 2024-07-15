using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter {

    [SerializeField] private KitchenObjectSO kitchenObjectSO;



    public override void Interact(Player player) 
    {
        if (!HasKitchenObject())
        {
            //No KitchenOBJ
            if (player.HasKitchenObject())
            {
                // Player have something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } 
            else
            {
                //Player has nothing
            }
        }
        else
        {
            //Is KitchenOBJ
            if (player.HasKitchenObject())
            {
                //Player carrying smth
            }
            else
            {
                //Player not carrying smth
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
