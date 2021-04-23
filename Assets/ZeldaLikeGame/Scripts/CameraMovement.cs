using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   [SerializeField] private Transform _target;
   [SerializeField] private float _smoothing=0.1f;

   private void LateUpdate(){
       if(transform.position!=_target.position){
           Vector3 targetPosition = new Vector3 (_target.position.x,_target.position.y,transform.position.z);  
           transform.position = Vector3.Lerp(transform.position,_target.position,_smoothing);
       }
   }
}
