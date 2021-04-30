using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpIteController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onItemTriggerEnter += OnItemPicked;
    }
    public void OnItemPicked(){
        
    }

   
}
