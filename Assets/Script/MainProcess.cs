using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainProcess : MonoBehaviour
{
    public GameObject Page1;
    public GameObject Page2; // 그냥 page2 임 
    public GameObject Page3;

    public void Over50_BtnClickEvent()
    {
        Page1.SetActive(false);
        Page2.SetActive(true);
        MenuList.Instance.SetMode(Mode.BIG);
    }

    public void Under50_BtnClickEvent()
    {
        Page1.SetActive(false);
        Page2.SetActive(true);
        MenuList.Instance.SetMode(Mode.SMALL);
    }

    public void ExitBtnClickEvent()
    {
        Page1.SetActive(true);
        Page2.SetActive(false);
    }

    public void PaymentClickEvent()
    {

    }
}
