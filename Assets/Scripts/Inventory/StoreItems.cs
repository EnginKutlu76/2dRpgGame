using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreItems : MonoBehaviour
{
    //public string itemName;
    public int itemSellPrice;
    public int itemBuyPrice;

    public GameObject itemToAdd;
    public int amountToAdd;

    TextMeshProUGUI buyPriceText;

    GameManagerTwo gameManager;
    Inventory inventory;

    private void Start()
    {
        gameManager = GameManagerTwo.Instance;
        inventory = gameManager.GetComponent<Inventory>();

        buyPriceText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        buyPriceText.text = itemBuyPrice.ToString();
    }
    private void Update()
    {
        
    }
    public void BuyItems()
    {
        if (itemBuyPrice <= CoinManager.instance.bank)
        {
            CoinManager.instance.Money(-itemBuyPrice);
            inventory.SlotlarDoluMu(itemToAdd, itemToAdd.name, amountToAdd);
        }
    }
}
