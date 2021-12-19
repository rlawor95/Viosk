using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderedListObject : MonoBehaviour
{
    public Image Icon;
    public Text NameTxt;
    public Text ValueTxt;

    public int Price = 0;
    public int val = 0;


    public void SetInfo(Sprite _icon, string _name, int price)
    {
        Icon.sprite = _icon;
        NameTxt.text = _name;
        ValueTxt.text = "1";
        val = 1;
        Price = price;

        Icon.SetNativeSize();
    }

    public void PlusBtnClickEvent()
    {
        val += 1;
        ValueTxt.text = val.ToString();
        MainProcess.Instance.IncreaseCost(Price);

    }

    public void MinusBtnClickEvent()
    {
        if (val == 1)
            return;

        val -= 1;
        ValueTxt.text = val.ToString();
        MainProcess.Instance.DecreaseCost(Price);
    }
}
