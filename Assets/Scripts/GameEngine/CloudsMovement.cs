using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CloudsMovement : MonoBehaviour
{
    public static CloudsMovement sharedInstance;
    public List<GameObject> clouds;
    public GameObject objectToPool;
    public int amountPool;
    public Transform turret;

    private void Awake()
    {
        sharedInstance = this;
    }
    private void Start()
    {
        clouds = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            clouds.Add(tmp);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountPool; i++)
        {
            if (!clouds[i].activeInHierarchy)
            {
                return clouds[i];
            }
        }
        return null;
    }

    public void Cloud()
    {
        GameObject cloud = CloudsMovement.sharedInstance.GetPooledObject();
        if (cloud != null)
        {
            cloud.transform.position = turret.position;
            cloud.transform.rotation = turret.rotation;
            cloud.SetActive(true); // Bu satýr þart!
        }
        //GameObject cloud = CloudsMovement.sharedInstance.GetPooledObject();
        //if (cloud != null)
        //{
        //    cloud.transform.position = turret.transform.position;
        //    cloud.transform.rotation = turret.transform.rotation;
        //    cloud.SetActive(false);
        //}
        //Destroy(gameObject);
        //gameObject.SetActive(false);
    }

}
