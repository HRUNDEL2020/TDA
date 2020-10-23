using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ColliderVrag : MonoBehaviour
{
    public Sprite knife;
    public SaveMassive svmas;
    public GameObject go1, go2,go3;
    public AudioSource aq;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {

            if (svmas.LookImage[svmas.NumberImage] != knife)
            {
                if (SceneManager.GetActiveScene().name == "lvl10")
                {
                    go3.SetActive(false);
                    go2.SetActive(true);
                    collision.gameObject.SetActive(false);
                    return;
                }
                Camera.main.transform.position = new Vector3(0, 22, -10);

                if (GameObject.Find("CloseUI"))
                {
                    GameObject.Find("CloseUI").SetActive(false);
                }
                if (GameObject.Find("PanelUI"))
                {
                    GameObject.Find("PanelUI").SetActive(false);
                }
                Camera.main.GetComponent<AsinhronLoad>().Die = true;
                Camera.main.GetComponent<AsinhronLoad>().StartCor(SceneManager.GetActiveScene().buildIndex + 1);
                GameObject.Find("zp").GetComponent<SaveLvl>().KEK();
                GameObject.Find("Canvas").SetActive(false);
            } else if(SceneManager.GetActiveScene().name=="lvl10")
            {
                aq.Stop();
                go3.SetActive(false);
                go1.SetActive(true);
               collision.gameObject.SetActive(false);
                return;
            }
        }
    }
}
