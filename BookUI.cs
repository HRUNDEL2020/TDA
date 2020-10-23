using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookUI : MonoBehaviour
{
    public GameObject next, last, exit,canvas,book;
    public GameObject[] stanichiobj;
    public int stranicha;
    public int maxstr = 3;
    public int minstr=0;
    public Animator anim;
    public AudioSource ar;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OnEnable()
    {
        stanichiobj[stranicha].SetActive(true);
        next.SetActive(true);
        exit.SetActive(true);
        last.SetActive(true);
        anim.SetInteger("std", 3);
    }
    public void EndAnim()
    {
        anim.SetInteger("std", 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Close()
    {
        book.SetActive(false);
    }
    public void CloseAll()
    {
        next.SetActive(false);
        exit.SetActive(false);
        last.SetActive(false);
        canvas.SetActive(true);
        anim.SetInteger("std", 4);
        GameObject.Find("gg").GetComponent<MoveHero>().IsPc = true;

    }
    public void SetActive()
    {
        next.SetActive(false);
        exit.SetActive(false);
        last.SetActive(false);
        stanichiobj[stranicha].SetActive(false);
        Debug.Log("es");
    }
    public void StaidAnim()
    {
       
    }
    public void EndAnimNext()
    {
        anim.SetInteger("std", 0);
        stranicha++;
        next.SetActive(true);
        exit.SetActive(true);
        last.SetActive(true);
        stanichiobj[stranicha].SetActive(false);
        stanichiobj[stranicha].SetActive(true);
        Debug.Log(stanichiobj[stranicha].name);

        
    }
    public void EndAnimLast()
    {
       
        stranicha--;
        next.SetActive(true);
        exit.SetActive(true);
        last.SetActive(true);
        stanichiobj[stranicha].SetActive(false);
        stanichiobj[stranicha].SetActive(true);
        Debug.Log(stanichiobj[stranicha].name);

        anim.SetInteger("std", 0);
    }
    public void nextStr()
    {
       
        if (maxstr != stranicha)
        {
            ar.Play();
            anim.SetInteger("std", 1);

        }
    }
    public void lastStr()
    {
       
        if (minstr != stranicha)
        {
            ar.Play();
            anim.SetInteger("std", 2);

        }
    }
}
