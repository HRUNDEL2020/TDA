using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Cooking : MonoBehaviour
{ 
public Sprite bludo1, bludo2, bludo3, bludo4, bludo5, bludo6, bludo7, bludo8   , nothing;
    public SaveMassive invert;
    public Sprite[] objspr;
    public string code;
    public int count = 0;
    public AudioSource ar,chel;
    // Start is called before the first frame update
    public GameObject[] AllChild;
    void Start()
    {
        
        for (int i=0;i<transform.childCount;i++)
        {
            AllChild[i] = GameObject.Find(transform.GetChild(i).name);
            Debug.Log(transform.GetChild(i).name);
            Debug.Log(transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name);
           
                objspr[i] = AllChild[i].GetComponent<SpriteRenderer>().sprite;
          
            AllChild[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDeactive()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            AllChild[i].SetActive(false);
        }
    }
    public void ActiveObj(Sprite a)
    {
      
        if (a != nothing)
        {
           
          
            for (int b = 0; b < objspr.Length; b++)
            {
             
                if (objspr[b] == a)
                {
                    ar.Play();
                    count++;
                    invert.LookImage[invert.NumberImage] = null;
                    Debug.Log(a.name);
                    AllChild[b].SetActive(true);
                    code += AllChild[b].name;

                    if (code == "12" || code == "21")
                    {
                        SetDeactive();
                        invert.LookImage[invert.MaxNum + 1] = bludo1;
                        invert.MaxNum++;
                        invert.NumberImage = invert.MaxNum;
                        code = "";
                        return;
                    }
                    else if (code == "89" || code == "98")
                    {
                        SetDeactive();
                        invert.LookImage[invert.MaxNum + 1] = bludo2;
                        invert.MaxNum++;
                        invert.NumberImage=invert.MaxNum;
                        code = "";
                        return;
                    }
                    else if (code == "97"|| code == "79")
                    {
                        SetDeactive();
                        invert.LookImage[invert.MaxNum + 1] = bludo4;
                        invert.MaxNum++;
                        invert.NumberImage = invert.MaxNum;
                        code = "";
                        return;
                    }
                    else if (code == "14"|| code == "41")
                    {
                        SetDeactive();
                        invert.LookImage[invert.MaxNum + 1] = bludo3;
                        invert.MaxNum++;
                        invert.NumberImage = invert.MaxNum;
                        code = "";
                        return;
                    }
                    else if (code == "1115" || code == "1511")
                    {
                        SetDeactive();
                        invert.LookImage[invert.MaxNum + 1] = bludo5;
                        invert.MaxNum++;
                        invert.NumberImage = invert.MaxNum;
                        code = "";
                        return;
                    }
                    else if (code == "11125" || code == "12511")
                    {
                        SetDeactive();
                        invert.LookImage[invert.MaxNum + 1] = bludo6;
                        invert.MaxNum++;
                        invert.NumberImage = invert.MaxNum;
                        code = "";
                        return;
                    }
                    else if (code == "1459" || code == "9145")
                    {
                        SetDeactive();
                        invert.LookImage[invert.MaxNum + 1] = bludo7;
                        invert.MaxNum++;
                        invert.NumberImage = invert.MaxNum;
                        code = "";
                        return;
                    }
                    else if (code == "10145" || code == "14510")
                    {
                        SetDeactive();
                        invert.LookImage[invert.MaxNum + 1] = bludo8;
                        invert.MaxNum++;
                        invert.NumberImage = invert.MaxNum;
                        code = "";
                        return;
                    }
                    else if (count>=2)
                    {
                        chel.Play();  
                        SetDeactive();
                        invert.LookImage[invert.NumberImage] = null;
                        code = "";
                        count = 0;
                        return;
                    }
                }
            }
           
        }
    }
}
