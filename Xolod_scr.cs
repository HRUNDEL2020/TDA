using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xolod_scr : MonoBehaviour
{
    public bool isChis, isVinograde;
    public Transform syp, izum;
    public GameObject setactive1, setactive2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OOPEN()
    {
        if (isChis&& syp != null)
        {
            syp.transform.position = new Vector3(-5.5f, 12.5f,0);
        }
        if (isVinograde&& izum != null)
        {
            izum.transform.position = new Vector3(-5.298f, 12.702f, -0.1f);
        }       
    }
    public void  CLOOSE()
    {
        if (isChis)
        {
            if (GameObject.Find("chis_spr"))
            {
                Destroy(GameObject.Find("chis_spr"));
            }
           
        }
        if (isVinograde)
        {
            if (GameObject.Find("vinograde_spr"))
            {
                Destroy(GameObject.Find("vinograde_spr"));
            }
          
        }
        if (izum != null)
        {
            izum.transform.position = new Vector3(3000, 30000000, 0);
        }
        if (syp != null)
        {
            syp.transform.position = new Vector3(300000, 300000, 0);
        }
    }
}
