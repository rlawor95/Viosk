using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainProcess : MonoBehaviour
{
    public static Mode curMode;
    public static MainProcess Instance = null;

    public GameObject Page1;
    public GameObject Page2; // 그냥 page2 임 
    public GameObject Page3;
    public GameObject Page4;
    public GameObject Page5;


    [Space(10)]
    [Header("Payment")]
    public GameObject PointPanel;
    public GameObject CreditPanel;
    public GameObject OrderedListPanel;
    public Transform orderedContent;
    public GameObject orderdPrefab;

    public Text OrderPriceTxt;
    public Text TotalPriceTxt;
    public Text TotalPriceTxt_credit;
    public Text TotalPriceTxt_point;

    public GameObject CartCircle;
    public Text CartNoticeCountTxt;

    public List<OrderedListObject> orderedList = new List<OrderedListObject>();

    //private Dictionary<string, OrderInfo>
     int totalprice=0;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Over50_BtnClickEvent()
    {
        Page1.SetActive(false);
        Page2.SetActive(true);
        MenuList.Instance.SetMode(Mode.BIG);
        curMode = Mode.BIG;
    }

    public void Under50_BtnClickEvent()
    {
        Page1.SetActive(false);
        Page2.SetActive(true);
        MenuList.Instance.SetMode(Mode.SMALL);
        curMode = Mode.SMALL;
    }

    public void ExitBtnClickEvent()
    {
        Page1.SetActive(true);
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(false);
        Page5.SetActive(false);
        totalprice = 0;

        foreach(var item in orderedList)
        {
            Destroy(item.gameObject);
        }
        orderedList.Clear();

        OrderedList.Instance.ClearData();
    }

    //page 2에서 결제버튼 
    public void PaymentPageInit(List<OrderInfo> _list)
    {
        Page2.SetActive(false);
        Page3.SetActive(true);

        if (curMode == Mode.BIG)
        {
            CreditPanel.SetActive(true);
            PointPanel.SetActive(false);
        }
        else
        {
            CreditPanel.SetActive(false);
            PointPanel.SetActive(true);
        }

        OrderedListPanel.SetActive(true);
        
        //////
        orderdPrefab.SetActive(false);

        // foreach(var item in _list)
        // {
        //     Debug.Log(item.name + " " + item.price + " " );
        //     foreach(var item2 in item.additionMenuList)
        //     {
        //         Debug.Log(item2.name + " " + item2.price + " " + item2.Icon.name);
        //     }
        // }

        int cnt=0;
        foreach (var item in _list)
        {
            var go = Instantiate(orderdPrefab).GetComponent<OrderedListObject>();
            go.SetInfo(item.img, item.name, item.originPrice);
            go.transform.parent = orderedContent;
            go.gameObject.SetActive(true);
            orderedList.Add(go);
            totalprice += item.price;
            cnt += 1;
            foreach (var addition in item.additionMenuList)
            {
                var addi = Instantiate(orderdPrefab).GetComponent<OrderedListObject>();
                addi.SetInfo(addition.Icon, addition.name, addition.price);
                addi.transform.parent = orderedContent;
                addi.gameObject.SetActive(true);
                orderedList.Add(addi);
            }
        }

        if(cnt>0)
        {
            CartCircle.SetActive(true);
            CartNoticeCountTxt.text = cnt.ToString();
        }
        else
        {
            CartCircle.SetActive(false);
        }

        OrderPriceTxt.text = totalprice.ToString() + "원";
        TotalPriceTxt.text = totalprice.ToString() + "원";
        TotalPriceTxt_credit.text = "\\" + totalprice.ToString() + "원";
        TotalPriceTxt_point.text = "\\" + totalprice.ToString() + "원";
    }

    public void CartBtnClickEvent()
    {
         OrderedListPanel.SetActive(true);
    }

    public void IncreaseCost(int cost)
    {
        totalprice += cost;
        OrderPriceTxt.text = totalprice.ToString() + "원";
        TotalPriceTxt.text = totalprice.ToString() + "원";
        TotalPriceTxt_credit.text = "\\" + totalprice.ToString() + "원";
        TotalPriceTxt_point.text = "\\" + totalprice.ToString() + "원";
    }

    public void DecreaseCost(int cost)
    {
        totalprice -= cost;
        OrderPriceTxt.text = totalprice.ToString() + "원";
        TotalPriceTxt.text = totalprice.ToString() + "원";
        TotalPriceTxt_credit.text = "\\" + totalprice.ToString() + "원";
        TotalPriceTxt_point.text = "\\" + totalprice.ToString() + "원";

    }

    public void CancelBtnClickEvent()
    {
        Page2.SetActive(true);
        Page3.SetActive(false);

        totalprice = 0;

        foreach(var item in orderedList)
        {
            Destroy(item.gameObject);
        }
        orderedList.Clear();
    }

    public void OkBtnClickEvent()
    {
        OrderedListPanel.SetActive(false);
    }

    public void OtherPaymentBtnClickEvent()
    {
        CreditPanel.SetActive(false);
        PointPanel.SetActive(true);
    }

    public void NextPageFromPage3()
    {
        Page3.SetActive(false);
        Page4.SetActive(true);
    }

    public void NextPageFromPage4()
    {
        //Page3.SetActive(false);
        Page4.SetActive(false);
        Page5.SetActive(true);
    }
}
