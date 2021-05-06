using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item _item;
    public override void Interact()
    {
        if(Input.GetKey(KeyCode.E)){
             PickUp();
        }
        base.Interact();
    }
    private void PickUp(){
        bool wasPickedUp = GameManagerRPG.current.Inventory.Add(_item);
        if(wasPickedUp)
        Destroy(gameObject);
    }
}
