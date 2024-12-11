//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class UIManager : MonoBehaviour
//{
//    public Text sackOfRiceText;
//    private int riceCount = 0;
//    public int money = 100;
//    public Text MoneyTxt;
//    public Sprite sack;


//    public void AddRice(int amount)
//    {
//        riceCount += amount;
//        UpdateSackUI();
//    }


//    public void UpdateSackUI()
//    {
//        sackOfRiceText.text = "Sack of Rice: " + riceCount;
//    }

//    void Start()
//    {
//        MoneyTxt.text = "Money: " + money;

//    }

//    public void Transactions(int value)
//    {
//        money += value;
//        MoneyTxt.text = "Money: " + money;
//    }

//    public void Plants(int value)
//    {
//        money -= value;
//        MoneyTxt.text = "Money: " + money;
//    }

//    public void Harvest(int value)
//    {
//        money += value;
//        MoneyTxt.text = "Money: " + money;
//    }

//}
