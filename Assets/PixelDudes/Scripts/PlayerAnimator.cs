using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]private string _runAnimation;
    private bool m_FacingRight = true;
    private Animator _animator;
    
    private void Start() {
        _animator = GetComponent<Animator>();
    }
    public void Animate(float dir){
        var a = Mathf.Abs(dir);
        if(dir > 0 && !m_FacingRight)
			{	
				Flip();
			}
			else if (dir < 0 && m_FacingRight)
			{
				Flip();
			}
            _animator.SetFloat("Speed",a);
    }
    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
