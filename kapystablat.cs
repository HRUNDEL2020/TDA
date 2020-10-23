using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapystablat : MonoBehaviour
{
    public Sprite[] setimg;
    public Sprite[] GetImg;
    public Sprite[] SetSprite;
    public AudioSource[] pla;
    public int stadia = 0;
    public bool isCan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  public Sprite KAPYSTA(Sprite img)
    {
        if (stadia == 3)
        {
            GetComponent<SpriteRenderer>().sprite = SetSprite[stadia];
            isCan = true;
            return setimg[stadia];
        }
        if (img == GetImg[stadia])
        {
            GetComponent<SpriteRenderer>().sprite = SetSprite[stadia];
            isCan = true;
            pla[stadia].Play();
            return setimg[stadia];
           
           
        }
        isCan = false;
        return img;
    }
}
