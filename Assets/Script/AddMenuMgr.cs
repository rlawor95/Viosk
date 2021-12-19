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
    int originPrice = 0;
    List<AddMenuObject> addMenuObjectList = new List<AddMenuObject>();

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
            
            AdditionMenu m = new AdditionMenu(item.smallSprite, item.Name, item.Price);
            go.SetInfo(m);

            go.transform.parent = content.transform;
            go.gameObject.SetActive(true);
            addMenuObjectList.Add(go);
        }
    }

    public void CheckingAdditionMenu(bool b, AdditionMenu menuInfo)
    {
        if (b)
        {
            curPrice += menuInfo.price;
    
        }
        else
        {
            curPrice -= menuInfo.price;
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
        originPrice = price;
    }

    public void OkBtnClickEvent()
    {
        OrderInfo _info = new OrderInfo();
        _info.name = SelectionMenuNameTxt.text;
        _info.price = curPrice;
        _info.img =  SelectionMenuImage.sprite;
        _info.additionMenuList = new List<AdditionMenu>();
        _info.originPrice = originPrice;
        foreach(var item in addMenuObjectList)
        {
            if(item.CheckImg.gameObject.activeSelf)
                _info.additionMenuList.Add(item.info);
        }
        
        OrderedList.Instance.AddOrder(_info);
        
        // foreach(var item in _info.additionMenuList)
        // {
        //     Debug.Log(item.name + " " + item.price);
        // }

        Panel.SetActive(false);
    }

}
