using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject InteractionMessage;
    [SerializeField]private float _interactionRadius=3f;
    private bool _canInteract = false;
    private Transform _playerTransform;


    public virtual void Interact(){
       
    }
    private void Update() {
        if(_canInteract){
            float distance = Vector2.Distance(transform.position,_playerTransform.position);
            Debug.Log(distance);
            if(distance<_interactionRadius){
            ShowMessage();
            Interact();
        }
        else{
            HideMessage();
        }
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(!other.CompareTag("Player")){
             _canInteract = false;
             return;
        } 
        _canInteract = true;
        _playerTransform = other.transform;
    }
    private void ShowMessage(){
         InteractionMessage.SetActive(true);
    }
    private void HideMessage(){
   InteractionMessage.SetActive(false);
    }
}
