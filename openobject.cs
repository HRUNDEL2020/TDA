using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openobject : MonoBehaviour
{
    public SaveMassive mas;
    public Sprite OpenSpr, CloseSpr;
    public Vector3 pos;
    public GameObject setObject;
    // Start is called before the first frame update
    void Start()
    {
        mas = GameObject.Find("invertar").GetComponent<SaveMassive>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        if (setObject != null)
        {
            setObject.GetComponent<Transform>().position = pos;
            
        }
        GetComponent<SpriteRenderer>().sprite = OpenSpr;
    }
    public void Close()
    {
        if (setObject != null)
        {
         
            setObject.GetComponent<Transform>().position = new Vector3(1000000,10000000,0);
            
            
        }
        GetComponent<SpriteRenderer>().sprite = CloseSpr;
          
    }
}
