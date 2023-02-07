using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class DummyInfo
{
    public string name;
    public int id;
    public Sprite sprite;
    public Color color;
}
[System.Serializable]
public class Data { 
    public List<DummyInfo> listOfDummy = new List<DummyInfo>();    
}
public class ScreenThree : UIPage
{
    [SerializeField] TextMeshProUGUI information;
    [SerializeField] GameObject dummy;
    [SerializeField] RectTransform dummyContainer;

    [SerializeField] List<DummyInfo> dummyList;
    Data _data = new Data();
    public override void Init()
    {
        base.Init();
        UpdateObjectCountOnUI();
    }
    public void OnAddButtonTap(int dummyId)
    {
        DummyInfo _dummyData = dummyList.Find(d => d.id == dummyId);
        if (_dummyData != null)
        {
            _uiManager.DisplayAddObjectConfirmation(() => {
                GameObject dummyObj = Instantiate(dummy, dummyContainer);
                Dummy d = dummyObj.GetComponent<Dummy>();
                d.SetInformation(_dummyData, () => {
                    _data.listOfDummy.Remove(_dummyData);
                    UpdateObjectCountOnUI();
                });
                _data.listOfDummy.Add(_dummyData);
                UpdateObjectCountOnUI();
            });            
        }
    }
    void UpdateObjectCountOnUI() 
    {
        information.text = $"You have added {_data.listOfDummy.Count} Dummy(s)";
    }
    public override void DeInit()
    {
        base.DeInit();
        information.text = string.Empty;
    }
    public override void SaveJsonFile()
    {        
        data = JsonUtility.ToJson(_data);        
        path = Application.persistentDataPath + "/DummyObjectLists.json";

        base.SaveJsonFile();
    }
}//ScreenThree class end.
