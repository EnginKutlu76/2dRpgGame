using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipments : MonoBehaviour
{
    public GameObject helmet, cloth, armor, weapons;
    public GameObject helmet1, cloth1, armor1, weapons1;
    //public List<Image> images;
    public List<GameObject> equipments;

    public static PlayerEquipments instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        // weapons1 içindeki child'dan changer prefab'ýný al
        Transform weaponChild = weapons1.transform.GetChild(0);
        GameObject changerPrefab = weaponChild.GetComponent<UIChanger>().changer;

        // Sahneye instantiate et
        GameObject changerInstance = Instantiate(changerPrefab);

        // weapons GameObject'inin çocuðu yap
        changerInstance.transform.SetParent(weapons.transform, false); // false = localPosition/rotation korunur

        // Ýstersen referans olarak da sakla
        weapons = changerInstance;
    }

    private void Start()
    {
    }
    private void Update()
    {
        
    }
    public void Adjustment()
    {
     
    }
}
