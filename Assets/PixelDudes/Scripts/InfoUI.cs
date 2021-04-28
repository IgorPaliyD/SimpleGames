using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InfoUI : MonoBehaviour
{
    [SerializeField]private TMP_Text _collectableCountText;
    [SerializeField]private Image _timerFillImage;
    [SerializeField]private GameObject _loseWindow;
    [SerializeField]private GameObject _winWindow;

    private void Awake() {
        GameMaster.InializeUi(this);
    }
    private void Update() {  
    }
    public void SetCollectableCount(float count){
        _collectableCountText.text = string.Format("Collected: {0}",count);
    }
    public void ShowFinalWindow(){
        if(GameMaster.IsPlayerWins()) _winWindow.SetActive(true);
        if(!GameMaster.IsPlayerWins())_loseWindow.SetActive(true);
    }
}
