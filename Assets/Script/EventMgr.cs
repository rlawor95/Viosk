using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMgr : MonoBehaviour
{
    public static EventMgr Instance = null;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public delegate void ClickDelegate(int id);
    public ClickDelegate ClickEvent;
    
    public void InvokeClickEvent(int id)
    {
        ClickEvent?.Invoke(id);
    }

}
