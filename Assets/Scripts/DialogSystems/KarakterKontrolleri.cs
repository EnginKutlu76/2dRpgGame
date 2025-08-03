using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrolleri : MonoBehaviour
{
    public event System.Action OyuncuHareket;
    public delegate void mesajVerDelegate(string mesaj);
    public static KarakterKontrolleri instance;

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

        mesajVerDelegate mesajDegiskeni = MesajGoster;
        mesajDegiskeni ("Merhaba Dünya");
    }
    void MesajGoster(string mesaj)
    {
        Debug.Log(mesaj);
    }
   }
