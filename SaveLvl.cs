   using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class SaveLvl : MonoBehaviour
{
    static Transform Camera;
    public Text textformoney;
    public Text texthelp;
    static int money = 20;
    static int sound_on = 0;
    static int keknylsa = 0;
    static string lvl;
    public AudioMixerGroup group;
    public Sprite soundoff, soundon;
    public GameObject cnvs, cnvs2;
    public GameObject[] obj;
    public AudioSource shit;
    // Start is called before the first frame update
    public void CheckSave()
    {
        if (PlayerPrefs.HasKey("moneycount"))
        {
            if (SceneManager.GetActiveScene().name == "menu")
            {

                money = PlayerPrefs.GetInt("moneycount");
                textformoney.text = "" + money;
            }
        }
        if (PlayerPrefs.HasKey("can"))
        {
            keknylsa = PlayerPrefs.GetInt("can");
        }
        if (PlayerPrefs.HasKey("sound"))
        {
            sound_on = PlayerPrefs.GetInt("sound");
            if (gameObject.name == "menu 1_0")
            {
                if (sound_on == 0)
                {
                    group.audioMixer.SetFloat("musicall", 0);
                    GameObject.Find(gameObject.name).GetComponent<SpriteRenderer>().sprite = soundon;
                }
                else
                {
                    group.audioMixer.SetFloat("musicall", -80);
                    GameObject.Find(gameObject.name).GetComponent<SpriteRenderer>().sprite = soundoff;

                }
            }
        }
    }
    public void Closee()
    {
     
      //  cnvs.SetActive(true);
     //  cnvs2.SetActive(false);
    }
   public void Cheat()
    {
        lvl = "lvl10";
        keknylsa = 0;
    }
    void Start()
    {
       
        Camera = GameObject.Find("Main Camera").GetComponent<Transform>();
        Time.timeScale = 1;


      
        if (SceneManager.GetActiveScene().name == "lvl10")
        {
            Debug.Log(keknylsa);
            if (keknylsa == 1)
            {
                Destroy(GameObject.Find("knife"));
            }

        }
        if (SceneManager.GetActiveScene().name == "lvl1")
        {
            if (1 < Convert.ToInt32(lvl.Replace("lvl", "")))
            {
                if (UnityEngine.Random.Range(0, 3) == 0)
                {
                    shit.Play();
                }
            }
        }
        if (SceneManager.GetActiveScene().name != "menu")
        {
         
            Debug.Log(Convert.ToInt32(SceneManager.GetActiveScene().name.Replace("lvl", "")));
            Debug.Log(Convert.ToInt32(lvl.Replace("lvl", "")));
            if (Convert.ToInt32(SceneManager.GetActiveScene().name.Replace("lvl", "")) > Convert.ToInt32(lvl.Replace("lvl", ""))){
                lvl = SceneManager.GetActiveScene().name;
                PlayerPrefs.SetString("lvlnumber", lvl);
                print(lvl);
            }
            CheckNightText();
        }
        
        else if(SceneManager.GetActiveScene().name == "menu")
        {
            if (!PlayerPrefs.HasKey("lvlnumber"))
            {
                lvl = "lvl1";
                PlayerPrefs.SetString("lvlnumber", lvl);
            } else
            {
                lvl = PlayerPrefs.GetString("lvlnumber");
            }
           
        }
        CheckSave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddMoney()
    {
        money += 5;
        if (SceneManager.GetActiveScene().name == "menu")
        {
            textformoney = GameObject.Find("countmoney").GetComponent<Text>();
            textformoney.text = "" + money;
            
        }
        PlayerPrefs.SetInt("moneycount", money);

    }
    public void KEK()
    {
        keknylsa = 1;
        PlayerPrefs.SetInt("can", keknylsa);
    }
    
    public void Inflachi()
    {
        if (money >= 10)
        {
            money -= 10;
            PlayerPrefs.SetInt("moneycount", money);
            
            Destroy(GameObject.Find("Canvas (1)"));
            
           GameObject.Find("Main Camera").GetComponent<Transform>().transform.position = new Vector3(0, 22, -10);
            GameObject.Find("Main Camera").GetComponent<AsinhronLoad>().StartCor(SceneManager.GetActiveScene().buildIndex + 1);

        } else
        {

        }
    }
    public void CheckNightText()
    {
        int e = Convert.ToInt32(SceneManager.GetActiveScene().name.Replace("lvl", ""));
        int q = Convert.ToInt32(lvl.Replace("lvl", ""));
        if (keknylsa == 1 && e < q)
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "lvl2":
                    texthelp.text = "Если ты решил пройти этот уровень в надежде вернуться на истинынй путь,то у тебя ничего не выйдет";
                    break;
                case "lvl4":
                    texthelp.text = "Ты все еще пытаешься вернуться на верный путь?";
                    break;
                case "lvl6":
                    texthelp.text = "Что тебя вообще сподвигнуло проходить этот уровень?";
                    break;
                case "lvl8":
                    texthelp.text = "Это мой любимый уровень";
                    break;
                case "lvl10":
                    texthelp.text = "Ты пришел сюда,что бы попытаться что-то исправить?";
                    break;
            }
        }
        else if (keknylsa == 1 && e == q)
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "lvl2":
                    texthelp.text += "Правда у тебя все равно уже ничего не получится изменить.";
                    break;
                case "lvl4":
                    texthelp.text += "Правда у тебя все равно уже ничего не получится изменить.";
                    break;
                case "lvl6":
                    texthelp.text += "Правда у тебя все равно уже ничего не получится изменить.";
                    break;
                case "lvl8":
                    texthelp.text += "Правда у тебя все равно уже ничего не получится изменить.";
                    break;
                case "lvl10":
                    texthelp.text += "Правда у тебя все равно уже ничего не получится изменить.";
                    break;
            }
          

        }
    }
    public void Levels()
    {
        cnvs2.SetActive(true);
        cnvs.SetActive(false);
        Debug.Log(obj[0].name);
        if (keknylsa == 1)
        {
            GameObject.Find("notext").GetComponent<Text>().text = "Sad end";
        }
        else
        {
            GameObject.Find("notext").GetComponent<Text>().text = "End?";
        }
        for (int i = 0; i < obj.Length; i++)
        {
                int o = Convert.ToInt32(lvl.Replace("lvl", ""));
                int e = Convert.ToInt32(obj[i].name);
            if ( e <  o)
            {
                obj[i].GetComponent<Image>().color += new Color(0, 0, 0, 0.5f);
                foreach (Transform child in obj[i].transform)
                {

                    if (GameObject.Find(child.name).GetComponent<Image>())
                    {
                        GameObject.Find(child.name).GetComponent<Image>().color += new Color(0, 0, 0, 0.5f);
                    }
                    else
                    {
                        GameObject.Find(child.name).GetComponent<Text>().color += new Color(0, 0, 0, 0.5f);
                    }
                }
            }
        }
    }
    public void NewGame()
    {
        keknylsa = 0;
        PlayerPrefs.DeleteKey("can");
        PlayerPrefs.DeleteKey("moneycount");
        money = 0;
        lvl = "lvl1";
        PlayerPrefs.SetString("lvlnumber", lvl);
        SceneManager.LoadScene(lvl);

    }
    public void Continue()
    {
        Debug.Log(PlayerPrefs.GetString("lvlnumber"));
        if (PlayerPrefs.GetString("lvlnumber") == "menu")
        {
            SceneManager.LoadScene("lvl1");
        }
        else   if (PlayerPrefs.HasKey("lvlnumber"))
        {

            SceneManager.LoadScene(PlayerPrefs.GetString("lvlnumber"));
        } 
    }
    public void Soun()
    {
        if (sound_on == 0)
        {
            GameObject.Find("sounds").GetComponent<Image>().sprite = soundoff;
            sound_on = 1;
            group.audioMixer.SetFloat("musicall", -80);
            PlayerPrefs.SetInt("sound", sound_on);
        }
        else
        {
            GameObject.Find("sounds").GetComponent<Image>().sprite = soundon;
            sound_on = 0;
            group.audioMixer.SetFloat("musicall", 0);
            PlayerPrefs.SetInt("sound", sound_on);
        }
    }
}
