using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerRPG : MonoBehaviour
{
    public static GameManagerRPG current;
    public Inventory Inventory=>_inventory;
    [SerializeField]private Inventory _inventory;
    
    private void Awake() {
        current = this;
    }
}
