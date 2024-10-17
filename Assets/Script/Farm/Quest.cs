using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    [SerializeField] private Text orderText;  // Display the order details
    [SerializeField] private Text timerText;  // Display the time left
    private int supplyOrder;                      // Random supply order
    private float orderTime = 120f;               // Time to complete the order
    private bool orderActive = true;              // Track if the order is active

    [SerializeField] private UIManager uiManager;  // Reference to UIManager

    void Start()
    {
        StartNewQuest();  // Start the first quest
    }

    void Update()
    {
        // Check if the order is active
        if (orderActive)
        {
            orderTime -= Time.deltaTime;  // Reduce the time each frame
            UpdateTimerUI();

            // Check if the player presses Enter to complete the transaction
            if (Input.GetKeyDown(KeyCode.Return))  // "Enter" is represented by Return key
            {
                PayOrder();  // Handle the payment when Enter is pressed
            }

            // If the time runs out
            if (orderTime <= 0f)
            {
                FailOrder();  // Handle failure case
            }
        }
    }

    // Call this method when the player presses Enter to pay for the order
    public void PayOrder()
    {
        // Check if the player has enough money and rice
        if (uiManager.money >= supplyOrder && uiManager.GetRiceCount() >= supplyOrder)
        {
            // Subtract the money and rice sacks
            uiManager.Transactions(-supplyOrder);
            uiManager.SubtractRice(supplyOrder);
            StartCoroutine(CompleteOrder());  // Handle successful payment and wait for the next quest
        }
        else
        {
            Debug.Log("Not enough resources to pay for the order!");
        }
    }

    private void FailOrder()
    {
        Debug.Log("Order failed! Player loses money.");
        uiManager.Plants(5);  // Penalize the player for failing
        orderActive = false;
    }

    private IEnumerator CompleteOrder()
    {
        Debug.Log("Order completed successfully!");
        orderActive = false;  // Stop the timer
        yield return new WaitForSeconds(3);  // Wait before starting a new quest
        StartNewQuest();  // Start a new quest
    }

    private void StartNewQuest()
    {
        supplyOrder = Random.Range(1, 5);  // Generate a new random order
        orderTime = 120f;  // Reset the timer
        orderActive = true;  // Reactivate the quest
        UpdateOrderUi();
    }

    private void UpdateOrderUi()
    {
        orderText.text = "Order " + supplyOrder + " coins and rice needed";
    }

    private void UpdateTimerUI()
    {
        timerText.text = "Time Left: " + Mathf.CeilToInt(orderTime) + " seconds";
    }
}
