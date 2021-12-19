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
    private string _selectionName;
    private int _selectionPrice;

    public GameObject AddMenuPrefab;

    public GameObject GradiantContent;
    public GameObject FryContent;
    public GameObject DrinkContent;
    public GameObject SauceContent;


    public Text TotalPriceTxt;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        AddMenuPrefab.SetActive(false);
    }

    void Start()
    {
        foreach (var item in MenuList.Instance.MenuDic["Gradiant"])
        {
            var go = Instantiate(AddMenuPrefab).GetComponent<AddMenuObject>();
            string name = item.Name + "\n" + "+" + item.Price.ToString();
            go.SetInfo(name, item.Price, item.smallSprite);
            go.transform.parent = GradiantContent.transform;
            go.gameObject.SetActive(true);
        }
    }

    public void Init(Sprite _sprite, string name, int price)
    {
        Panel.gameObject.SetActive(true);
        SelectionMenuImage.sprite = _sprite;
        SelectionMenuNameTxt.text = name;
        SelectionMenuPriceTxt.text = price.ToString()+"원";

        //Gradiant 
         foreach (var item in MenuList.Instance.MenuDic["Gradiant"])
         {

         }
    }

    public void OkBtnClickEvent()
    {
        OrderInfo _info = new OrderInfo();
        _info.name = _selectionName;
        _info.price = _selectionPrice;
        OrderedList.Instance.AddOrder(_info);
        Panel.SetActive(false);
    }

}
