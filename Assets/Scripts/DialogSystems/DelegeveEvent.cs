using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegeveEvent : MonoBehaviour
{
    public event System.Action OyuncuHareket;
    public delegate void mesajVerDelegate(string mesaj);
    public static mesajVerDelegate mesajVer;
    public static DelegeveEvent instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Debug.Log("Oyun Baþladý");
        OyuncuHareket?.Invoke();
        OyuncuHareket += OyuncuHareketEylemi;
        mesajVer?.Invoke("Karakter caný=");
    }
    void OyuncuHareketEylemi()
    {
        Debug.Log("Oyuncu hareket etti!");
    }

}
