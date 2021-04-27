using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class GameMaster : MonoBehaviour
{
    static GameMaster current;
    private float _collectableCount;
    private bool isWin=false;

    [Header("Timers")]
    private float _maxGameTime;
    private float _totalGameTime;
    private float _currentSessiontime;
    [SerializeField]private float _roundTime;
    
    [SerializeField]private float _mustBeCollected=5;

    private void Awake() {
        if (current != null && current != this)
		{
			//...destroy this and exit. There can only be one Game Manager
			Destroy(gameObject);
			return;
		}

		//Set this as the current game manager
		current = this;
    }
    private void FixedUpdate() {
        
    }
    private void Update() {
        if(Input.GetKey(KeyCode.R)){
            SceneManager.LoadScene(0);
        }
    }
    public static void SaveMaxTime(){
        if(current._maxGameTime>current._currentSessiontime) return;
       current._maxGameTime=current._currentSessiontime;
    }
    public void CountTotalGameTime(){
        
    }
    public static void IncreaseCurrentSessiontime(){
       current._currentSessiontime++;
    }
    public static void IncreaseCollectableCount(){
        current._collectableCount++;
    }
    public static float GetCollectableCount(){
        return current._collectableCount;
    }
    
    public static void DecreaseTime(){
        current._roundTime--;
    }
    public static bool IsTime(){
        return current._roundTime==0?true:false;
    }
    public static bool IsPlayerWins(){
        return current._collectableCount==current._mustBeCollected?true:false;
    }
}
