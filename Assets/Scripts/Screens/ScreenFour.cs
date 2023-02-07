using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenFour : UIPage
{
    [SerializeField] TextMeshProUGUI information;
    private Action callBack;
    public override void Init()
    {
        base.Init();
        this.information.text = "This is Generic Information PopUp!!\nOnce User Tap on Save or delete Button this will come in Picture.";
    }
    public void SetInformation(string information, Action callBack) 
    {
        this.information.text = information;
        this.callBack = callBack;
    }

    public void OnYesButtonClicked() 
    { 
        this.callBack?.Invoke();
        HidePage();
    }
    public override void DeInit()
    {
        base.DeInit();
        this.callBack = null;
    }
}//ScreenFour class end
