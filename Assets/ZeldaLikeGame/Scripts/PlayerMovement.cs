using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float _speed;
   private Rigidbody2D _rigidbody;
    private Vector2 _change;
   private void Start(){
       _rigidbody = GetComponent<Rigidbody2D>();
   }
   private void Update(){}
}
