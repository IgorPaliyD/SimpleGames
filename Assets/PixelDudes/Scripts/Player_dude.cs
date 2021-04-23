using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Player_dude : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private MoveState _lastState = MoveState.Idle;
    private float _walkTime, _walkCooldown = 0.1f;
    private Transform _transform;
    private DirectionState _directionState = DirectionState.Right;
    [SerializeField]private Animator _animator;
    [SerializeField]private float _moveSpeed,_jumpforce;
    [SerializeField]private AnimationNames _animations;
    [SerializeField]private bool _canMoveInAir = true;
    
    private void Start(){
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }
    private void Update(){
            if(_rigidbody.velocity==Vector2.zero){
                Idle();
            }
            Debug.Log(_lastState);
    }
    private void FixedUpdate(){
        if(_lastState == MoveState.Walk){
            _rigidbody.velocity = ((_directionState == DirectionState.Right?Vector2.right:-Vector2.right)*_moveSpeed*Time.fixedDeltaTime);
       }
    }
    public void MovePlayerHorizontal(float h){
        if(h>0){
            WalkRight();
        }
        if(h<0){
            WalkLeft();
        }
    }
    public void WalkRight(){
        ChangeState(MoveState.Walk);
        if(_directionState==DirectionState.Left){
            _transform.localScale = new Vector3(-_transform.localScale.x,_transform.localScale.y,transform.localScale.z);
            _directionState = DirectionState.Right;
        }
        PlayAnimation();
    }
    private void WalkLeft(){
         if(_directionState==DirectionState.Right){
            _transform.localScale = new Vector3(-_transform.localScale.x,_transform.localScale.y,transform.localScale.z);
            _directionState=DirectionState.Left;
        }
    }
    public void Jump(float v){
        if(v==0) return;
        ChangeState(MoveState.Jump);
        PlayAnimation();
    }
    private void ChangeState(MoveState state){
        if(_lastState==state)return;
        _lastState = state;
    }
    private void Idle(){
        
        ChangeState(MoveState.Idle);
        PlayAnimation();
    }

    private void PlayAnimation(){
        switch (_lastState)
        {
            case MoveState.Idle:
             _animator.Play(_animations.IdleAnim); 
            break;
            case MoveState.Walk:
            _animator.Play(_animations.WalkAnim);
            break;
            case MoveState.Jump:
            _animator.Play(_animations.JumpAnim);
            break;
            default: break;
        }            
        }



    enum DirectionState{
        Right,
        Left
    }
    enum MoveState{
        Jump,
        Walk,
        Idle
    }
    
    [System.Serializable]
    public class AnimationNames
    {
        public string JumpAnim, WalkAnim, IdleAnim; 
    }
    
}
