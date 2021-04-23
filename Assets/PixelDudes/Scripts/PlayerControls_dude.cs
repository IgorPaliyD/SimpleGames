using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls_dude : MonoBehaviour
{
    // [SerializeField]private float _movementSpeed;
    // [SerializeField]private float maxHorizontalMovementSpeed;
    // private Rigidbody2D _rigidbody;

    // private void Start(){
    //     _rigidbody= GetComponent<Rigidbody2D>();
    // }
    private Player_dude _Dude;

    private void SetPlayer(){
        if(_Dude) return;
        if(TryGetComponent(out Player_dude player)){
            _Dude=player;
            return;
        }
        Debug.LogError("No Player_dude script");
    }
    private void Start(){
        SetPlayer();
    }
    private void Update(){
        float vertical = 0;
        float horizontal;
        if(Input.GetKey(KeyCode.W)){
            vertical +=1;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        
        _Dude.MovePlayerHorizontal(horizontal);
        _Dude.Jump(vertical);
    }
}
