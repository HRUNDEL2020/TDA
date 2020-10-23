using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveHero : MonoBehaviour
{
    public bool IsPc;
    private CollisionHero ColHer;
    public Rigidbody2D rg2D;
    public bool Check = false;
    public Vector3 MoveVect;
    public SaveMassive sv;
    public Animator MoveAnim;
    public AudioSource ggmove;
    public SpriteRenderer skin;
    public Transform skintr;
    public Sprite leftskin, upskin, downskin;
    public bool isPlay;
    public void SetAnim(int anim)
    {

         
        if (Check||IsPc)
        {
            MoveAnim.SetInteger("member", anim);
            Check = false;
        }
    }
    private void Awake()
    {
        IsPc = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        ggmove = GameObject.Find("ggmove").GetComponent<AudioSource>();
      
      
        sv = GameObject.Find("invertar").GetComponent<SaveMassive>();
        rg2D = this.GetComponent<Rigidbody2D>();
        MoveAnim = this.GetComponent<Animator>();
        ColHer = GameObject.Find("telo").GetComponent<CollisionHero>();
        UPUP();
       
    }
    public void LeftDown()
    {
        skin.sprite = leftskin;
       
      
        Debug.Log("Left");
        MoveVect = new Vector3(-0.1f, 0, 0);
        transform.localScale = new Vector3(-1, 1.2f, 1);
        SetAnim(5);
        if (isPlay)
        {
            ggmove.Play();
            isPlay = false;
        }

    }
    public void RightDown()
    {
        skin.sprite = leftskin;
     
       
     
        transform.localScale = new Vector3(1, 1.2f, 1);
        MoveVect = new Vector3(0.1f, 0, 0);
        SetAnim(5);
        if (isPlay)
        {
            ggmove.Play();
            isPlay = false;
        }
    }
    public void UpDown()
    {
       // skintr.transform.position =transform.position+new Vector3(1,0,0);
        skin.sprite =downskin;
        skintr.localScale = new Vector3(1, 1, 1);
      
        MoveVect = new Vector3(0, 0.1f, 0);
        transform.localScale = new Vector3(1, 1.2f, 1);
        SetAnim(4);
        if (isPlay)
        {
            ggmove.Play();
            isPlay = false;
        }
    }
    public void UPUP()
    {
        ggmove.Stop();
        Check = true;
        CheckAnim();
        MoveVect = Vector3.zero;
        isPlay = true;
    }
        public void DownDown()
    {
      //  skintr.transform.position = new Vector3(0.1f, 2, 0);
        skin.sprite = upskin;
        
      
        transform.localScale = new Vector3(1, 1.2f, 1);
        MoveVect = new Vector3(0, -0.1f, 0);
       
        SetAnim(1);
    }
    public void Update()
    {
        if (IsPc)
        {
           
            if (Input.GetKey(KeyCode.A))
            {

                LeftDown();
                
            }
            else if (Input.GetKey(KeyCode.D))
            {
                RightDown();
               
            }
            else if (Input.GetKey(KeyCode.S))
            {
                DownDown();
               
            }
            else if (Input.GetKey(KeyCode.W))
            {
                UpDown();
                
            }
           if(Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.D)|| Input.GetKeyUp(KeyCode.S)|| Input.GetKeyUp(KeyCode.W))
           {
                UPUP();
             
            }
        }
    }
    public  void FixedUpdate()
    {
        transform.Translate(MoveVect);
        if (MoveVect != Vector3.zero)
        {
            if (GameObject.Find("textbook"))
            {
                GameObject.Find("Canvas (1)").SetActive(false);
                GameObject.Find("telo").GetComponent<CollisionHero>().menuUI.SetActive(true);
            }
        }
        


    }
  
   
    public void CheckAnim()
    {
      
        switch (MoveAnim.GetInteger("member"))
        {
            case 1:
                MoveAnim.SetInteger("member", 6);
                break;
            case 5:
                MoveAnim.SetInteger("member", 3);
                break;
            case 4:
                MoveAnim.SetInteger("member", 2);
                break;
            default:
                MoveAnim.SetInteger("member", 2);
                break;

        }
    }
    
}
