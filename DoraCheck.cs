using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoraCheck : MonoBehaviour
{

    public Sprite KeySprite,SetSyp;
    public GameObject[] CheckObject;
    public GameObject[] WhoObject;
    public GameObject[] ChildSprite;
    [SerializeField]
    private int Count;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CHeck()
    {
        for(int i = 0; i < 4; i++)
        {
            if (WhoObject[i] == CheckObject[i])
            {
                if (i == 3)
                {
                    GetComponent<SpriteRenderer>().sprite = SetSyp;
                    Destroy(ChildSprite[0]);
                    Destroy(ChildSprite[1]);
                    Destroy(ChildSprite[2]);
                    Destroy(ChildSprite[3]);
                    GameObject.Find("invertar").GetComponent<SaveMassive>().LookImage[GameObject.Find("invertar").GetComponent<SaveMassive>().NumberImage] = KeySprite;
                }
            }else
            {
                GameObject.Find("telo").GetComponent<CollisionHero>().PlayAudio[8].Play();
                GameObject.Find("telo").GetComponent<CollisionHero>().LoadDie();
            }
        }
    }
    public void CheckVisibleSprite(Sprite sprite)
    {
        for(int i = 0; i < 4; i++)
        {
          
            if (ChildSprite[i].GetComponent<SpriteRenderer>().sprite==sprite)
            {
                GameObject.Find("telo").GetComponent<CollisionHero>().PlayAudio[7].Play();
                Debug.Log(ChildSprite[i].GetComponent<SpriteRenderer>().sprite.name + " " + sprite.name);
                WhoObject[Count] = ChildSprite[i];
               
                ChildSprite[i].SetActive(true);
                GameObject.Find("invertar").GetComponent<SaveMassive>().LookImage[GameObject.Find("invertar").GetComponent<SaveMassive>().NumberImage] = null;
                Count++;
                if (Count == 4)
                {
                    CHeck();
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
