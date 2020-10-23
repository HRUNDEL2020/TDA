using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Proverka : MonoBehaviour
{
    public int b = 0;
    public Sprite aaaaaaaaa;
    public AudioSource diegg;
    public GameObject AIU,IU;
    public Animator MyLaziness;
    public Sprite[] sprget;
    public Image[] gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Proverk()
    {
       for (int i = 0; i < sprget.Length; i++)
        {
            if (sprget[i] == gm[i].sprite)
            {
                b++;
                if (b==4)
                {
                    GameObject.Find("klish").GetComponent<Transform>().position = new Vector3(1.82f, 11.1f, 0);
                    GameObject.Find("doradyra").GetComponent<SpriteRenderer>().sprite = aaaaaaaaa;
                }
            } else
            {
                diegg.Play();
                MyLaziness.SetInteger("dies", 0);
                AIU.SetActive(false);
                IU.SetActive(false);
            }
        }
    }
}
