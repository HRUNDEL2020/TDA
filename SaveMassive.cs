using UnityEngine;
using UnityEngine.UI;
public class SaveMassive : MonoBehaviour
{
    public Sprite irpich;
    public int MaxNum = 0;
    public int NumberImage = 0;
    public Sprite[] LookImage=new Sprite[10];
    private Image ImgInv;
    // Start is called before the first frame update
    void Start()
    {
        ImgInv = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("gg").GetComponent<MoveHero>().IsPc)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (NumberImage > 0)
                {
                    NumberImage--;

                }
                else
                {
                    NumberImage = MaxNum;
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (NumberImage < MaxNum)
                {
                    NumberImage++;

                }
                else
                {
                    NumberImage = 0;
                }
            }
            if (irpich != null)
            {
                if (LookImage[NumberImage] == irpich)
                {
                    GameObject.Find("man").GetComponent<MoveForPlayer>().RotateInt = -1;
                }
                else
                {
                    GameObject.Find("man").GetComponent<MoveForPlayer>().RotateInt = 1;
                }
            }
        }
        ImgInv.sprite = LookImage[NumberImage];
        while (LookImage[NumberImage] == null)
        {
            NumberImage++;
            if (NumberImage > MaxNum)
            {
                NumberImage = 0;
            }
        }
    }
    public void TapInvert()
    {
        GetComponent<Image>().color = Color.white;
        GetComponent<Image>().color += new Color(Random.Range(-0.2f, 0.2f), 0, 0, 0);
        if (NumberImage<MaxNum)
        {
            NumberImage++;
           
        }else
        {
            NumberImage = 0;
        }
        if (irpich != null)
        {
            if (LookImage[NumberImage] == irpich)
            {
                GameObject.Find("man").GetComponent<MoveForPlayer>().RotateInt = -1;
            }
            else
            {
                GameObject.Find("man").GetComponent<MoveForPlayer>().RotateInt = 1;
            }
        }

    }
    public bool HaveObject(Sprite TakeSprite)
    {
        foreach(Sprite WhoSprite in LookImage)
        {
            if (TakeSprite == WhoSprite)
            {
                return true;
            }
        }
        return false;
    }
}
