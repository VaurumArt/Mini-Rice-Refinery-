using UnityEngine;
using UnityEngine.UI;

public class BuyingMachine : MonoBehaviour
{
    public GameObject machine;  // The machine object to enable/disable
    public GameObject requiredObject; // The prerequisite object that must be enabled
    public int machineCost = 100; // The cost of the machine
    private bool isBought = false; // Track if the machine has been bought
    private MoneySystem moneySystem; // Reference to the MoneySystem script

    public Button buyButton; // The UI button for buying the machine
    public Text feedbackText; // The UI text to show feedback messages
    public Color availableColor = Color.green; // Color for available
    public Color unavailableColor = Color.red; // Color for unavailable

    void Start()
    {
        // Get the MoneySystem component in the scene
        moneySystem = FindObjectOfType<MoneySystem>();

        if (moneySystem == null)
        {
            Debug.LogError("MoneySystem not found in the scene!");
        }

        // Initially disable the machine
        machine.SetActive(false);

        // Add listener to the button
        buyButton.onClick.AddListener(TryBuyMachine);

        // Update button state at the start
        UpdateButtonState();
    }

    void Update()
    {
        // Continuously update button state based on conditions
        UpdateButtonState();
    }

    void TryBuyMachine()
    {
        // Check if the prerequisite object is active
        if (requiredObject != null && !requiredObject.activeSelf)
        {
            feedbackText.text = "You need to enable the prerequisite first!";
            return;
        }

        // Check if the player has enough money and the machine is not bought
        if (moneySystem.GetMoney() >= machineCost && !isBought)
        {
            moneySystem.SubtractMoney(machineCost); // Deduct money from MoneySystem
            isBought = true; // Mark machine as bought
            EnableMachine(); // Enable the machine
            feedbackText.text = "Machine bought!";
        }
        else if (isBought)
        {
            feedbackText.text = "Machine already bought!";
        }
        else
        {
            feedbackText.text = "Not enough money to buy the machine!";
        }

        // Update button state after attempting purchase
        UpdateButtonState();
    }

    void EnableMachine()
    {
        machine.SetActive(true); // Enable the machine
    }

    void UpdateButtonState()
    {
        // Check if the machine can be bought
        bool canBuy = requiredObject != null && requiredObject.activeSelf && !isBought && moneySystem.GetMoney() >= machineCost;

        // Update button color based on availability
        ColorBlock colors = buyButton.colors;
        colors.normalColor = canBuy ? availableColor : unavailableColor;
        colors.highlightedColor = canBuy ? availableColor : unavailableColor;
        buyButton.colors = colors;

        // Disable the button if unavailable
        buyButton.interactable = canBuy;
    }
}
