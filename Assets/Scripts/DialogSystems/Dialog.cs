using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public static Dialog instance;
    public GameObject dialogPanel;

    public List<string> dialogLines = new List<string>();

    public string nameOfNpc;

    public List<string> karakterler = new List<string>();

    public Button contButton;
    public Text dialogText, nameText;
    int dialogIndex;

    private void Awake()
    {
        dialogPanel.SetActive(false);

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        DelegeveEvent.mesajVer += Baslangic;
    }
    public void AddDialog(string[] lines, string npcName)
    {
        this.nameOfNpc = npcName;
        dialogIndex = 0;
        dialogLines = new List<string>(lines.Length);
        dialogLines.AddRange(lines);
        CreateDialog();
    }
    public void CreateDialog()
    {
        DelegeveEvent.mesajVer("Azaldý");
        dialogText.text = dialogLines[dialogIndex];
        nameText.text = nameOfNpc;
        dialogPanel.SetActive(true);

        var npcNameMatch = new List<string> { nameOfNpc }
        .Where(name => name == "OE")
        .ToList();

        if (npcNameMatch.Any())
        {
            Debug.Log("OE");
        }
    }
    public void ContinueDialog()
    {
        if (dialogIndex < dialogLines.Count - 1)
        {
            dialogIndex++;
            dialogText.text = dialogLines[dialogIndex];
        }
        else
        {
            //DelegeveEvent.instance.OyuncuHareket += Bitis;
            dialogPanel.SetActive(false);
            //  Time.timeScale = 1;
        }
    }
    public void Bitis()
    {
        Debug.Log("Diyalog Bitti");
    }
    public void Baslangic(string mesaj)
    {
        Debug.Log("Karakter caný=" + mesaj);
    }
}
