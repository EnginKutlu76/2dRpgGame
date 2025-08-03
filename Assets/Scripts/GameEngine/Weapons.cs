using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float strength;
    [SerializeField]
    private bool isUsed;
    BoxCollider2D boxCollider2D;
    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            boxCollider2D.enabled = true;
        }
    }
}
