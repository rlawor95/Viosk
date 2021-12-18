using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderObject : MonoBehaviour
{
    public Text UGUI_nameText;
    public Text UGUI_priceText;

    public OrderInfo _info;

    public void SetInfo(OrderInfo info)
    {
        UGUI_nameText.text = info.name;
        UGUI_priceText.text = info.price.ToString() + "원";
        _info = info;
    }

    public void RemoveClickEvent()
    {
        OrderedList.Instance.RemoveOrder(_info);
    }
}
