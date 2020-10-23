using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Eat : MonoBehaviour
{
    public int count = 0;
    public bool isDish;
    public List<GameObject> aetObj;
    public Animator animat;
    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        animat = GameObject.Find("ghost").GetComponent<Animator>();
        foreach (GameObject go in Resources.FindObjectsOfTypeAll<GameObject>())
        {
            if (go.name == "eat")
            {
                aetObj.Add(go);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void check(Sprite sprite)
    {
      
        img.sprite = sprite;
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = sprite;
        gameObject.transform.GetChild(1).localScale = new Vector3(0, 0, 0);
        isDish = true;
        Debug.Log("belisino");
        foreach (GameObject go2 in aetObj)
        {
            if (go2.GetComponent<Eat>().isDish)
            {
                count++;
                if (count == 6)
                {
                    animat.SetInteger("am", 1);
                }
            } else
            {
                return;
            }
        }
    }
}
