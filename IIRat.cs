using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IIRat : MonoBehaviour
{
    public Transform clock;
    public GameObject chis;
    public bool isSeak;
    public Transform ggpos;
    public Vector2 EndMove;
    public float speedMove;
    public Sprite srp;
    public AudioSource kris;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

      
        transform.Translate(EndMove);

        if (Vector2.Distance(transform.position, ggpos.position) / Time.deltaTime < 200)
        {
            EndMove = new Vector3(0, speedMove, 0);
            
            transform.localScale = new Vector3(0.0297716f, -0.0297716f, 0.0297716f);
        }
        else if (isSeak == true&& Vector3.Distance(transform.position, ggpos.position) / Time.deltaTime > 260)
        {
            EndMove = new Vector3(0, -speedMove, 0);

            transform.localScale = new Vector3(0.0297716f, 0.0297716f, 0.0297716f);
        }
        else {

       
            EndMove = new Vector3(0, 0, 0);

            transform.localScale = new Vector3(0.0297716f, 0.0297716f, 0.0297716f);
        }
    }
    
public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "chis_stav")
        {
            kris.Play();
            clock.position = collision.gameObject.transform.position;
            chis.SetActive(true);
            Destroy(collision.gameObject);
            EndMove = new Vector3(0, 0, 0);
            isSeak = false;
        }
       else if(collision.gameObject.name == "chees in cletka_0")
       {
          
            collision.gameObject.GetComponent<SpriteRenderer>().sprite=srp;
            collision.gameObject.GetComponent<PLaySound>().Play();
           gameObject.SetActive(false);
        }
    }
    
}
