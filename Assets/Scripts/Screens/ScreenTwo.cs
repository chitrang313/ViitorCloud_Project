using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Info 
{ 
    public string colorName = string.Empty;
    public List<ScreenTwo.Shape> shapeNames = new List<ScreenTwo.Shape>();
}
public class ScreenTwo : UIPage
{
    [SerializeField] private TextMeshProUGUI information;
    private Info info = new Info();
    public enum Color
    {
        Black = 0,
        Red = 1,
        Green = 2,
        Blue = 3,
        Yellow = 4,
    }

    public enum Shape
    {
        Circle = 0,
        Squre = 1,
        Triangle = 2,
        Rectangle = 3,
    }

    [SerializeField] Toggle RedOption, GreenOption, BlueOption, YellowOption;
    
    [SerializeField] Toggle CircleOption, SqureOption, TriangleOption, RectangleOption;

    public override void Init()
    {
        base.Init();
        ResetInfoText();

        RadioButtonAssignment();
        CheckBoxAssignment();
    }
    void RadioButtonAssignment()
    {
        RedOption.onValueChanged.AddListener((val) => {
            if (val)
                OnColorSelected(Color.Red);
        });
        GreenOption.onValueChanged.AddListener((val) => {
            if (val)
                OnColorSelected(Color.Green);
        });
        BlueOption.onValueChanged.AddListener((val) => {
            if (val)
                OnColorSelected(Color.Blue);
        });
        YellowOption.onValueChanged.AddListener((val) => {
            if (val)
                OnColorSelected(Color.Yellow);
        });
    }

    void CheckBoxAssignment()
    {
        CircleOption.onValueChanged.AddListener(val => {
            if (val)
                AddShape(Shape.Circle);
            else
                RemoveShapeFromList(Shape.Circle);
        });

        SqureOption.onValueChanged.AddListener(val => {
            if (val)
                AddShape(Shape.Squre);
            else
                RemoveShapeFromList(Shape.Squre);
        });

        TriangleOption.onValueChanged.AddListener(val => {
            if (val)
                AddShape(Shape.Triangle);
            else
                RemoveShapeFromList(Shape.Triangle);
        });

        RectangleOption.onValueChanged.AddListener(val => {
            if (val)
                AddShape(Shape.Rectangle);
            else
                RemoveShapeFromList(Shape.Rectangle);
        });
    }

    public void AddShape(Shape shape) 
    {        
        info.shapeNames.Add(shape);
        UpdateUi();
    }
    private void OnColorSelected(Color color) 
    {        
        info.colorName = color.ToString();
        UpdateUi();
    }
    private void ResetInfoText() { 
        information.text = string.Empty;    
    }
    private void UpdateUi() 
    {
        ResetInfoText();
        information.text += $"You have selected ";
        information.text += !string.IsNullOrEmpty(info.colorName) ? $"{info.colorName} Color " : string.Empty;
        information.text += info.shapeNames.Count > 0 && !string.IsNullOrEmpty(info.colorName) ? "& " : string.Empty;

        for (int i = 0; i < info.shapeNames.Count; i++)
        {
            information.text += $"{info.shapeNames[i]} ";
        }
    }
    private void RemoveShapeFromList(Shape shape) 
    {
        info.shapeNames.Remove(shape);
        UpdateUi();
    }
    public override void DeInit()
    {
        base.DeInit();

        RedOption.onValueChanged.RemoveAllListeners();
        GreenOption.onValueChanged.RemoveAllListeners(); 
        BlueOption.onValueChanged.RemoveAllListeners(); 
        YellowOption.onValueChanged.RemoveAllListeners();

        CircleOption.onValueChanged.RemoveAllListeners();
        SqureOption.onValueChanged.RemoveAllListeners();
        TriangleOption.onValueChanged.RemoveAllListeners();
        RectangleOption.onValueChanged.RemoveAllListeners();

        info.shapeNames.Clear();
    }

    public override void SaveJsonFile()
    {
        data = JsonUtility.ToJson(info);
        path = Application.persistentDataPath + "/ShapeAndColorData.json";

        base.SaveJsonFile();        
    }

}//ScreenTwo class end. 
