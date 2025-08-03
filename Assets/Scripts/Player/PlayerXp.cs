using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXp : MonoBehaviour
{
    public Image xpBar;
    public Text xpText;
    [SerializeField]
    private int xpAmt;
    private int gerekenXp;
    private int level;
    private float bolen;

    private void Start()
    {
        level = 1;
        gerekenXp = 100;
        bolen = 100;
    }
    private void Update()
    {
        xpBar.fillAmount = xpAmt / bolen;
        if (xpAmt >= gerekenXp)
        {
            Debug.Log("Level Yükseldi");
            level += 1;
            gerekenXp += 50;
            bolen += 50;
            xpAmt = 0;
        }
        xpText.text = level.ToString();
    }
    public void ButonlaDeneme()
    {
        xpAmt += 10;
    }
}
