using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimForRecence : MonoBehaviour
{
    public Animator anm;
    public GameObject cns;
    public bool isDie;
    public Sprite key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetStand2()
    {
        anm.SetInteger("IZAEBALSA", 2);
    }
    public void SetStand()
    {
        anm.SetInteger("IZAEBALSA", 0);
        GameObject.Find("gg").GetComponent<MoveHero>().IsPc = false;
        cns.SetActive(false);
    }
    IEnumerator em()
    {
        anm.SetInteger("IZAEBALSA", 6);
        yield return new WaitForSeconds(Random.Range(2, 5));
        GameObject.Find("telo").GetComponent<CollisionHero>().LoadDie();
        Destroy(gameObject);
    }
    public void Fshix()
    {
        if (isDie)
        {
            StartCoroutine(em());
        } else
        {
            GameObject.Find("gg").GetComponent<MoveHero>().IsPc = true;
            cns.SetActive(true);
            GameObject.Find("telo").GetComponent<CollisionHero>().CheckMassive.LookImage[GameObject.Find("telo").GetComponent<CollisionHero>().CheckMassive.NumberImage] = key;
            Destroy(gameObject);

        }
        
    }
}
