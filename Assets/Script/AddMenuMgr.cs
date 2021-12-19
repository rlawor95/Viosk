using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMenuMgr : MonoBehaviour
{
     public static AddMenuMgr Instance = null;

    public GameObject Panel;
    public Image SelectionMenuImage;
    public Text SelectionMenuNameTxt;
    public Text SelectionMenuPriceTxt;

    private int _selectionPrice;

    public GameObject AddMenuPrefab;

    public GameObject GradiantContent;
    public GameObject FryContent;
    public GameObject DrinkContent;
    public GameObject SauceContent;
    public GameObject SizeContent;


    public Text TotalPriceTxt;

    int curPrice = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        AddMenuPrefab.SetActive(false);
    }

    void Start()
    {
        AddMenuLoad("Gradiant", GradiantContent.transform);
        AddMenuLoad("Fry", FryContent.transform);
        AddMenuLoad("Drink", DrinkContent.transform);
        AddMenuLoad("Sauce", SauceContent.transform);
        AddMenuLoad("Size", SizeContent.transform);
    }

    void AddMenuLoad(string key, Transform content)
    {
        foreach (var item in MenuList.Instance.MenuDic[key])
        {
            var go = Instantiate(AddMenuPrefab).GetComponent<AddMenuObject>();
            string name = item.Name + "\n" + "+" + item.Price.ToString();
            go.SetInfo(name, item.Price, item.smallSprite);
            go.transform.parent = content.transform;
            go.gameObject.SetActive(true);
        }
    }

    public void CheckingAdditionMenu(bool b, int price)
    {
        if (b)
        {
            curPrice += price;
        }
        else
        {
            curPrice -= price;
        }

        TotalPriceTxt.text = curPrice.ToString() + "원";
    }

    public void Init(Sprite _sprite, string name, int price)
    {
        Panel.gameObject.SetActive(true);
        SelectionMenuImage.sprite = _sprite;
        SelectionMenuNameTxt.text = name;
        SelectionMenuPriceTxt.text = price.ToString()+"원";

        TotalPriceTxt.text = SelectionMenuPriceTxt.text;
        curPrice = price;

    }

    public void OkBtnClickEvent()
    {
        OrderInfo _info = new OrderInfo();
        _info.name = SelectionMenuNameTxt.text;
        _info.price = curPrice;
        OrderedList.Instance.AddOrder(_info);
        Panel.SetActive(false);
    }

}
