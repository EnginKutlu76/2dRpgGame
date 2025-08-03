using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject inventory;
    public GameObject map;
    public Animator animator;

    private void Start()
    {
    }
    private void Update()
    {
        
    }
    public void InventoryActive()
    {
        inventory.SetActive(true);
        Debug.Log("ÝNV AÇILDI");
    }
    public void MapActive()
    {
        map.SetActive(true);
        animator.SetTrigger("open");
        Debug.Log("Map açýldý");
    }
}
