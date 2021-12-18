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
        }

        OpenMenu(MenuType.Recommend);
    }

    public void OpenMenu(MenuType type)
    {
        switch (type)
        {
            case MenuType.Recommend:
                int cnt = 5;
                for (int i = 0; i < cnt; i++)
                {
                    
                }
                break;
        }
    }
}
