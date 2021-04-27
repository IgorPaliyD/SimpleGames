using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class PlayerCollect : MonoBehaviour
{
    public TMP_Text _countText;
    private UnityEvent _event;

    private void Start() {
  
    }

   private void OnTriggerEnter2D(Collider2D other) {
       if(!other.gameObject.CompareTag("Collectable")) return;
        GameMaster.IncreaseCollectableCount();
        SetCount();
        Destroy(other.gameObject);
   }

    private void SetCount(){
        _countText.text= string.Format("Collected: {0}", GameMaster.GetCollectableCount());
    }

   
}
