using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderedList : MonoBehaviour
{
    public static OrderedList Instance = null;

    //public GameObject OrderObject;

    //public List<OrderInfo> _orderList = new List<OrderInfo>();

    public Queue<OrderInfo> _queueOrderRight = new Queue<OrderInfo>();
    public Queue<OrderInfo> _queueOrderLeft = new Queue<OrderInfo>();

    
    public OrderObject _orderObject1;
    public OrderObject _orderObject2;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void AddOrder(OrderInfo order)
    {
        if(_orderObject1.gameObject.activeSelf==false)
        {
            _orderObject1.gameObject.SetActive(true);
            _orderObject1.SetInfo(order);
        }
        else if(_orderObject2.gameObject.activeSelf==false)
        {
            _orderObject2.gameObject.SetActive(true);
            _orderObject2.SetInfo(order);
        }
        else
        {
            _queueOrderRight.Enqueue(order);
        }

        Debug.Log("order _queueOrderRight count" + _queueOrderRight.Count);
    }



    public void RemoveOrder(OrderInfo info)
    {
        //왼쪽 오브젝이 삭제라면, 오른쪽을 왼쪽으로 옮기고 right 큐에서 하나 받아옴

        // 오른쪽 오브젝이 삭제라면, right 큐에서 하나 받아옴.
    }

    public void LeftArrowBtnClickEvent()
    {

    }

    public void RightArrowBtnClickEvent()
    {
        
    }
}
