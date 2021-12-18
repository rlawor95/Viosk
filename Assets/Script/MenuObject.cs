using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct OrderInfo
{
    public int ID;
    public string name;
    public int price;
}

public class MenuObject : MonoBehaviour
{
    public Button UGUI_btn;
    public Image UGUI_MenuImg;
    public Text UGUI_nameText;
    public Text UGUI_priceText;

    [Space(20)]

    public OrderInfo _info;

    void Start()
    {

    }

    public void SetInfo(string _name, int _price, Sprite _icon = null)
    {
        _info = new OrderInfo();
        UGUI_nameText.text = _name;
        UGUI_priceText.text = _price.ToString() + "원";
        if (_icon != null)
        {
            UGUI_MenuImg.sprite = _icon;
        }

        _info.name = _name;
        _info.price = _price;
    }

    public void BtnClickEvent()
    {
        OrderedList.Instance.AddOrder(_info);
    }

}
