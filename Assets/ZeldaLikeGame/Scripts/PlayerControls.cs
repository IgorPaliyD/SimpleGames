using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControls : MonoBehaviour
{
    private Player _player;
    private PlayerAnimations _playerAnimations;
    [SerializeField] private LayerMask _dashLayerMask;
    [SerializeField] private float _moveSpeed = 60f;
    [SerializeField] private float _dashAmount = 50f;
    private Rigidbody2D _rigidbody;
    private Vector3 _moveDirection;
    private bool _isDashButtonDown;
    private void Start(){
         _playerAnimations = _playerAnimations == null ? GetComponent<PlayerAnimations>() : _playerAnimations;
        if(_playerAnimations == null){
            Debug.LogError("PlayerAnimation not set to controls");
        }
    //    _player = _player == null ? GetComponent<Player>() : _player;
    //     if(_player == null){
    //         Debug.LogError("Player not set to controls");
    //     }
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update(){
        float moveX = 0f;
        float moveY = 0f;
      if(Input.GetKey(KeyCode.W)){
          moveY=+1f;
          Debug.Log("here");
      }
      if(Input.GetKey(KeyCode.S)){
          moveY=-1f;
      }
      if(Input.GetKey(KeyCode.A)){
          moveX=-1f;
      }
      if(Input.GetKey(KeyCode.D)){
          moveX=+1f;
      }

      _moveDirection = new Vector3(moveX,moveY).normalized;
      _playerAnimations.PlayWalkAimation(_moveDirection);

      if(Input.GetKeyDown(KeyCode.Space)){
          _isDashButtonDown = true;
      }
    } 
    private void FixedUpdate(){
        _rigidbody.velocity = _moveDirection * _moveSpeed;

        if(_isDashButtonDown){
            Vector3 dashPosition = transform.position + _moveDirection*_dashAmount;
           RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position,_moveDirection,_dashAmount,_dashLayerMask);
           if(raycastHit2D.collider!=null){
               dashPosition=raycastHit2D.point;
           }
           _rigidbody.MovePosition(dashPosition);
            _isDashButtonDown = false;
        }
    }
}
