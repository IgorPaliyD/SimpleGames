using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private void Start(){
        _animator = GetComponent<Animator>();
    }

    public void PlayWalkAimation(Vector3 moveDirection){
        _animator.SetFloat("Horizontal",moveDirection.x);
        _animator.SetFloat("Vertical",moveDirection.y);
        _animator.SetFloat("Speed",moveDirection.sqrMagnitude);
    }
}


