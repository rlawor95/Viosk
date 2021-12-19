using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainProcess : MonoBehaviour
{
    public GameObject Page1;
    public GameObject Page2_50Under;

    public void Over50_BtnClickEvent()
    {

    }

    public void Under50_BtnClickEvent()
    {
        Page1.SetActive(false);
        Page2_50Under.SetActive(true);
    }
}
