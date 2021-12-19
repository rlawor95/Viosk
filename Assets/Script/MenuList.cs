using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MenuType
{
    Recommend, Limited, Set, BurgerOnly, Side
}

public enum Mode
{
    BIG, SMALL
}

public class MenuList : MonoBehaviour
{
    public Mode CurrentMode;   // false 50 이하, true 50 이상 
    public static MenuList Instance = null;

    public MenuObject SmallmenuObject;
    public MenuObject BigmenuObject;
    public GameObject SmallContent;
    public GameObject BigContent;

    public ScrollRect _scrollRect;

    public RectTransform RedLine;
    public RectTransform[] CategoryTxt;

    public MenuDatabase menuDB;

    public Dictionary<string, MenuDatabase.DBEntry[]> MenuDic = new Dictionary<string, MenuDatabase.DBEntry[]>();


    List<MenuObject> SmallmenuobjPoolingList = new List<MenuObject>();
    List<MenuObject> BigmenuobjPoolingList = new List<MenuObject>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        foreach (var item in menuDB.MenuCategory)
        {
            MenuDic.Add(item.CategoryName, item.MenuArray);
        }

         for (int i = 0; i < 15; i++)
        {
            var go = Instantiate(SmallmenuObject.gameObject).GetComponent<MenuObject>();
            go.gameObject.SetActive(false);
            go.transform.parent = SmallContent.transform;
            SmallmenuobjPoolingList.Add(go);
        }

        for (int i = 0; i < 15; i++)
        {
            var go = Instantiate(BigmenuObject.gameObject).GetComponent<MenuObject>();
            go.gameObject.SetActive(false);
            go.transform.parent = BigContent.transform;
            BigmenuobjPoolingList.Add(go);
        }
    }

    public void SetMode(Mode m)
    {
        this.CurrentMode = m;
        if (m == Mode.BIG)   // 50대 이상
        {
            SmallContent.SetActive(false);
            BigContent.SetActive(true);
            _scrollRect.content = BigContent.GetComponent<RectTransform>();
        }
        else // 50대 이하
        {
            SmallContent.SetActive(true);
            BigContent.SetActive(false);
            _scrollRect.content = SmallContent.GetComponent<RectTransform>();
        }

         OpenMenu(MenuType.Recommend);
    }


    void Start()
    {
       
    }

    public void CategoryBtnClickEvent(int type)
    {
        OpenMenu((MenuType)type);

        RedLine.anchoredPosition = new Vector2(CategoryTxt[type].anchoredPosition.x, RedLine.anchoredPosition.y);

        foreach(var item in CategoryTxt)
        {
            item.GetComponent<Text>().color = Color.black;
        }

        CategoryTxt[type].GetComponent<Text>().color = Color.red;
    }


    public void OpenMenu(MenuType type)
    {
        DisableObjects();

        switch (type)
        {
            case MenuType.Recommend:
                foreach (var item in MenuDic["Recommend"])
                {
                    var go = ReturnObjFromPooling();
                    var _sprite = CurrentMode == Mode.BIG ? item.bigSprite : item.smallSprite;
                    go.SetInfo(item.Name, item.Price, _sprite);
                }
                break;
            case MenuType.Limited://Limited
                foreach (var item in MenuDic["Limited"])
                {
                    var go = ReturnObjFromPooling();
                    var _sprite = CurrentMode == Mode.BIG ? item.bigSprite : item.smallSprite;
                    go.SetInfo(item.Name, item.Price, _sprite);
                }
                break;
            case MenuType.Set:
                foreach (var item in MenuDic["Set"])
                {
                    var go = ReturnObjFromPooling();
                    var _sprite = CurrentMode == Mode.BIG ? item.bigSprite : item.smallSprite;
                    go.SetInfo(item.Name, item.Price, _sprite);
                }
                break;
            case MenuType.BurgerOnly:

                foreach (var item in MenuDic["BurgerOnly"])
                {
                    var go = ReturnObjFromPooling();
                    var _sprite = CurrentMode == Mode.BIG ? item.bigSprite : item.smallSprite;
                    go.SetInfo(item.Name, item.Price, _sprite);
                }
                break;
            case MenuType.Side:
                foreach (var item in MenuDic["Side"])
                {
                    var go = ReturnObjFromPooling();
                    var _sprite = CurrentMode == Mode.BIG ? item.bigSprite : item.smallSprite;
                    go.SetInfo(item.Name, item.Price, _sprite);
                }
                break;
        }
    }

    void DisableObjects()
    {
        foreach (var item in SmallmenuobjPoolingList)
        {
            item.gameObject.SetActive(false);
        }
        foreach (var item in BigmenuobjPoolingList)
        {
            item.gameObject.SetActive(false);
        }
    }

    MenuObject ReturnObjFromPooling()
    {
        if (CurrentMode == Mode.SMALL)
        {
            foreach (var item in SmallmenuobjPoolingList)
            {
                if (item.gameObject.activeSelf == false)
                {
                    item.gameObject.SetActive(true);
                    return item;
                }
            }
        }
        else
        {
            foreach (var item in BigmenuobjPoolingList)
            {
                if (item.gameObject.activeSelf == false)
                {
                    item.gameObject.SetActive(true);
                    return item;
                }
            }
        }
       

        Debug.LogError("Pooling Error");
        return null;
    }
}
