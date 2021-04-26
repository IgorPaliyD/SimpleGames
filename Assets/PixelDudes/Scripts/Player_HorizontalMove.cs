using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HorizontalMove : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D _rb;

    [Header("Movement Variables")]
    [SerializeField]private float _movementAcceleration;
    [SerializeField]private float _maxMoveSpeed;
    [SerializeField]private float _linearDrag;

    [SerializeField]private PlayerAnimator _playerAnim;
    private float _horizontalDirection;
    private bool _changingDirection => (_rb.velocity.x>0f && _horizontalDirection<0f || _rb.velocity.x<0f && _horizontalDirection>0f);

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        _horizontalDirection = GetInput().x;
        _playerAnim.Animate(_horizontalDirection);

    }
    private void FixedUpdate() {
        MoveCharacter();
        ApplyLinearDrag();        
    }


    private Vector2 GetInput(){
        return new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
    }

    private void MoveCharacter(){
        _rb.AddForce(new Vector2(_horizontalDirection,0f)*_movementAcceleration);
        if(Mathf.Abs(_rb.velocity.x)>_maxMoveSpeed)
        _rb.velocity = new Vector2(Mathf.Sign(_rb.velocity.x)*_maxMoveSpeed,_rb.velocity.y);

    }
    private void ApplyLinearDrag(){
        if(Mathf.Abs(_horizontalDirection)<0.4f||_changingDirection){
            _rb.drag = _linearDrag;
        }
        else{
             _rb.drag = 0f;
        }
    }
}
