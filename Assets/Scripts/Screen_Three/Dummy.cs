
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Dummy : MonoBehaviour
{
    private UIManager _uiManager;
    private Action OnDeleteCallback;
    [SerializeField] Image img;

    private void Start()
    {
        if(_uiManager == null)
            _uiManager = UIManager.Instance;        
    }
   
    public void OnDeleteButtonTap() 
    {
        _uiManager.DisplayDeleteObjectConfirmation(() => {
            this.OnDeleteCallback?.Invoke();
            Destroy(gameObject);
        });
    }

    public void SetInformation(DummyInfo info, Action OnDeleteCallback) 
    {
        this.OnDeleteCallback = OnDeleteCallback;

        this.gameObject.name = info.name;

        if (img == null)
            img = GetComponent<Image>();

        img.sprite = info.sprite;
        img.color = info.color;
    }
}//Dummy class end
