using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TapButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public AudioSource MoveHeroAudio;
    public Transform HerTr;
    public Animator HeroAnim;
    public Rigidbody2D MvHer;
    public CollisionHero herCol;
    [SerializeField]
    static float MoveSet=5;
    public bool test = true;
    // Start is called before the first frame update
    void Start()
    {
       
        herCol = GameObject.Find("telo").GetComponent<CollisionHero>();
        HerTr= GameObject.Find("gg").GetComponent<Transform>();
        MvHer = GameObject.Find("gg").GetComponent<Rigidbody2D>();
        HeroAnim = GameObject.Find("gg").GetComponent<Animator>();
        MoveHeroAudio = GameObject.Find("movehero").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void a()
    {
        if (test)
        {
            MvHer.velocity = new Vector2(-5, 0);
            test = false;
        }
    }
    public void OnPointerDown(PointerEventData pointerEvent)
    {
       herCol.Canvas.SetActive(false);
     
        MoveHeroAudio.Play();
        switch (gameObject.name)
        {
            case "left":
              
                HerTr.localScale = new Vector3(-1, 1.2f, 1);
                a();

             
                HeroAnim.SetInteger("member", 5);
               
                break;
            case "right":
              
                HerTr.localScale = new Vector3(1, 1.2f, 1);
              // MvHer.velocity = new Vector2(5, 0);

                HeroAnim.SetInteger("member", 5);
             
                break;
            case "up":

              //  MvHer.velocity = new Vector2(0, 5);
                HeroAnim.SetInteger("member", 4);
                HerTr.localScale = new Vector3(1, 1.2f, 1);
                break;
            case "down":

               // MvHer.velocity = new Vector2(0, -5);
                HeroAnim.SetInteger("member", 1);
                HerTr.localScale = new Vector3(1, 1.2f, 1);
                break;
            
        }
    }
    public void OnPointerUp(PointerEventData pointerEvent)
    {
        test = true;
        MoveHeroAudio.Stop();
        HerTr.localScale = new Vector3(+HerTr.localScale.x, 1.2f, 1);
        MvHer.velocity = new Vector2(0, 0);
        switch (HeroAnim.GetInteger("member"))
        {
            case 1:
                HeroAnim.SetInteger("member",6);
                break;
            case 5:
                HeroAnim.SetInteger("member", 3);
                break;
            case 4:
                HeroAnim.SetInteger("member", 2);
                break;
        }
    }
}
