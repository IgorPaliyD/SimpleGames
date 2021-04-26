using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField]private GameMaster _master;
    [SerializeField]private GameObject[] _prefab;
    [SerializeField] private float _spawnRate = 2f;

   private float _randX;
   private Vector2 _whereToSpawn;

   private float _nextSpawn=0.0f;
   
   
   public Transform LeftDownAnchor;
   public Transform RightUpAnchor;

   
    private void Spawn(){
        Random rand = new Random();
        var i = rand.Next(0,_prefab.Length);
        var x = rand.Next((int)LeftDownAnchor.position.x,(int)RightUpAnchor.position.x);
        Vector3 variables = new Vector3 ((float)x,LeftDownAnchor.position.y,0);
        GameObject _object = Instantiate(_prefab[i],variables,new Quaternion(0,0,0,0));
        //StartCoroutine(SpawnCoroutine(rand.Next()));
    }
    private void Update() {
        if(_master.IsTime()){
            if(Time.time > _nextSpawn){
            _nextSpawn = Time.time + _spawnRate;
            Spawn();
            _master.DecreaseTime();
        }
        }
        
        
        
    }
    IEnumerator SpawnCoroutine(int seed){
        Debug.Log("spawn");
        Random rand = new Random(seed);
        
        yield return new WaitForSecondsRealtime(2f);
    }
}

