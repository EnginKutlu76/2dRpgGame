using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChanger : MonoBehaviour
{
    public GameObject changer;
    public static UIChanger instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
