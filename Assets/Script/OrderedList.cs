using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderedList : MonoBehaviour
{
    public static OrderedList Instance = null;

    public Stack<OrderInfo> _stackOrderRight = new Stack<OrderInfo>();
    public Stack<OrderInfo> _stackOrderLeft = new Stack<OrderInfo>();

    public Queue<OrderInfo> _queueNewOrder = new Queue<OrderInfo>();

    public OrderObject _orderObject1;
    public OrderObject _orderObject2;

    int orderCount = 0; // 주문 할 때마다 카운트를 올리고 주문했을떄의 카운터가 그 주문의 ID

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void AddOrder(OrderInfo order)
    {
        order.ID = orderCount;
        orderCount += 1;

        if (_orderObject1.gameObject.activeSelf == false)
        {
            _orderObject1.gameObject.SetActive(true);
            _orderObject1.SetInfo(order);
        }
        else if (_orderObject2.gameObject.activeSelf == false)
        {
            _orderObject2.gameObject.SetActive(true);
            _orderObject2.SetInfo(order);
        }
        else
        {
            _queueNewOrder.Enqueue(order);
        }

        Debug.Log("order _queueOrderRight count" + _queueNewOrder.Count);
    }



    public void RemoveOrder(OrderInfo info)
    {
        //왼쪽 삭제
        if (_orderObject1._info.ID == info.ID)
        {
            if (_orderObject2.gameObject.activeSelf == false)
            {
                _orderObject1.gameObject.SetActive(false);
                return;
            }
            _orderObject1.SetInfo(_orderObject2.GetInfo());

            if (_stackOrderRight.Count == 0)
            {
                if (_queueNewOrder.Count == 0)
                {
                    _orderObject2.gameObject.SetActive(false);
                }
                else
                {
                    var _newdata = _queueNewOrder.Dequeue();
                    _orderObject2.SetInfo(_newdata);
                }
            }
            else
            {
                var newdata = _stackOrderRight.Pop();
                _orderObject2.SetInfo(newdata);
            }
        }
        //오른쪽 삭제
        else if (_orderObject2._info.ID == info.ID)
        {
            if (_stackOrderRight.Count == 0)
            {
                if (_queueNewOrder.Count == 0)
                {
                    _orderObject2.gameObject.SetActive(false);
                }
                else
                {
                    var _newdata = _queueNewOrder.Dequeue();
                    _orderObject2.SetInfo(_newdata);
                }
            }
            else
            {
                var newdata = _stackOrderRight.Pop();
                _orderObject2.SetInfo(newdata);
            }
        }
    }

    public void LeftArrowBtnClickEvent()
    {
        if (_stackOrderLeft.Count == 0)
            return;

        if (_orderObject2.gameObject.activeSelf == false)
        {
            _orderObject2.SetInfo(_orderObject1.GetInfo());
            _orderObject2.gameObject.SetActive(true);
        }
        else
        {
            //좌측스택에 데이터가 있다면 오른쪽 데이터를 우측스택로 넘기고
            _stackOrderRight.Push(_orderObject2.GetInfo());
            //왼쪽데이터를 오른쪽으로 넘기고 
            _orderObject2.SetInfo(_orderObject1.GetInfo());
        }

        //좌측스택에서 받아온 데이터를 왼쪽으로 
        var newdata = _stackOrderLeft.Pop();
        _orderObject1.SetInfo(newdata);
    }

    public void RightArrowBtnClickEvent()
    {
        if (_stackOrderRight.Count == 0)
        {
            if (_queueNewOrder.Count == 0)
                return;
            else
            {
                _stackOrderLeft.Push(_orderObject1.GetInfo());
                _orderObject1.SetInfo(_orderObject2.GetInfo());
                var _newdata = _queueNewOrder.Dequeue();
                _orderObject2.SetInfo(_newdata);
               
            }
             return;
        }

        //우측스택에 데이터가 있다면 왼쪽 데이터를 좌측스택로 넘기고 
        _stackOrderLeft.Push(_orderObject1.GetInfo());

        //오른쪽 데이터를 왼쪽으로 
        _orderObject1.SetInfo(_orderObject2.GetInfo());

        //우측스택 데이터를 오른쪽으로 
        var newdata = _stackOrderRight.Pop();
        _orderObject2.SetInfo(newdata);
    }
}
