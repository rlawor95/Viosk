using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomBtn : MonoBehaviour
{
    public int ID;
    public bool IsSelected = false;

    public Sprite NormalImage;
    public Sprite SelectionImage;

    Image _img;

    void Start()
    {
        EventMgr.Instance.ClickEvent += ReceiveClickEvent;

        _img = GetComponent<Image>();
        SetSprite();
        
    }

    public void BtnClickEvent()
    {
        if(IsSelected)
        {
            IsSelected =false;
            SetSprite();
        }
        else
        {
             EventMgr.Instance.InvokeClickEvent(ID);
             IsSelected = true;
             SetSprite();
        }
       
    }

    //어떤 버튼에 클릭이 들어오면 모든 버 
    void ReceiveClickEvent(int id)
    {
        if (id != this.ID)
            return;

        IsSelected = false;
        SetSprite();
    }

    void SetSprite()
    {
        if (IsSelected)
            _img.sprite = SelectionImage;
        else
            _img.sprite = NormalImage;
    }
}
