using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake(){
        current = this;
    }
    public event Action onItemTriggerEnter;
    public void ItemTriggerEnter(){
        if(onItemTriggerEnter!=null){
            onItemTriggerEnter();
        }
    } 
}
