using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForPlayer : MonoBehaviour
{
    public int RotateInt = 1;
 
    public Transform PlayerPos;
    public SaveMassive SvMas;
    public Animator GetAnim;
    public Rigidbody2D RgMan2D;
    public float Savevector2;
    public GameObject ColObject;
    [SerializeField]
    private CheckVectorAnim checkScr;
    
    [SerializeField]
    private float SaveDistance = 0;
    [SerializeField]
    private float Speed = 5;
    [SerializeField]
    private Vector2 VectPosPlayer;
    [SerializeField]
    private Vector2 VectPosOther;
   
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.Find("gg").GetComponent<Transform>();
        SvMas = GameObject.Find("invertar").GetComponent<SaveMassive>();
        GetAnim = this.gameObject.GetComponent<Animator>();
        RgMan2D = this.gameObject.GetComponent<Rigidbody2D>();
        checkScr = this.gameObject.GetComponent<CheckVectorAnim>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        VectorCheck();
       
        transform.position = Vector2.MoveTowards(transform.position, VectPosPlayer, Speed * Time.deltaTime);
        Savevector2 = Vector2.Distance(transform.position, VectPosPlayer) / Time.deltaTime;
        SaveDistance = Vector2.Distance(transform.position, new Vector2(PlayerPos.position.x, PlayerPos.position.y)) / Time.deltaTime;
        checkScr.AnimCheck(VectPosOther);
    }
   
    public void VectorCheck()
    {
        if (Vector2.Distance(transform.position, new Vector2(PlayerPos.position.x, PlayerPos.position.y)) / Time.deltaTime < 260)
        {

            if (Vector2.Distance(transform.position, new Vector2(PlayerPos.position.x, transform.position.y)) / Time.deltaTime > 10)
            {
               
                    VectPosPlayer = new Vector2(PlayerPos.position.x*RotateInt, transform.position.y);
                
                
            }
            else
            {        
                   VectPosPlayer = new Vector2(transform.position.x, PlayerPos.position.y*RotateInt);           
            }

        }
        else
        {
            if (transform.position.y != VectPosOther.y)
            {
              
                    VectPosPlayer = new Vector2(transform.position.x, VectPosOther.y);
                
            }
            else if (transform.position.x != VectPosOther.x)
            {
               
                    VectPosPlayer = new Vector2(VectPosOther.x, transform.position.y);
                
                
            }

        }
       
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        ColObject = collision.gameObject;
    }
   
}