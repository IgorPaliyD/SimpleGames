using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour
{
    [SerializeField]private float _time;
    [SerializeField]private GameObject _loseImage,_winImage;


    public void ActiveteGameMonitor(bool t){
        if(!t){
            _loseImage.SetActive(true);
        }
        else{
            _winImage.SetActive(true);
        }
    }
    private void Update() {
        if(Input.GetKey(KeyCode.R)){
            SceneManager.LoadScene(0);
        }
    }
    public void DecreaseTime(){
        _time--;
    }
    public bool IsTime(){
        return _time==0?true:false;
    }
}
