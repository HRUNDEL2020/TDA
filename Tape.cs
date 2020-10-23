using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Tape : MonoBehaviour,IPointerDownHandler
{
    public GameObject Cn;
    public CollisionHero herCol;
    public SaveLvl svlvl;
    public GameObject mncam, dontmoney;
    static int time2 = 2;
    public int timeravno=1;
   static Text txt;
    static Image retur,menu,left,right,up,down,ispol,mn,invert;
    // Start is called before the first frame update
    void Start()
    {
        herCol = GameObject.Find("telo").GetComponent<CollisionHero>();
        svlvl = GameObject.Find("zp").GetComponent<SaveLvl>();
        invert = GameObject.Find("invertar").GetComponent<Image>();
      
        mncam = GameObject.Find("Main Camera");
        if (GameObject.Find("right"))
        {
            txt = GameObject.Find("Text").GetComponent<Text>();
            retur = GameObject.Find("return").GetComponent<Image>();
            right = GameObject.Find("right").GetComponent<Image>();
            up = GameObject.Find("up").GetComponent<Image>();
            left = GameObject.Find("left").GetComponent<Image>();
            down = GameObject.Find("down").GetComponent<Image>();
            Cn = GameObject.Find("Canvas");
            menu = GameObject.Find("back").GetComponent<Image>();
            mn = GameObject.Find("menu").GetComponent<Image>();
            ispol = GameObject.Find("Button").GetComponent<Image>();
        }
       
        if (GameObject.Find("gg").GetComponent<MoveHero>().IsPc&& GameObject.Find("right"))
        {
            GameObject.Find("right").SetActive(false);
          GameObject.Find("up").SetActive(false);
            GameObject.Find("left").SetActive(false);
            GameObject.Find("down").SetActive(false);
            GameObject.Find("Text").SetActive(false);
            GameObject.Find("Button").SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
            time2 = timeravno;
    }
    public void WhenLoadScene()
    {
        invert.color = new Color(1, 1, 1, 0);
        right.color = new Color(1, 1, 1, 0);
        up.color = new Color(1, 1, 1, 0);
        left.color = new Color(1, 1, 1, 0);
        down.color = new Color(1, 1, 1, 0);
        ispol.color = new Color(1, 1, 1, 0);
        mn.color = new Color(1, 1, 1, 0);
        
        retur.color = new Color(1, 1, 1, 0);
        menu.color = new Color(1, 1, 1, 0);
        txt.text = "";
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
    // herCol.Canvas.SetActive(false);
      
        if (gameObject.name == "menu")
        {
            retur.color = new Color(1, 1, 1, 1);
            menu.color = new Color(1, 1, 1, 1);
            invert.color = new Color(1, 1, 1, 0);
            right.color = new Color(1, 1, 1, 0);
            up.color = new Color(1, 1, 1, 0);
            left.color = new Color(1, 1, 1, 0);
            down.color = new Color(1, 1, 1, 0);
            ispol.color = new Color(1, 1, 1, 0);
           mn.color = new Color(1, 1, 1, 0);
            
            txt.text = "";
            Time.timeScale = 0;
           
        } else if (gameObject.name == "return" && retur.color == new Color(1, 1, 1, 1))
        {
            invert.color = new Color(1, 1, 1, 1);
           
            retur.color = new Color(1, 1, 1, 0);
            menu.color = new Color(1, 1, 1, 0);
            right.color = new Color(1, 1, 1, 0.5f);
            up.color = new Color(1, 1, 1,0.5f);
            left.color = new Color(1, 1, 1, 0.5f);
            down.color = new Color(1, 1, 1, 0.5f);
            ispol.color = new Color(1, 1, 1, 1);
            mn.color = new Color(1, 1, 1, 1);
            txt.text = "Использовать";
            Time.timeScale = time2;

        }
        else if (gameObject.name == "back" && menu.color == new Color(1, 1, 1, 1))
        {
            Time.timeScale = 1;
            retur.color = new Color(1, 1, 1, 0);
            menu.color = new Color(1, 1, 1, 0);
            Camera.main.transform.position = new Vector3(0, 22, -10);
            Cn.SetActive(false);
            GameObject.Find("Main Camera").GetComponent<AsinhronLoad>().StartCor(1);
            Camera.main.GetComponent<Transform>().position = new Vector3(0, 22, -10);
            
        }
        
    }
}
