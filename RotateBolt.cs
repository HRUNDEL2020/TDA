using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class RotateBolt : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public Sprite standartSprite;
    public int ChildId;
    public GameObject panelobj;
    public float hp = 100;
    public float damage = 0;
    public Vector3 rotateVect;
    public bool Kostyl;
    public GameObject ParentObj;
    public AudioSource pl;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {

        Kostyl = true;
        GetComponent<Image>().color = Color.white; 
        GetComponent<Image>().sprite = standartSprite;
      
    }
  void OnDisable()
    {
        panelobj.transform.GetChild(ChildId).GetComponent<SaveHp>().HpPanel = hp;
        panelobj = null;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Kostyl)
        {
           hp = panelobj.transform.GetChild(ChildId).GetComponent<SaveHp>().HpPanel;
            Kostyl = false;
        }
        transform.Rotate(rotateVect, 3);
        hp -= damage;
       

            if (hp < 0)
        {
            pl.Stop();
            GetComponent<Image>().color = new Color(0, 0, 0, 0);
            GetComponent<Image>().sprite = standartSprite;
            panelobj.transform.GetChild(ChildId).GetComponent<SpriteRenderer>().sprite = null;

            hp = 1000000000000;
           
        }
    }
    public void OnPointerDown(PointerEventData eventData)
{

    rotateVect = new Vector3(0, 0, 50);
    damage = 0.5f;
    if (hp < 101)
    {
        pl.Play();
    }
}
    public void OnPointerUp(PointerEventData eventData)
    {
        rotateVect = new Vector3(0, 0, 0);
        damage = 0;
        pl.Stop();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        rotateVect = new Vector3(0, 0, 0);
        damage = 0;
        pl.Stop();
    }
}
