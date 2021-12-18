using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuList : MonoBehaviour
{
    public enum MenuType
    {
        Recommend, Limited, Set, BugerOnly, Side
    }

    public static MenuList Instance = null;

    public MenuObject menuObject;
    public GameObject Content;

    public MenuDatabase menuDB;

    

    List<MenuObject> menuobjPoolingList = new List<MenuObject>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            var go = Instantiate(menuObject.gameObject).GetComponent<MenuObject>();
            go.gameObject.SetActive(false);
            go.transform.parent = Content.transform;
        }

        
        //OpenMenu(MenuType.Recommend);
    }

    public void OpenMenu(MenuType type)
    {
        switch (type)
        {
            case MenuType.Recommend:
                int cnt = 5;
                for (int i = 0; i < cnt; i++)
                {
                    //var item = ReturnObjFromPooling();
                    //item.SetInfo("추천"+(char)46+i, )
                }
                break;
        }
    }

    MenuObject ReturnObjFromPooling()
    {
        foreach (var item in menuobjPoolingList)
        {
            if (item.gameObject.activeSelf == false)
                return item;
        }

        Debug.LogError("Pooling Error");
        return null;    
    }
}
