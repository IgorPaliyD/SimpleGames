using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class PlayerCollect : MonoBehaviour
{
    private UnityEvent _event;

    private void Start() {
  
    }

   private void OnTriggerEnter2D(Collider2D other) {
       if(!other.gameObject.CompareTag("Collectable")) return;
        GameMaster.IncreaseCollectableCount();
        Destroy(other.gameObject);
   }

    

   
}
