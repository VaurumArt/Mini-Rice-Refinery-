using UnityEngine;
using TMPro;

public class MoneySystem : MonoBehaviour
{
    public int money = 0; // Player's current money
    public TextMeshProUGUI moneyText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        UpdateMoneyDisplay(); // Ensure the display is updated at the start
    }

    void Update()
    {
        UpdateMoneyDisplay();
    }

    // Method to add money
    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyDisplay(); // Update the display
    }

    // Method to subtract money
    public void SubtractMoney(int amount)
    {
        if (money >= amount) // Ensure there’s enough money
        {
            money -= amount;
            UpdateMoneyDisplay(); // Update the display
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }

    // Method to update the TextMeshPro display
    private void UpdateMoneyDisplay()
    {
        if (moneyText != null)
        {
            moneyText.text = "Money: " + money;
        }
    }

    // Method to get the player's current money
    public int GetMoney()
    {
        return money;
    }
}
