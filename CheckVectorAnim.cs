using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVectorAnim : MonoBehaviour
{
    
    [SerializeField]
    private Transform posman;
    [SerializeField]
    private Vector3 vectLast, vectNow;
    [SerializeField]
    private Animator GetAnim;
    // Start is called before the first frame update
    void Start()
    {
        posman = this.gameObject.GetComponent<Transform>();
        GetAnim = this.gameObject.GetComponent<Animator>();
     

    }
    public void FixedUpdate()
    {
        vectLast = vectNow;
        vectNow = transform.position;
    }
    public void SetAnim()
    {
        GetAnim.SetInteger("xer", 1);

    }
    public void AnimCheck(Vector3 VectPosEnd)
    {
        
    
        if (transform.position == VectPosEnd)
        {

            GetAnim.SetInteger("xer", 1);

        }
        else if (vectLast.y == vectNow.y)
        {
            if (vectNow.x < vectLast.x)
            {
                GetAnim.SetInteger("xer", 3);
                GetComponent<Transform>().localScale = new Vector2(1, 1);
            }
            else 
            {
                GetAnim.SetInteger("xer", 3);
                GetComponent<Transform>().localScale = new Vector2(-1, 1);
            }
        }
        else if (vectLast.x == vectNow.x)
        {
            if (vectLast.y < vectNow.y)
            {
                GetAnim.SetInteger("xer", 2);
            }
            else if (vectLast.y > vectNow.y)
            {
                GetAnim.SetInteger("xer", 5);
            }
           
            else
            {
                GetAnim.SetInteger("xer", 5);
            }
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
