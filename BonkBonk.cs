using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonkBonk : MonoBehaviour
{
    public Sprite clock;
    public SaveMassive svms;
    public BonkBonk[] gmbonk;
    public Sprite setspr;
    public SpriteRenderer spr;
    public bool isTrue;
    public bool SetTrue;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        svms = GameObject.Find("invertar").GetComponent<SaveMassive>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSprite()
    {
        spr.sprite = setspr;
        SetTrue = false;
        for(int b = 0; b < 4; b++)
        {
            if(gmbonk[b].isTrue== gmbonk[b].SetTrue)
            {
                Debug.Log("check");
                if (b == 3)
                {
                    Debug.Log("yes");
                    svms.LookImage[svms.NumberImage] = clock;
                  
                    return;
                }
            } else
            {
                return;
            }
        }
    }
}
