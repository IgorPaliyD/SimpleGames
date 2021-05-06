using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public List<Item> _itemList= new List<Item>();
   [SerializeField]private int _freeSpace=10;
   private void Awake() {
       
   }
   public bool Add(Item item){
       if(!item.IsDefaultItem){
           if(_itemList.Count>=_freeSpace){
                return false;
           }
           _itemList.Add(item);
       }
      return true;
   }
   public void Remove(Item item){
       _itemList.Remove(item);
   }
}
