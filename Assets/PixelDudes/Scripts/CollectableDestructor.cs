using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableDestructor : MonoBehaviour
{
    [SerializeField]private float _timeToDestroy=0.5f;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")) StartCoroutine("Destroy");
    }
    IEnumerator Destroy(){
        yield return new WaitForSecondsRealtime(_timeToDestroy);
        Destroy(this.gameObject);
    }
}
