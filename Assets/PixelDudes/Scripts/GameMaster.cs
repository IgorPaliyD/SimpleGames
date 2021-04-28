using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
public class GameMaster : MonoBehaviour
{
    static GameMaster current;
    //Private fields
    private float _collectableCount;
    private bool isWin=false;

    [Header("Timers")]
    private float _maxGameTime;
    private float _totalGameTime;
    private float _currentSessiontime;
    private bool _isGameStarted=false;

    //CustomComponents
    private InfoUI _ui;
    private CollectableSpawner _spawner;

    //Serialize Fields
    [SerializeField]private float _roundTime;
    
    [SerializeField]private float _mustBeCollected=5;

    //Events
    [HideInInspector]public static UnityEvent onTimerStart;
    [HideInInspector]public static UnityEvent onTimeOut;

    private void Awake() {
        if (current != null && current != this)
		{
			//...destroy this and exit. There can only be one Game Manager
			Destroy(gameObject);
			return;
		}

		current = this;
        StartGame();
    }

    //Field setters 
    public static void InializeUi(InfoUI ui){
        if (current == null)
			return;

		
        current._ui= ui;
    }
    public static void InitializeSpawner(CollectableSpawner spawner){
        current._spawner = spawner;
    }
    private void FixedUpdate() {
        
    }
    private void Update() {
        if(Input.GetKey(KeyCode.R)){
            SceneManager.LoadScene(0);
        }
        CountTime();
        
    }
    private static void CountTime(){
        if(!current._isGameStarted) return;
        if(!IsTime()){
//            onTimeOut.Invoke();
        }
        if(current._roundTime>0){
            current._roundTime -=Time.deltaTime;
        }
    }
    // public static void SaveMaxTime(){
    //     if(current._maxGameTime>current._currentSessiontime) return;
    //    current._maxGameTime=current._currentSessiontime;
    // }
    // public void CountTotalGameTime(){
        
    // }
    public static void StartGame(){
        current._isGameStarted = true;
    }
    // public static void IncreaseCurrentSessiontime(){
    //    current._currentSessiontime++;
    // }
    public static void IncreaseCollectableCount(){
        current._collectableCount++;
        current._ui.SetCollectableCount(current._collectableCount);
    }
    public static float GetCollectableCount(){
        return current._collectableCount;
    }
    
    public static void DecreaseTime(){
        current._roundTime--;
    }
    public static bool IsTime(){
        return current._roundTime>0?true:false;
    }
    public static bool IsPlayerWins(){
        return current._collectableCount==current._mustBeCollected?true:false;
    }

    public static void SetListenerOnTimeOut(Action action){
        
    }
}
