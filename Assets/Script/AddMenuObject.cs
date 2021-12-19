using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct AdditionMenu
{
    public Sprite Icon;
    public string name;
    public int price;


    public AdditionMenu(Sprite _icon, string _name, int _price)
    {
        this.Icon = _icon;
        this.name = _name;
        this.price = _price;
    }

}

public class AddMenuObject : MonoBehaviour
{
    public Image Icon;
    public Text infoTxt;
    public Image CheckImg;

    public AdditionMenu info;

    public int Price = 0;

    public void SetInfo(string _infoTxt, int price, Sprite _icon = null)
    {
        infoTxt.text = _infoTxt;
        if (_icon != null)
            Icon.sprite = _icon;

        Price = price;
    }

    public void SetInfo(AdditionMenu menu)
    {
        info = menu;
    }

    public void ClickEvent()
    {
        bool b = !CheckImg.gameObject.activeSelf;
        CheckImg.gameObject.SetActive(b);

        AddMenuMgr.Instance.CheckingAdditionMenu(b, info);
    }

    void OnDisable()
    {
        CheckImg.gameObject.SetActive(false);
    }
}
