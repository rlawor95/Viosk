using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMenuObject : MonoBehaviour
{
    public Image Icon;
    public Text infoTxt;
    public Image CheckImg;


    public int Price = 0;

    public void SetInfo(string _infoTxt, int price, Sprite _icon = null)
    {
        infoTxt.text = _infoTxt;
        if (_icon != null)
            Icon.sprite = _icon;

        Price = price;
    }

    public void ClickEvent()
    {
        bool b = !CheckImg.gameObject.activeSelf;
        CheckImg.gameObject.SetActive(b);

        AddMenuMgr.Instance.CheckingAdditionMenu(b, Price);
    }

    void OnDisable()
    {
        CheckImg.gameObject.SetActive(false);
    }
}
