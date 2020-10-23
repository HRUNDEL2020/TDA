using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRat : MonoBehaviour
{
    public GameObject DieUI;
    public Quaternion savelr;
    public Sprite[] sprchees;
    public Sprite spr;
    public GameObject WhoCol;
    public Vector2 Tprat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Tprat*Time.deltaTime);
      
    }
  public void   OnTriggerEnter2D(Collider2D collider)
    {
        if (GameObject.Find("telo") != collider.gameObject&& GameObject.Find("gg") != collider.gameObject)
        {
            WhoCol = collider.gameObject;

            if (collider.name == "norka_0")
            {
                GameObject.Find("klish").GetComponent<Transform>().position = new Vector2(5.67f, 13.2f);
                Destroy(gameObject);
            }
            else if (collider.tag == "not")
            {
                StartCoroutine(DestrObj());
            }
            else if (collider.tag == "ChisTag")
            {
                StartCoroutine(ChisCheck());
            }
        }
    }
    IEnumerator DestrObj()
    {

        yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        WhoCol.GetComponent<SpriteRenderer>().sprite = spr;
        gameObject.layer = -2;
        yield return new WaitForSeconds(1);
        GameObject.Find("telo").GetComponent<CollisionHero>().PlayAudio[8].Play();
        GameObject.Find("telo").GetComponent<CollisionHero>().LoadDie();
      
       
    }
    IEnumerator ChisCheck()
    {
        yield return new WaitForSeconds(0.7f);
        Tprat = new Vector2(0, 0);
        yield return new WaitForSeconds(1);
        if (WhoCol.GetComponent<SpriteRenderer>().sprite == sprchees[0])
        {
            Tprat = new Vector2(0, -1);
            this.GetComponent<Transform>().localRotation = new Quaternion(0, 0, 180,1);
            this.GetComponent<Transform>().localScale = new Vector2(0.04f, 0.04f);
            Debug.Log("up");
        }
        else  if (WhoCol.GetComponent<SpriteRenderer>().sprite == sprchees[1])
        {
            Tprat = new Vector2(0, -1);
            this.GetComponent<Transform>().localRotation = savelr;
            this.GetComponent<Transform>().localScale = new Vector2(0.04f, 0.04f);
            Debug.Log("right");
        }
        else if (WhoCol.GetComponent<SpriteRenderer>().sprite == sprchees[2])
        {
            Tprat = new Vector2(0, 1);
            this.GetComponent<Transform>().localRotation = savelr;
            this.GetComponent<Transform>().localScale = new Vector2(0.04f, -0.04f);
            Debug.Log("left");
        }
        else if (WhoCol.GetComponent<SpriteRenderer>().sprite == sprchees[3])
        {
            Tprat = new Vector2(0, -1);
            this.GetComponent<Transform>().localRotation = new Quaternion(0, 0,0, 1);
            Debug.Log("down");
        }
        WhoCol.GetComponent<SpriteRenderer>().sprite = sprchees[4];


    }
}
