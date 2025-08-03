using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int bank;
    public Text bankText;
    public static CoinManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        bankText.text = "x " + bank.ToString();
    }

    public void Money(int coinCollected)
    {
        bank += coinCollected;
        bankText.text = "x " + bank.ToString();
    }
        
}
