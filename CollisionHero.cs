using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CollisionHero : MonoBehaviour
{
    public Animator AnimHero;
    public TapButton BtTup;
    public Transform HeroTransf;
    public AudioSource[] PlayAudio;
    public int ClockTT = 0;
    public GameObject pasxalka;
    public Sprite[] AllSprite;
    public GameObject WhoCollision,CarryObject,Canvas,MoneyUI,DieUI,PanelUI,PodMoneyUI, PodMoneyUI2,BookUI,menuUI;
    private Image InvertImage;
    public SaveMassive CheckMassive;
  
    public bool NotCan=false;
    // Start is called before the first frame update
    void Awake()
    {
        FindAll();
        BtTup = GameObject.Find("left").GetComponent<TapButton>();
 
        HeroTransf = GameObject.Find("gg").GetComponent<Transform>();
        AnimHero = GameObject.Find("gg").GetComponent<Animator>();
        InvertImage = GameObject.Find("invertar").GetComponent<Image>();
        CheckMassive = GameObject.Find("invertar").GetComponent<SaveMassive>();
    }
    public void LoadDie()
    {
        Camera.main.transform.position = new Vector3(0, 22, -10);
        if (GameObject.Find("Canvas"))
        {
            GameObject.Find("Canvas").SetActive(false);
        }
        Camera.main.GetComponent<AsinhronLoad>().Die = true;
        Camera.main.GetComponent<AsinhronLoad>().StartCor(1);
    }
    public void FindAll()
    {

        Canvas = GameObject.Find("Canvas");
        MoneyUI = GameObject.Find("Canvas (1)");
        PodMoneyUI = GameObject.Find("Money");
        PodMoneyUI2 = GameObject.Find("textbook");
        menuUI = GameObject.Find("menu");
        if (GameObject.Find("WindowDIe"))
        {
            DieUI = GameObject.Find("WindowDIe");
            DieUI.SetActive(false);
        }
        if (GameObject.Find("PanelUI"))
        {
            PanelUI = GameObject.Find("PanelUI");
            PanelUI.SetActive(false);
        }
        MoneyUI.SetActive(false);
       
        PlayAudio[0] = GameObject.Find("openbook").GetComponent<AudioSource>();
        PlayAudio[1] = GameObject.Find("gg").GetComponent<AudioSource>();
        PlayAudio[2] = GameObject.Find("opendoor").GetComponent<AudioSource>();
        PlayAudio[3] = GameObject.Find("openscaf").GetComponent<AudioSource>();
        PlayAudio[4] = GameObject.Find("closescaf").GetComponent<AudioSource>();
        PlayAudio[5] = GameObject.Find("openxolod").GetComponent<AudioSource>();
        PlayAudio[6] = GameObject.Find("closexolod").GetComponent<AudioSource>();
        PlayAudio[7] = GameObject.Find("takeit").GetComponent<AudioSource>();
        PlayAudio[8] = GameObject.Find("glass").GetComponent<AudioSource>();

        PlayAudio[9] = GameObject.Find("water").GetComponent<AudioSource>();
        PlayAudio[10] = GameObject.Find("cheeswater").GetComponent<AudioSource>();
        PlayAudio[11] = GameObject.Find("tyndyn").GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& GameObject.Find("gg").GetComponent<MoveHero>().IsPc)
        {
            CheckTap();
        }
    }
    public void ForChis()
    {
        PlayAudio[10].Play();
        int CountChis = 0;
        foreach(GameObject chisobject in GameObject.FindGameObjectsWithTag("ChisTag"))
        {
            if (chisobject.GetComponent<SpriteRenderer>().sprite !=AllSprite[21])
            {
                CountChis++;
                if (CountChis ==9)
                {
                    GameObject.Find("rat").GetComponent<MoveRat>().Tprat = new Vector2(0, -1);
                }
            }
        }
    }
    public void HowDeistv(Sprite setPsrite)
    {
        WhoCollision.GetComponent<SpriteRenderer>().sprite =setPsrite;
        CheckMassive.LookImage[CheckMassive.NumberImage] = null;
    }
    public void CheckObject(GameObject SaveObj,Vector2 tpVec)
    {
        if (CheckMassive.HaveObject(SaveObj.GetComponent<SpriteRenderer>().sprite) == false)
        {
            SaveObj.GetComponent<Transform>().transform.position = tpVec;
        }
    }
    public void CloseCheckMoney()
    {
      MoneyUI.SetActive(false);
       Canvas.SetActive(true);
        GameObject.Find("gg").GetComponent<MoveHero>().IsPc = true;
        PlayAudio[1].Play();
    }
    public void TpObject(GameObject SaveTpObj)
    {
        SaveTpObj.GetComponent<Transform>().transform.position = new Vector2(1000, 0);
    }
    public void DorWin()
    {
        Camera.main.transform.position = new Vector3(0, 22, -10);
        Canvas.SetActive(false);
        Camera.main.GetComponent<AsinhronLoad>().StartCor(SceneManager.GetActiveScene().buildIndex + 1);
        GameObject.Find("zp").GetComponent<SaveLvl>().AddMoney();
    }
    public void CheckTap()
    {
       
        if (WhoCollision != null)
        {
            Debug.Log(WhoCollision.name + " " + WhoCollision.tag);
            if (WhoCollision.tag != "TakeIt"&& WhoCollision.tag != "IsPanel")
            {
                switch (WhoCollision.name)
                {
                    
                     case "chees in cletka_0":
                        if (WhoCollision.GetComponent<SpriteRenderer>().sprite==AllSprite[22])
                        {
                            if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[21])
                            {
                                CheckMassive.MaxNum++;
                                CheckMassive.LookImage[CheckMassive.MaxNum] = AllSprite[24];
                                CheckMassive.NumberImage = CheckMassive.MaxNum;
                                WhoCollision.GetComponent<SpriteRenderer>().sprite = AllSprite[25];
                            } else
                            {
                                CheckMassive.MaxNum++;
                                CheckMassive.LookImage[CheckMassive.MaxNum] = AllSprite[23];
                                CheckMassive.NumberImage = CheckMassive.MaxNum;
                                WhoCollision.GetComponent<SpriteRenderer>().sprite = AllSprite[25];
                            }
                        }
                        break;
                    case "Clock":
                        NotCan = true;
                        WhoCollision.GetComponent<Animator>().SetBool("Active", true);
                        WhoCollision.GetComponent<AudioSource>().Play();

                        break;
                    case "door_win1":

                        DorWin();
                        break;
                    case "door_win3":
                        if (ClockTT == 4)
                        {
                            DorWin();
                        }
                        break;
                    case "door_win2":
                        if (CheckMassive.LookImage[CheckMassive.NumberImage] == GameObject.Find("klish").GetComponent<SpriteRenderer>().sprite)
                        {
                            GameObject.Find("gg").tag = "not";
                            DorWin();
                        }
                        break;
                    case "door_up2":
                        HeroTransf.transform.position = new Vector3(HeroTransf.transform.position.x + 18, -3.4f, 0);
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + 18, 0, -10);
                        if (AnimHero.GetInteger("member") == 6)
                        {
                            AnimHero.SetInteger("member", 2);
                        }
                        PlayAudio[2].Play();
                      //  GameObject.Find(AllObject[6]).GetComponent<Transform>().position = new Vector3(GameObject.Find(AllObject[6]).GetComponent<Transform>().position.x + 18, GameObject.Find(AllObject[6]).GetComponent<Transform>().position.y, 0);
                        break;
                   
                    case "door_down2":
                        if (pasxalka != null)
                        {
                            if (pasxalka.active == false)
                            {
                                if (Random.Range(0, 10) == 3)
                                {
                                    pasxalka.SetActive(true);
                                }
                            }
                            else
                            {
                                pasxalka.SetActive(false);
                            }
                        }
                        HeroTransf.transform.position = new Vector3(HeroTransf.transform.position.x - 18, 2.5f, 0);
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - 18, 0, -10);
                        if (AnimHero.GetInteger("member") == 2)
                        {
                            AnimHero.SetInteger("member", 6);
                        }
                        PlayAudio[2].Play();

                        break;
                     
                             case "door_win20":
                        if (GameObject.Find("Point Light 2D").GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity == 10000)
                        {
                            DorWin();
                        }

                        break;
                    case "door_up":
                        print("A");
                        HeroTransf.transform.position = new Vector3(-0.3f, 7, 0);
                        Camera.main.transform.position = new Vector3(0, 10, -10);
                        if (AnimHero.GetInteger("member") == 6)
                        {
                            AnimHero.SetInteger("member", 2);
                        }
                        PlayAudio[2].Play();

                        break;
                    
                    case "xolod":
                        if (WhoCollision.GetComponent<SpriteRenderer>().sprite == AllSprite[3])
                        {
                            WhoCollision.GetComponent<openobject>().Open();
                            PlayAudio[5].Play();
                            if (GameObject.Find("QWESOK"))
                            {
                                if (Random.Range(0, 5) == 3)
                                {
                                    GameObject.Find("QWESOK").transform.position = new Vector2(-5.41f, 12.85f);

                                }
                            }
                        }
                        else
                        {
                            WhoCollision.GetComponent<openobject>().Close();
                            PlayAudio[6].Play();

                            if (GameObject.Find("QWESOK"))
                            {
                                GameObject.Find("QWESOK").transform.position = new Vector2(10000000, 10000000000);

                               
                            }


                        }
                        break;
                    case "door_down":
                        if (AnimHero.GetInteger("member") == 2)
                        {
                            AnimHero.SetInteger("member", 6);
                        }
                        HeroTransf.transform.position = new Vector3(-0.3f, 2, 0);
                        Camera.main.transform.position = new Vector3(0, 0, -10);
                        PlayAudio[2].Play();

                        break;
                    case "stole2":
                       
                        GameObject.Find("doradyra").GetComponent<DoraCheck>().CheckVisibleSprite(CheckMassive.LookImage[CheckMassive.NumberImage]);
                        

                        break;
                    case "scafic":
                        if (WhoCollision.GetComponent<SpriteRenderer>().sprite == AllSprite[0])
                        {
                            WhoCollision.GetComponent<openobject>().Open();
                            PlayAudio[3].Play();
                        }
                        else
                        {
                            WhoCollision.GetComponent<openobject>().Close();
                            PlayAudio[4].Play();
                        }
                        break;
                    case "pot":
                        if (WhoCollision.GetComponent<SpriteRenderer>().sprite == AllSprite[16] & CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[15])
                        {
                            HowDeistv(AllSprite[12]);
                            GameObject.Find("pot1").GetComponent<AudioSource>().Play();
                        }
                        else if (WhoCollision.GetComponent<SpriteRenderer>().sprite == AllSprite[12] & CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[17])
                        {
                            HowDeistv(AllSprite[13]);
                            GameObject.Find("pot2").GetComponent<AudioSource>().Play();
                        }
                        else if (WhoCollision.GetComponent<SpriteRenderer>().sprite == AllSprite[14])
                        {
                            if (NotCan == true)
                            {
                                CheckMassive.MaxNum++;
                                CheckMassive.LookImage[CheckMassive.MaxNum] = AllSprite[10];
                                CheckMassive.NumberImage = CheckMassive.MaxNum;
                                NotCan = false;
                            }
                        }
                        break;
                    case "xolod_lvl9":
                        if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[19])
                        {
                            CheckMassive.LookImage[CheckMassive.NumberImage] = AllSprite[13];
                            Destroy(GameObject.Find("vinograde"));
                        }
                        else if (WhoCollision.GetComponent<SpriteRenderer>().sprite == AllSprite[3])
                        {

                            WhoCollision.GetComponent<SpriteRenderer>().sprite = AllSprite[2];
                            WhoCollision.GetComponent<Xolod_scr>().OOPEN();
                            PlayAudio[5].Play();
                         
                        }
                        else if (WhoCollision.GetComponent<SpriteRenderer>().sprite == AllSprite[2])
                        {
                            if (CheckMassive.LookImage[CheckMassive.NumberImage] != AllSprite[6] && CheckMassive.LookImage[CheckMassive.NumberImage] != AllSprite[20])
                            {
                                WhoCollision.GetComponent<SpriteRenderer>().sprite = AllSprite[3];
                                WhoCollision.GetComponent<Xolod_scr>().CLOOSE();

                                PlayAudio[6].Play();
                            }
                            else if(CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[6])
                            {
                                WhoCollision.GetComponent<Xolod_scr>().isChis = true;
                                if (WhoCollision.GetComponent<Xolod_scr>().setactive1 != null)
                                {
                                    WhoCollision.GetComponent<Xolod_scr>().setactive1.SetActive(true);
                                }
                                PlayAudio[7].Play();
                                CheckMassive.LookImage[CheckMassive.NumberImage] = null;
                            }
                            else if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[20])
                            {
                                WhoCollision.GetComponent<Xolod_scr>().isVinograde = true;
                                if (WhoCollision.GetComponent<Xolod_scr>().setactive2 != null)
                                {
                                    WhoCollision.GetComponent<Xolod_scr>().setactive2.SetActive(true);
                                }
                                PlayAudio[7].Play();
                                CheckMassive.LookImage[CheckMassive.NumberImage] = null;
                            }
                           
                        }
                        
                        break;
                    case "booking":
                        Canvas.SetActive(false);
                        BookUI.SetActive(true);
                        GameObject.Find("gg").GetComponent<MoveHero>().IsPc = false;
                        GameObject.Find("gg").GetComponent<MoveHero>().MoveVect = Vector3.zero;
                        GameObject.Find("gg").GetComponent<MoveHero>().ggmove.Stop();
                        GameObject.Find("gg").GetComponent<MoveHero>().CheckAnim();
                        break;

                    case "plita_cook":

                        if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[6])
                        {
                            CheckMassive.LookImage[CheckMassive.NumberImage] = null;
                            WhoCollision.GetComponent<CookingPlita>().YesCook();
                        }
                        else if (WhoCollision.GetComponent<CookingPlita>().isCook&& !GameObject.Find("fire(cl)"))
                        {

                            CheckMassive.MaxNum++;
                            CheckMassive.LookImage[CheckMassive.MaxNum] = AllSprite[10];
                           
                            CheckMassive.NumberImage = CheckMassive.MaxNum;
                            WhoCollision.GetComponent<CookingPlita>().isCook = false;
                        }
                        
                        else if (!GameObject.Find("fire(cl)"))
                        {
                            GameObject go = Instantiate(GameObject.Find("fire"), new Vector3(-1.936f, 13.901f, 0), transform.rotation) as GameObject;
                            go.name = "fire(cl)";
                            go.GetComponent<AudioSource>().Play();
                        }
                        else
                        {
                            Destroy(GameObject.Find("fire(cl)"));

                        }
                        break;
                    case "pygalo":

                        if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[6])
                        {
                            HowDeistv(AllSprite[7]);


                            GameObject.Find("pygaloeat").GetComponent<AudioSource>().Play();
                        }
                        else if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[9] & WhoCollision.GetComponent<SpriteRenderer>().sprite == AllSprite[7])
                        {
                            GameObject.Find("pygalodie").GetComponent<AudioSource>().Play();
                            CheckMassive.MaxNum++;
                            CheckMassive.LookImage[CheckMassive.MaxNum] = AllSprite[11];
                            HowDeistv(AllSprite[8]);

                        }
                        else if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[9] & WhoCollision.GetComponent<SpriteRenderer>().sprite != AllSprite[7])
                        {
                            CheckMassive.LookImage[CheckMassive.NumberImage] = null;
                            PlayAudio[8].Play();
                            LoadDie();
                        }

                        break;
                   
                   
                   
                    case "scafic_fire":
                        if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[21])
                        {
                            WhoCollision.GetComponent<ScafeFire>().SetActiveObj();
                        }
                       
                            break;
                    
                   
                    case "plita":
                        if (!GameObject.Find("fire(cl)"))
                        {
                            if (SceneManager.GetActiveScene().name != "lvl8")
                            {
                                GameObject go = Instantiate(GameObject.Find("fire"), new Vector3(-1.936f, 13.901f, 0), transform.rotation) as GameObject;
                                go.name = "fire(cl)";
                                go.GetComponent<AudioSource>().Play();
                            } else
                            {
                                GameObject go = Instantiate(GameObject.Find("fire"), new Vector3(-1.927f, 4.016f, 0), transform.rotation) as GameObject;
                                go.name = "fire(cl)";
                            }
                          
                        }
                        else
                        {
                            Destroy(GameObject.Find("fire(cl)"));

                        }
                        break;
                    case "stole":
                        if (MoneyUI.active != true)
                        {
                            menuUI.SetActive(false);
                            MoneyUI.SetActive(true);
                            PodMoneyUI2.SetActive(true);
                            PodMoneyUI.SetActive(false);
                            PlayAudio[0].Play();
                        }
                        break;
                    case "clock":
                       if(CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[22] && WhoCollision.GetComponent<SpriteRenderer>().color.a<1)
                        {
                            PlayAudio[11].Play();
                            WhoCollision.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 1);
                            CheckMassive.LookImage[CheckMassive.NumberImage] = null;
                            ClockTT++;
                          
                        }
                        break;
                    case "bonk":
                        if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[19])
                        {
                            PlayAudio[9].Play();
                            CheckMassive.LookImage[CheckMassive.NumberImage] = AllSprite[20];
                            WhoCollision.GetComponent<BonkBonk>().SetSprite();
                        }
                        break;
                    case "chis_stav":
                        if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[6])
                        {
                            PlayAudio[7].Play();
                            WhoCollision.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 1);
                            CheckMassive.LookImage[CheckMassive.NumberImage] = null;
                            GameObject.Find("rat").GetComponent<IIRat>().isSeak = true;
                        }
                        break;
                    case "bed":
                        if (CheckMassive.LookImage[CheckMassive.NumberImage] != AllSprite[19])
                        {
                            GameObject.Find("gg").GetComponent<MoveHero>().IsPc = false;
                            GameObject.Find("gg").GetComponent<MoveHero>().MoveVect = Vector3.zero;
                            GameObject.Find("gg").GetComponent<MoveHero>().ggmove.Stop();
                            GameObject.Find("gg").GetComponent<MoveHero>().CheckAnim();
                            Canvas.SetActive(false);
                            MoneyUI.SetActive(true);
                            PodMoneyUI.SetActive(true);
                            PodMoneyUI2.SetActive(false);
                            
                            PlayAudio[0].Play();
                        }else
                        {
                            CheckMassive.LookImage[CheckMassive.NumberImage] = AllSprite[18];

                        }
                       
                        break;
                    case "chis":
                        if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[19])
                        {
                            WhoCollision.GetComponent<SpriteRenderer>().sprite = AllSprite[22];
                            CheckMassive.LookImage[CheckMassive.NumberImage] = AllSprite[20];
                            ForChis();
                        }
                        else if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[17])
                        {
                            WhoCollision.GetComponent<SpriteRenderer>().sprite = AllSprite[23];
                            CheckMassive.LookImage[CheckMassive.NumberImage] = AllSprite[20];
                            ForChis();
                        }
                        else if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[18])
                        {
                            WhoCollision.GetComponent<SpriteRenderer>().sprite = AllSprite[24];
                            CheckMassive.LookImage[CheckMassive.NumberImage] = AllSprite[20];
                            ForChis();
                        }
                        else if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[16])
                        {
                            WhoCollision.GetComponent<SpriteRenderer>().sprite = AllSprite[25];
                            CheckMassive.LookImage[CheckMassive.NumberImage] = AllSprite[20];
                            ForChis();
                        }
                        break;
                    case "drnk2":
                        if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[16])
                        {
                            PlayAudio[9].Play();
                            CheckMassive.LookImage[CheckMassive.NumberImage] = AllSprite[17];
                            WhoCollision.transform.Find("color").GetComponent<Transform>().localScale = new Vector3(1, WhoCollision.transform.Find("color").GetComponent<Transform>().localScale.y - 0.5f, 1);
                        }
                        break;
                    case "kapysta":

                        if (WhoCollision.GetComponent<kapystablat>().stadia != 3)
                        {
                            CheckMassive.LookImage[CheckMassive.NumberImage] = WhoCollision.GetComponent<kapystablat>().KAPYSTA(CheckMassive.LookImage[CheckMassive.NumberImage]);
                        } else
                        {
                            CheckMassive.MaxNum++;
                            CheckMassive.LookImage[CheckMassive.MaxNum] = WhoCollision.GetComponent<kapystablat>().KAPYSTA(CheckMassive.LookImage[CheckMassive.NumberImage]);
                            CheckMassive.NumberImage = CheckMassive.MaxNum;
                        }
                        if (WhoCollision.GetComponent<kapystablat>().isCan)
                        {
                            WhoCollision.GetComponent<kapystablat>().stadia++;
                        }
                        break;
                    case "cook":
                        WhoCollision.GetComponent<Cooking>().ActiveObj(CheckMassive.LookImage[CheckMassive.NumberImage]);
                     
                        break;
                    case "eat":
                        Debug.Log("belisino");
                        if (CheckMassive.LookImage[CheckMassive.NumberImage] != AllSprite[4])
                        {
                            WhoCollision.GetComponent<Eat>().check(CheckMassive.LookImage[CheckMassive.NumberImage]);
                            CheckMassive.LookImage[CheckMassive.NumberImage] = null;
                        }
                        break;
                    case "drnk":
                        if (CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[20] || CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[19] || CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[18] || CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[17] || CheckMassive.LookImage[CheckMassive.NumberImage] == AllSprite[16])
                        {
                            foreach (Transform child in WhoCollision.transform)
                            {
                                if (child.GetComponent<SpriteRenderer>())
                                {
                                    if (child.GetComponent<Transform>().localScale != new Vector3(1, 0, 1))
                                    {
                                        switch (child.GetComponent<SpriteRenderer>().color.g)
                                        {

                                            case 0.5f:

                                                if (CheckMassive.LookImage[CheckMassive.NumberImage] != AllSprite[17])
                                                {
                                                    CheckMassive.LookImage[CheckMassive.NumberImage] = AllSprite[17];
                                                    child.GetComponent<Transform>().localScale = new Vector3(1, child.GetComponent<Transform>().localScale.y - 0.5f, 1);
                                                }
                                                break;
                                            case 0.4f:

                                                if (CheckMassive.LookImage[CheckMassive.NumberImage] != AllSprite[16])
                                                {
                                                    CheckMassive.LookImage[CheckMassive.NumberImage] = AllSprite[16];
                                                    child.GetComponent<Transform>().localScale = new Vector3(1, child.GetComponent<Transform>().localScale.y - 0.5f, 1);
                                                }
                                                break;
                                            case 0f:

                                                if (CheckMassive.LookImage[CheckMassive.NumberImage] != AllSprite[18])
                                                {
                                                    CheckMassive.LookImage[CheckMassive.NumberImage] = AllSprite[18];
                                                    child.GetComponent<Transform>().localScale = new Vector3(1, child.GetComponent<Transform>().localScale.y - 0.5f, 1);
                                                }
                                                break;
                                            case 0.05f:

                                                if (CheckMassive.LookImage[CheckMassive.NumberImage] != AllSprite[19])
                                                {
                                                    CheckMassive.LookImage[CheckMassive.NumberImage] = AllSprite[19];
                                                    child.GetComponent<Transform>().localScale = new Vector3(1, child.GetComponent<Transform>().localScale.y - 0.5f, 1);
                                                }
                                                break;
                                        }
                                    }
                                    PlayAudio[9].Play();
                                    break;
                                }

                            }
                        }
                        break;
                    case "strelka_1":
                        CheckMassive.MaxNum++;
                        CheckMassive.LookImage[CheckMassive.MaxNum] = GameObject.Find("klish").GetComponent<SpriteRenderer>().sprite;

                        TpObject(GameObject.Find("klish"));
                        PlayAudio[7].Play();

                        break;

                }

            } else if (WhoCollision.tag == "IsPanel")
            {
               
                Canvas.SetActive(false);
                GameObject.Find("gg").GetComponent<MoveHero>().IsPc = false;
                GameObject.Find("gg").GetComponent<MoveHero>().MoveVect = Vector3.zero;
                GameObject.Find("gg").GetComponent<MoveHero>().ggmove.Stop();
                GameObject.Find("gg").GetComponent<MoveHero>().CheckAnim();
                PanelUI.SetActive(true);
                AnimHero.SetInteger("member", 6);
                for (int b = 0; b < 4; b++)
                {
                    GameObject.Find("Panel").transform.GetChild(b).GetComponent<RotateBolt>().panelobj = WhoCollision;
                    if (WhoCollision.transform.GetChild(b).GetComponent<SpriteRenderer>().sprite == null)
                    {
                        GameObject.Find("Panel").transform.GetChild(b).GetComponent<RotateBolt>().hp = -1;
                        GameObject.Find("Panel").transform.GetChild(b).GetComponent<Image>().color = new Color(0, 0, 0, 0);
                        GameObject.Find("Panel").transform.GetChild(b).GetComponent<Image>().sprite =null;
                    }
                }


               
            }
            else
            {
                CheckMassive.MaxNum++;
                CheckMassive.LookImage[CheckMassive.MaxNum] = WhoCollision.GetComponent<SpriteRenderer>().sprite;

                
                
                WhoCollision.GetComponent<Transform>().transform.position = new Vector2(10000000, 0);
                Destroy(WhoCollision);
                PlayAudio[7].Play();
            }
                
                
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "not")
        {
            WhoCollision = collision.gameObject;
            if (collision.gameObject.name == "pasxalka")
            {
                pasxalka.SetActive(false);
            }
                       
          
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        WhoCollision = null;
    }

}
