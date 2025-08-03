using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialog : MonoBehaviour
{
    public string[] dialog;
    public string nameOfNpc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Dialog.instance.AddDialog(dialog, nameOfNpc);
        }
    }
}
