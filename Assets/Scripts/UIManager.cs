using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private List<UIPage> listOfPages;
    private void Awake()
    {
        if(Instance != null)
            Destroy(Instance);
        else
            Instance = this;
    }
    private void Start()
    {
        HideAllpages();
    }
    public void HideAllpages()
    {
        foreach (UIPage page in listOfPages)
        {
            if (page != null)
                page.HidePage();
        }
    }

    public void ShowPage(int pageId)
    {
        HideAllpages();
        if (listOfPages != null)
        {
            foreach (UIPage page in listOfPages)
            {
                if (page.pageId.Equals((UIPage.PageId)pageId))
                {
                    page.ShowPage();                    
                    break;
                }
            }
        }       
    }

    public UIPage GetPageById(UIPage.PageId pageId)
    {
        if (listOfPages != null) {
            return listOfPages.Find(page => page.pageId.Equals(pageId));
        }
        return null;
    }
    public void DisplaySaveFileConfirmationPopup(Action callback)
    {
        ScreenFour informationPage = GetPageById(UIPage.PageId.Screen4) as ScreenFour;
        informationPage.ShowPage();
        informationPage.SetInformation("Are You Sure You Want to save this Slected Option(s)?", callback);
    }
    public void DisplayDeleteObjectConfirmation(Action callback) 
    {
        ScreenFour informationPage = GetPageById(UIPage.PageId.Screen4) as ScreenFour;
        informationPage.ShowPage();
        informationPage.SetInformation("Are You Sure You Want to delete this Object?", callback);
    }
    public void DisplayAddObjectConfirmation(Action callback)
    {
        ScreenFour informationPage = GetPageById(UIPage.PageId.Screen4) as ScreenFour;
        informationPage.ShowPage();
        informationPage.SetInformation("Are You Sure You Want to Add this Object?", callback);
    }
}//UIManager class end.
