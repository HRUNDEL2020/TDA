using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForLine : MonoBehaviour
{
    public float progress;
    public float Distance;
    public bool isMove=true;
    public Vector2 vectormove, howmove;
    public float Speed;
    public float[] WaitToRun;
    public Vector2[] TranslateObj;
    public int MoveLineInt = 0;
    public GameObject TraectoryObj;
    [SerializeField]
    private Transform ThisTr;
    [SerializeField]
    private Transform GGTranform;
    [SerializeField]
    private Rigidbody2D rg;
    [SerializeField]
    private Animator Anim;
    [SerializeField]
    private int MaxLine = 0;
    // Start is called before the first frame update
    void Awake()
    {
        ThisTr = this.gameObject.transform;
        Anim = this.gameObject.GetComponent<Animator>();
        rg = this.gameObject.GetComponent<Rigidbody2D>();
       
        GGTranform = GameObject.Find("gg").GetComponent<Transform>();
        int b = 0;
        foreach (Transform go in TraectoryObj.transform)
        {

            TranslateObj[b] = go.transform.position;
            b++;

        }
        MaxLine = b;   
       
         
    }
   
    public void CheckPos()
    {
       
        Debug.Log(gameObject.name+" "+ transform.position.x+" "+transform.position.y+" yes "+TranslateObj[MoveLineInt].x+ " "+ TranslateObj[MoveLineInt].y);
        if (ThisTr.position.x==TranslateObj[MoveLineInt].x)
        {
          
            if (ThisTr.position.y > TranslateObj[MoveLineInt].y)
            {
                Debug.Log(gameObject.name);
                Anim.SetInteger("xer", 5);
                GetComponent<Transform>().localScale = new Vector2(-1, 1);
            }
            else 
            {
                Anim.SetInteger("xer", 2);
                GetComponent<Transform>().localScale = new Vector2(1, 1);
                
            }
            vectormove = new Vector2(ThisTr.position.x, TranslateObj[MoveLineInt].y);
        }
        else if (ThisTr.position.y == TranslateObj[MoveLineInt].y)
        {
            Debug.Log("max2:" + MoveLineInt);
            if (ThisTr.position.x> TranslateObj[MoveLineInt].x)
            {
                Anim.SetInteger("xer", 3);
                GetComponent<Transform>().localScale = new Vector2(1, 1);
               
            } else
            {
                Anim.SetInteger("xer", 3);
                GetComponent<Transform>().localScale = new Vector2(-1, 1);
               
            }
            vectormove = new Vector2(TranslateObj[MoveLineInt].x, ThisTr.position.y);

        }
        isMove = true;

    }
    public void DistanceYes()
    {
      
        GetComponent<Transform>().localScale = new Vector2(1, 1);
        howmove = Vector2.zero;
        StartCoroutine(HowWait());
        if (MaxLine - MoveLineInt == 1)
        {
            MoveLineInt = 0;
            return;
        }
        MoveLineInt++;
    }
    
    public void Start()
    {
        CheckPos();
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMove)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x,transform.position.y), TranslateObj[MoveLineInt], progress*Time.deltaTime);

            if ( new Vector2(ThisTr.position.x, ThisTr.position.y) == TranslateObj[MoveLineInt])
            {
                Debug.Log("pos:" + transform.position.x + " " + transform.position.y + " other pos:" + TranslateObj[MoveLineInt].x + " " + TranslateObj[MoveLineInt].y);
                transform.position = TranslateObj[MoveLineInt];
                Debug.Log("pos:" + transform.position.x + " " + transform.position.y + " other pos:" + TranslateObj[MoveLineInt].x + " " + TranslateObj[MoveLineInt].y);
                isMove = false;
                Anim.SetInteger("xer", 1);
                DistanceYes();
            }
        }
    }
    IEnumerator HowWait()
    {

       
        yield return new WaitForSeconds(WaitToRun[MoveLineInt]);
       
        CheckPos();
       

    }
}
