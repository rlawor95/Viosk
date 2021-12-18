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

    public Dictionary<string, MenuDatabase.DBEntry[]> MenuDic = new Dictionary<string, MenuDatabase.DBEntry[]>();

    List<MenuObject> menuobjPoolingList = new List<MenuObject>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        foreach (var item in menuDB.MenuCategory)
        {
            MenuDic.Add(item.CategoryName, item.MenuArray);
            Debug.Log("key : " + item.CategoryName + "  value count : " + item.MenuArray.Length);
        }
    }

    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            var go = Instantiate(menuObject.gameObject).GetComponent<MenuObject>();
            go.gameObject.SetActive(false);
            go.transform.parent = Content.transform;
            menuobjPoolingList.Add(go);
        }


        OpenMenu(MenuType.Recommend);
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
                    go.SetInfo(item.Name, item.Price);
                }
                break;
        }
    }

    void DisableObjects()
    {
         foreach (var item in menuobjPoolingList)
         {
             item.gameObject.SetActive(false);
         }
    }

    MenuObject ReturnObjFromPooling()
    {
        foreach (var item in menuobjPoolingList)
        {
            if (item.gameObject.activeSelf == false)
            {
                item.gameObject.SetActive(true);
                return item;
            }
        }

        Debug.LogError("Pooling Error");
        return null;
    }
}
