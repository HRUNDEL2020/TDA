using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chosts : MonoBehaviour
{
    public Sprite eatFood;
    public Text recencheText;
    public Sprite[] checkSprite;
    public string[] txtrecenche;
    public float[] numberrecence;
    public float endochenka;
    static float rezyltat;
    static int count=1;
    public SpriteRenderer da;
    public Image setSprite;
    public Text AAAAA;
    public SetAnimForRecence s;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Recenche()
    {
        Debug.Log("AAAAAAA");
        eatFood = da.sprite;
        setSprite.sprite = da.sprite;
        for (int i = 0; i < checkSprite.Length; i++)
        {
            Debug.Log("AAAAAAAAAAA");
            if (eatFood == checkSprite[i])
            {
                Debug.Log("AAAAAAAAAAAAAAAAAAA");
                recencheText.text = txtrecenche[i]+"\n"+"Оценка:"+numberrecence[i];
                endochenka = numberrecence[i];
                rezyltat += endochenka;
                count++;
                Debug.Log(rezyltat);
                if (count == 6)
                {
                    rezyltat =Mathf.Round(rezyltat) / 6;

                    AAAAA.text += rezyltat;
                    if (rezyltat < 3)
                    {
                        s.isDie = true;
                    }
                }

            }
        }
    }

}
