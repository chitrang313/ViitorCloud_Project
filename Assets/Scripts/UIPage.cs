using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UIPage : MonoBehaviour
{
    protected UIManager _uiManager;

    protected string path;
    protected string data;
    public enum PageId
    {
        None = 0,
        Screen1 = 1,
        Screen2 = 2,
        Screen3 = 3,
        Screen4 = 4,
    }

    public PageId pageId;

    public virtual void Init() 
    { 
        if(_uiManager == null)
            _uiManager = UIManager.Instance;
    }

    public virtual void DeInit() { }

    public virtual void HidePage()
    {
        DeInit();
        this.gameObject.SetActive(false);
    }

    public void ShowPage()
    {
        Init();
        this.gameObject.SetActive(true);
    }
    
    public virtual void SaveJsonFile() 
    {
        _uiManager.DisplaySaveFileConfirmationPopup(() =>
        {
            //Save File once User Tap on Confirmation Button
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            System.IO.File.WriteAllText(path, data);
        });
    }
}//UIPage class end.
